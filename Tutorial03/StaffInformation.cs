using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Tutorial03
{
    public partial class StaffInformation : Form
    {

        DataTable staffDataTable = new DataTable();

        // Add columns to the DataTable for different staff attributes


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


            staffDataTable.Columns.Add("StaffID", typeof(int)); // Assuming StaffID is an integer
            staffDataTable.Columns["StaffID"].AutoIncrement = true;
            staffDataTable.Columns["StaffID"].AutoIncrementSeed = 1;
            staffDataTable.Columns.Add("Image", typeof(byte[])); // Column to store image as byte array
            staffDataTable.Columns.Add("StaffName", typeof(string));
            staffDataTable.Columns.Add("Gender", typeof(string));
            staffDataTable.Columns.Add("JoinDate", typeof(DateTime));
            staffDataTable.Columns.Add("StaffType", typeof(string));
            staffDataTable.Columns.Add("NRCNo", typeof(string));
            staffDataTable.Columns.Add("PhoneNumber1", typeof(string)); // Phone number 1
            staffDataTable.Columns.Add("PhoneNumber2", typeof(string)); // Phone number 2
            staffDataTable.Columns.Add("Address", typeof(string)); // Address
            staffDataTable.Columns.Add("Age", typeof(int)); // Age

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        // Adding Staff
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //validation for staff name
            string alphaPattern = @"^[\p{L}\s]+$";
            if (!Regex.IsMatch(txtStaffName.Text, alphaPattern))
            {
                errorProviderCommon.SetError(txtStaffName, "Invalid staff name .");
            }
            else
            {
                errorProviderCommon.SetError(txtStaffName, "");
            }


            //validateion for Join date
            if (dJoinDate.Value == dJoinDate.MinDate)
            {
                errorProviderCommon.SetError(dJoinDate, "Join Date cannot be empty.");
            }
            else
            {
                errorProviderCommon.SetError(dJoinDate, "");
            }

            //validation for birthday
            if (dBirthDate.Value.Year == DateTime.Today.Year && dBirthDate.Value.Month == DateTime.Today.Month && dBirthDate.Value.Day == DateTime.Today.Day)
            {
                errorProviderCommon.SetError(dBirthDate, "Birth Date cannot be empty.");
            }
            else
            {
                errorProviderCommon.SetError(dBirthDate, "");
            }

            //validation for staff type
            if (cbStaffType.SelectedItem == null)
            {
                errorProviderCommon.SetError(cbStaffType, "Staff type cannot be empty.");
            }
            else
            {
                errorProviderCommon.SetError(cbStaffType, "");
            }

            //validation for NRC NO
            string nrcPattern = @"^\d+\/[a-zA-Z]+\([a-zA-Z]+\)\d{6}$";

            if (!Regex.IsMatch(txtNrcNo.Text, nrcPattern) || txtNrcNo.Text.Length <= 15)
            {
                errorProviderCommon.SetError(txtNrcNo, "Invalid NRC NO format.");
            }
            else
            {
                errorProviderCommon.SetError(txtNrcNo, "");
            }

            //getting gender
            string gender = "";
            if (rdMale.Checked)
            {
                gender = rdMale.Text;
            }
            else if (rdfemale.Checked)
            {
                gender = rdfemale.Text;
            }
            else if (rdOther.Checked)
            {
                gender = rdOther.Text;
            }
            else
            {
                gender = "";
            }

            //validation for phone number
            string numericPattern = @"^\d+$";
            if (Regex.IsMatch(txtPhoneNo1.Text, numericPattern) && txtPhoneNo1.Text.Length >= 5)
            {
                errorProviderCommon.SetError(txtPhoneNo1, "");
            }
            else
            {
                errorProviderCommon.SetError(txtPhoneNo1, "Invalid phone number format. Please enter a numeric value.");

            }

            // Check if any error is present
            bool errorsPresent = errorProviderCommon.ContainerControl.Controls
                .OfType<Control>()
                .Any(control => !string.IsNullOrEmpty(errorProviderCommon.GetError(control)));

            if (!errorsPresent)
            {
                byte[] imageData;
                if (pbStaffPhoto.Image != null)
                {
                    imageData = ImageToByteArray(pbStaffPhoto.Image);
                }
                else
                {
                    imageData = new byte[0];
                }

                // Add data to staffDataTable
                DataRow newRow = staffDataTable.NewRow();
                newRow["Image"] = imageData; // Store image as bytes
                newRow["StaffName"] = txtStaffName.Text;
                newRow["Gender"] = gender;
                newRow["Age"] = txtAge.Text;
                newRow["JoinDate"] = dJoinDate.Value.Date;
                newRow["StaffType"] = cbStaffType.SelectedItem.ToString();
                newRow["NRCNo"] = txtNrcNo.Text;
                newRow["PhoneNumber1"] = txtPhoneNo1.Text;
                newRow["PhoneNumber2"] = txtPhoneNo2.Text;
                newRow["Address"] = rtxtAddress.Text;

                staffDataTable.Rows.Add(newRow);
                MessageBox.Show("Adding staff successful");

                PopulateListViewWithDataTable();
            }
            else
            {
                MessageBox.Show("Error still present");
            }
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
                // Add other columns as needed
                item.SubItems.Add("Image"); // Placeholder for image
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
        

        ate void birthDate_Validation(object sender, System.ComponentModel.CancelEventArgs e)
        {

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

        private void djoinDate_Validate(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}