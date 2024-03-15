using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Windows.Forms;
using Tutorial4;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Cryptography;
using System.Net;
using System.Reflection;

namespace Tutorial03
{
    public partial class StaffInformation : Form
    {
        private readonly DataTable staffDataTable = new DataTable();
        DBAccess DB = new DBAccess();
        public StaffInformation()
        {
            InitializeComponent();
            dBirthDate.MaxDate = DateTime.Now;
            dBirthDate.Format = DateTimePickerFormat.Custom;
            dBirthDate.CustomFormat = "0 / 00 / 0000";
            txtAge.Text = "";
            dJoinDate.Value = dJoinDate.MinDate;
            dJoinDate.MaxDate = DateTime.Now;
            dJoinDate.Format = DateTimePickerFormat.Custom;
            dJoinDate.CustomFormat = "0 / 00 / 0000";

            staffDataTable.Columns.Add("StaffID", typeof(int));
            staffDataTable.Columns.Add("Image", typeof(string));
            staffDataTable.Columns.Add("StaffName", typeof(string));
            staffDataTable.Columns.Add("Gender", typeof(string));
            staffDataTable.Columns.Add("JoinDate", typeof(DateTime));
            staffDataTable.Columns.Add("StaffType", typeof(string));
            staffDataTable.Columns.Add("NRCNo", typeof(string));
            staffDataTable.Columns.Add("PhoneNumber1", typeof(string));
            staffDataTable.Columns.Add("PhoneNumber2", typeof(string));
            staffDataTable.Columns.Add("Address", typeof(string));
            staffDataTable.Columns.Add("Age", typeof(int));
        }

        private void dBirthDate_ValueChanged(object sender, EventArgs e)
        {

            if (dBirthDate.Value != DateTime.MinValue)
            {
                dBirthDate.CustomFormat = "dd / MM / yyyy";
                int age = DateTime.Today.Year - dBirthDate.Value.Year;
                if (dBirthDate.Value.Date > DateTime.Today.AddYears(-age))
                    age--;
                txtAge.Text = age.ToString();
            }
            else
            {
                dBirthDate.CustomFormat = "0 / 00 / 0000";
                txtAge.Text = "";
            }
        }

        private void dJoinDate_ValueChanged(object sender, EventArgs e)
        {
            if (dJoinDate.Value != DateTime.MinValue)
            {
                dJoinDate.CustomFormat = "dd / MM / yyyy";
            }
            else
            {
                dJoinDate.CustomFormat = "0 / 00 / 0000";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string alphaPattern = @"^[\p{L}\s]+$";
            if (!Regex.IsMatch(txtStaffName.Text, alphaPattern))
            {
                errorProviderCommon.SetError(txtStaffName, "Invalid staff name.");
            }
            else
            {
                errorProviderCommon.SetError(txtStaffName, "");
            }

            if (dJoinDate.Value == dJoinDate.MinDate)
            {
                errorProviderCommon.SetError(dJoinDate, "Join Date cannot be empty.");
            }
            else
            {
                errorProviderCommon.SetError(dJoinDate, "");
            }

            if (dBirthDate.Value.Year == DateTime.Today.Year && dBirthDate.Value.Month == DateTime.Today.Month && dBirthDate.Value.Day == DateTime.Today.Day)
            {
                errorProviderCommon.SetError(dBirthDate, "Birth Date cannot be empty.");
            }
            else
            {
                errorProviderCommon.SetError(dBirthDate, "");
            }

            if (cbStaffType.SelectedItem == null)
            {
                errorProviderCommon.SetError(cbStaffType, "Staff type cannot be empty.");
            }
            else
            {
                errorProviderCommon.SetError(cbStaffType, "");
            }

            string nrcPattern = @"^\d+\/[a-zA-Z]+\([a-zA-Z]+\)\d{6}$";
            if (!Regex.IsMatch(txtNrcNo.Text, nrcPattern) || txtNrcNo.Text.Length <= 15)
            {
                errorProviderCommon.SetError(txtNrcNo, "Invalid NRC NO format.");
            }
            else
            {
                errorProviderCommon.SetError(txtNrcNo, "");
            }

            string numericPattern = @"^\d+$";
            if (Regex.IsMatch(txtPhoneNo1.Text, numericPattern) && txtPhoneNo1.Text.Length >= 5)
            {
                errorProviderCommon.SetError(txtPhoneNo1, "");
            }
            else
            {
                errorProviderCommon.SetError(txtPhoneNo1, "Invalid phone number format. Please enter a numeric value.");
            }

            byte[] imageData = pbStaffPhoto.Image != null ? ImageToByteArray(pbStaffPhoto.Image) : new byte[0];

            bool errorsPresent = errorProviderCommon.ContainerControl.Controls
                .OfType<Control>()
                .Any(control => !string.IsNullOrEmpty(errorProviderCommon.GetError(control)));

            if (!errorsPresent)
            {
                if (lvStaffInfo.SelectedItems.Count > 0)
                {
                    lvStaffInfo.SelectedItems[0].SubItems[0].Text = txtStaffNo.Text;
                    //update image soon
                    lvStaffInfo.SelectedItems[0].SubItems[1].Text = "Image";
                    lvStaffInfo.SelectedItems[0].SubItems[5].Text = txtNrcNo.Text;
                    lvStaffInfo.SelectedItems[0].SubItems[2].Text = txtStaffName.Text;
                    lvStaffInfo.SelectedItems[0].SubItems[4].Text = cbStaffType.Text;
                    lvStaffInfo.SelectedItems[0].SubItems[6].Text = GetGender();
                    lvStaffInfo.SelectedItems[0].SubItems[8].Text = txtPhoneNo1.Text;
                    lvStaffInfo.SelectedItems[0].SubItems[9].Text = txtPhoneNo2.Text;
                    lvStaffInfo.SelectedItems[0].SubItems[10].Text = rtxtAddress.Text;
                    clear();

                    SqlCommand updateCommand = new SqlCommand("UPDATE StaffInformation SET Image=@Image, Name=@Name, JoinFrom=@JoinFrom, StaffType=@StaffType, NrcNo=@NrcNo, Gender=@Gender, BirthDate=@BirthDate, PhoneNo1=@PhoneNo1, PhoneNo2=@PhoneNo2, Address=@Address WHERE Id=@StaffId");

                    // Bind parameters
                    updateCommand.Parameters.AddWithValue("@Image", imageData);
                    updateCommand.Parameters.AddWithValue("@Name", txtStaffName.Text);
                    updateCommand.Parameters.AddWithValue("@JoinFrom", dJoinDate.Value.Date);
                    updateCommand.Parameters.AddWithValue("@StaffType", cbStaffType.SelectedItem.ToString());
                    updateCommand.Parameters.AddWithValue("@NrcNo", txtNrcNo.Text);
                    updateCommand.Parameters.AddWithValue("@Gender", GetGender().ToString());
                    updateCommand.Parameters.AddWithValue("@BirthDate", dBirthDate.Value.Date);
                    updateCommand.Parameters.AddWithValue("@PhoneNo1", txtPhoneNo1.Text); // Assuming PhoneNo1 is an integer
                    updateCommand.Parameters.AddWithValue("@PhoneNo2", txtPhoneNo2.Text);
                    updateCommand.Parameters.AddWithValue("@Address", rtxtAddress.Text);
                    updateCommand.Parameters.AddWithValue("@StaffId", txtStaffNo.Text); // Assuming the primary key column is named "Id"

                    int result = DB.executeQuery(updateCommand);
                    if (result == 1)
                    {
                        MessageBox.Show("Updating Staff Success");
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Update Staff");
                        return;
                    }
                }
                else
                {
                    DataRow newRow = staffDataTable.NewRow();
                    int id = 1;
                    if (staffDataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in staffDataTable.Rows)
                        {
                            int rowId = Convert.ToInt32(row["StaffID"]);
                            if (rowId >= id)
                            {
                                id = rowId + 1;
                            }
                        }
                    }
                    newRow["StaffID"] = id;
                    newRow["Image"] = imageData.ToString();
                    newRow["StaffName"] = txtStaffName.Text;
                    newRow["Gender"] = GetGender();
                    newRow["Age"] = txtAge.Text;
                    newRow["JoinDate"] = dJoinDate.Value.Date;
                    newRow["StaffType"] = cbStaffType.SelectedItem.ToString();
                    newRow["NRCNo"] = txtNrcNo.Text;
                    newRow["PhoneNumber1"] = txtPhoneNo1.Text;
                    newRow["PhoneNumber2"] = txtPhoneNo2.Text;
                    newRow["Address"] = rtxtAddress.Text;
                    staffDataTable.Rows.Add(newRow);
                    PopulateListViewWithDataTable();

                    SqlCommand insertCommand = new SqlCommand("INSERT INTO StaffInformation (Image,Name,JoinFrom,StaffType,NrcNo,Gender,BirthDate,PhoneNo1,PhoneNo2,Address) VALUES (@Image,@Name,@JoinFrom,@StaffType,@NrcNo,@Gender,@BirthDate,@PhoneNo1,@PhoneNo2,@Address)");
                    insertCommand.Parameters.AddWithValue("@Name", txtStaffName.Text);
                    insertCommand.Parameters.AddWithValue("@Image", imageData.ToString());
                    insertCommand.Parameters.AddWithValue("@JoinFrom", dBirthDate.Value.Date);
                    insertCommand.Parameters.AddWithValue("@StaffType", cbStaffType.SelectedItem.ToString());
                    insertCommand.Parameters.AddWithValue("@NrcNo", txtNrcNo.Text);
                    insertCommand.Parameters.AddWithValue("@Gender", GetGender().ToString());
                    insertCommand.Parameters.AddWithValue("@BirthDate", dBirthDate.Value.Date);
                    insertCommand.Parameters.AddWithValue("@PhoneNo1", txtPhoneNo1.Text);
                    insertCommand.Parameters.AddWithValue("@PhoneNo2", txtPhoneNo2.Text);
                    insertCommand.Parameters.AddWithValue("@Address", rtxtAddress.Text);
                    int result = DB.executeQuery(insertCommand);
                    if (result == 1)
                    {
                        MessageBox.Show("Adding Staff Success");
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Fail");
                    }
                }

               
            }
            else
            {
                MessageBox.Show("Error still present");
            }
        }

        private string GetGender()
        {
            return rdMale.Checked ? "Male" : (rdfemale.Checked ? "Female" : (rdOther.Checked ? "Other" : ""));
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void PopulateListViewWithDataTable()
        {
            lvStaffInfo.Items.Clear();
            foreach (DataRow row in staffDataTable.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = row["StaffID"].ToString();
               
                //update comming soon
                item.SubItems.Add("Image");

                item.SubItems.Add(row["StaffName"].ToString());
                item.SubItems.Add(row["JoinDate"].ToString());
                item.SubItems.Add(row["StaffType"].ToString());
                item.SubItems.Add(row["NRCNo"].ToString());
                item.SubItems.Add(row["Gender"].ToString());
                item.SubItems.Add(row["Age"].ToString());
                item.SubItems.Add(row["PhoneNumber1"].ToString());
                item.SubItems.Add(row["PhoneNumber2"].ToString());
                item.SubItems.Add(row["Address"].ToString());
                lvStaffInfo.Items.Add(item);
            }
        }

        private void clickChooseFile(object sender, EventArgs e)
        {
            OpenFileDialog uploadImage = new OpenFileDialog();
            uploadImage.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;*.png;)|*.jpg;*.jpeg;.*.gif;*.png";
            if (uploadImage.ShowDialog() == DialogResult.OK)
            {
                pbStaffPhoto.Image = new Bitmap(uploadImage.FileName);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            txtStaffNo.Text = "";
            txtNrcNo.Text = "";
            txtStaffName.Text = "";
            cbStaffType.Text = "";
            rdMale.Checked = false;
            rdfemale.Checked = false;
            rdOther.Checked = false;
            txtPhoneNo1.Text = "";
            txtPhoneNo2.Text = "";
            rtxtAddress.Text = "";
            dJoinDate.Value = dJoinDate.MinDate;
            dBirthDate.Value = DateTime.Today;
            dJoinDate.CustomFormat = "0 / 00 / 0000";
            dBirthDate.CustomFormat = "0 / 00 / 0000";
            pbStaffPhoto.Image = null;
        }

        private void lvStaffInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStaffInfo.SelectedItems.Count > 0)
            {
                btnDelete.Enabled = true;
                btnAdd.Text = "Update";
                listViewClick();
            }
            else { 
                btnDelete.Enabled = false
                    ;
                btnAdd.Text = "Add";
                clear();
            }
        }

        private void listViewClick()
        {

            txtStaffNo.Text = lvStaffInfo.SelectedItems[0].SubItems[0].Text;
            txtNrcNo.Text = lvStaffInfo.SelectedItems[0].SubItems[5].Text;
            txtStaffName.Text = lvStaffInfo.SelectedItems[0].SubItems[2].Text;

            if (DateTime.TryParse(lvStaffInfo.SelectedItems[0].SubItems[3].Text, out DateTime joinDate))
            {
                dJoinDate.Value = joinDate;
            }
            else
            {
                dJoinDate.Value = DateTime.Today;
            }

            dBirthDate.Value = DateTime.Today;

            cbStaffType.Text = lvStaffInfo.SelectedItems[0].SubItems[4].Text;

            string updateGender = lvStaffInfo.SelectedItems[0].SubItems[6].Text;
            if (updateGender == "Male")
            {
                rdMale.Checked = true;
            }
            else if (updateGender == "Female")
            {
                rdfemale.Checked = true;
            }
            else if (updateGender == "Other")
            {
                rdOther.Checked = true;
            }
            else
            {
                rdMale.Checked = false;
                rdfemale.Checked = false;
                rdOther.Checked = false;
            }

            txtPhoneNo1.Text = lvStaffInfo.SelectedItems[0].SubItems[8].Text;
            txtPhoneNo2.Text = lvStaffInfo.SelectedItems[0].SubItems[9].Text;
            rtxtAddress.Text = lvStaffInfo.SelectedItems[0].SubItems[10].Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvStaffInfo.SelectedItems.Count > 0)
            {
                lvStaffInfo.Items.Remove(lvStaffInfo.SelectedItems[0]);
                clear();
            }
            else
            {
                MessageBox.Show("Choose a row you want to Delete!");
            }
        }

        private void first_load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            string query = "SELECT * FROM StaffInformation;";
            SqlDataReader reader = DB.readDatathroughReader(query);
            if (reader.HasRows)
            {
                foreach (var row in reader)
                {
                    DataRow newRow = staffDataTable.NewRow();
                    newRow["StaffID"] = reader.GetInt32(0);
                    newRow["Image"] = reader.GetString(1); ;
                    newRow["StaffName"] = reader.GetString(2);
                    newRow["JoinDate"] = reader.GetDateTime(3).Date;
                    newRow["StaffType"] = reader.GetString(4);
                    newRow["NRCNo"] = reader.GetString(5);
                    newRow["Gender"] = reader.GetString(10);
                    newRow["Age"] = (DateTime.Today.Year - reader.GetDateTime(6).Year).ToString();
                    newRow["PhoneNumber1"] = reader.GetInt32(7);
                    newRow["PhoneNumber2"] = reader.GetInt32(8);
                    newRow["Address"] = reader.GetString(9);

                    staffDataTable.Rows.Add(newRow);
                    //MessageBox.Show("Adding staff successful");
                    PopulateListViewWithDataTable();
                    clear();
                }
            }
            reader.Close();
        }
    }
}
