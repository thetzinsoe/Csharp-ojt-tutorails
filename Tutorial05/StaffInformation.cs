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
using System.Reflection.PortableExecutable;

namespace Tutorial03
{
    public partial class StaffInformation : Form
    {
        private int currentPage = 1;
        private int pageSize = 5;
        private int totalRecords = 0;
        private int countPage = 0;
        private readonly DataTable staffDataTable = new DataTable();
        DBAccess DB = new DBAccess();
        string imagePath = "";
        byte[] imageData = new byte[0];
        byte[] noImage = File.ReadAllBytes(Environment.CurrentDirectory + "\\Images\\noImage.png");

        public StaffInformation()
        {
            InitializeComponent();
            txtStaffName.Focus();
            btnPrevious.Enabled = false;
            dBirthDate.MaxDate = DateTime.Now;
            dBirthDate.Format = DateTimePickerFormat.Custom;
            dBirthDate.CustomFormat = "0 / 00 / 0000";
            txtAge.Text = "";
            dJoinDate.Value = dJoinDate.MinDate;
            dJoinDate.MaxDate = DateTime.Now;
            dJoinDate.Format = DateTimePickerFormat.Custom;
            dJoinDate.CustomFormat = "0 / 00 / 0000";

            staffDataTable.Columns.Add("Staff No.", typeof(int));
            staffDataTable.Columns.Add("Image", typeof(byte[]));
            staffDataTable.Columns.Add("Staff Name", typeof(string));
            staffDataTable.Columns.Add("Join From", typeof(DateTime));
            staffDataTable.Columns.Add("Staff Type", typeof(string));
            staffDataTable.Columns.Add("NRC No", typeof(string));
            staffDataTable.Columns.Add("Gender", typeof(string));
            staffDataTable.Columns.Add("Age", typeof(int));
            staffDataTable.Columns.Add("Phone No1", typeof(string));
            staffDataTable.Columns.Add("Phone No2", typeof(string));
            staffDataTable.Columns.Add("Address", typeof(string));

            CreateTwoColumn();

        }

        private void CreateTwoColumn()
        {
            DataGridViewTextBoxColumn staffNoColumn = new DataGridViewTextBoxColumn();
            staffNoColumn.HeaderText = "Staff No.";
            staffNoColumn.DataPropertyName = "Staff No.";
            dgvStaffInformation.Columns.Add(staffNoColumn);
            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.HeaderText = "Image";
            imgColumn.DataPropertyName = "Image";
            imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvStaffInformation.Columns.Add(imgColumn);
            dgvStaffInformation.DataSource = staffDataTable;
        }

        private void cellClick_editInfo(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Text = "Update";
            btnDelete.Enabled = true;
            int staffId = 0;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvStaffInformation.Rows[e.RowIndex];
                if (selectedRow.Cells.Count > 0)
                {
                    var firstCellValue = selectedRow.Cells[0].Value;
                    staffId = Convert.ToInt32(firstCellValue);
                    string query = "SELECT * FROM StaffInformation WHERE Id=" + staffId;
                    SqlDataReader reader = DB.readDatathroughReader(query); // Assuming the method accepts a parameter
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            txtStaffNo.Text = reader.GetInt32(0).ToString();
                            if (!reader.IsDBNull(1))
                            {
                                imagePath = reader.GetString(1);
                                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                                {
                                    pbStaffPhoto.Image = new Bitmap(imagePath);
                                }
                                else
                                {
                                    pbStaffPhoto.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Images", "noImage.png"));
                                }
                            }
                            else
                            {
                                pbStaffPhoto.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Images", "noImage.png"));
                            }

                            txtStaffName.Text = reader.GetString(2);
                            dJoinDate.Value = reader.GetDateTime(3);
                            cbStaffType.Text = reader.GetString(4);
                            txtNrcNo.Text = reader.GetString(5);
                            dBirthDate.Value = reader.GetDateTime(10);
                            string gender = reader.GetString(6);
                            switch (gender)
                            {
                                case "Male":
                                    rdMale.Checked = true;
                                    break;
                                case "Female":
                                    rdfemale.Checked = true;
                                    break;
                                case "Other":
                                    rdOther.Checked = true;
                                    break;
                                default:
                                    rdMale.Checked = false;
                                    rdfemale.Checked = false;
                                    rdOther.Checked = false;
                                    break;
                            }
                            txtPhoneNo1.Text = reader.GetString(7);
                            txtPhoneNo2.Text = reader.GetString(8);
                            rtxtAddress.Text = reader.GetString(9);
                        }
                    }
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Click cell");
                }
            }
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


            if (int.Parse(txtAge.Text) < 18)
            {
                errorProviderCommon.SetError(dBirthDate, "Age is too young!.");
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

            if (rdMale.Checked == false && rdfemale.Checked == false && rdOther.Checked == false)
            {
                errorProviderCommon.SetError(rdfemale, "You need to choose your gender");
            }
            else
            {
                errorProviderCommon.SetError(rdfemale, "");
            }

            string numericPattern = @"^(?:[0-9]{1,9}|[၀-၉]{1,9})$";

            if (Regex.IsMatch(txtPhoneNo1.Text, numericPattern) && txtPhoneNo1.Text.Length >= 5)
            {
                errorProviderCommon.SetError(txtPhoneNo1, "");
            }
            else
            {
                errorProviderCommon.SetError(txtPhoneNo1, "Invalid phone number format. Please enter a numeric value.");
            }

            if (txtPhoneNo2.Text.Length > 0)
            {
                if (Regex.IsMatch(txtPhoneNo1.Text, numericPattern) && txtPhoneNo1.Text.Length >= 5)
                {
                    errorProviderCommon.SetError(txtPhoneNo2, "");
                }
                else
                {
                    errorProviderCommon.SetError(txtPhoneNo2, "Invalid phone number format. Please enter a numeric value.");
                }
            }
           
            bool errorsPresent = errorProviderCommon.ContainerControl.Controls
                .OfType<Control>()
                .Any(control => !string.IsNullOrEmpty(errorProviderCommon.GetError(control)));


            if (!errorsPresent)
            {
                if (dgvStaffInformation.SelectedCells.Count > 0&& btnAdd.Text=="Update")
                {
                    try
                    {
                        int staffId = 0;
                        var firstCellValue = txtStaffNo.Text.ToString();
                        staffId = Convert.ToInt32(firstCellValue);
                        SqlCommand updateCommand = new SqlCommand("UPDATE StaffInformation SET Image=@Image, Name=@Name, JoinFrom=@JoinFrom, StaffType=@StaffType, NrcNo=@NrcNo, Gender=@Gender, BirthDate=@BirthDate, PhoneNo1=@PhoneNo1, PhoneNo2=@PhoneNo2, Address=@Address WHERE Id=" + staffId);

                        // Bind parameters
                        updateCommand.Parameters.AddWithValue("@Image", imagePath);
                        updateCommand.Parameters.AddWithValue("@Name", txtStaffName.Text);
                        updateCommand.Parameters.AddWithValue("@JoinFrom", dJoinDate.Value.Date);
                        updateCommand.Parameters.AddWithValue("@StaffType", cbStaffType.SelectedItem.ToString());
                        updateCommand.Parameters.AddWithValue("@NrcNo", txtNrcNo.Text);
                        updateCommand.Parameters.AddWithValue("@Gender", GetGender().ToString());
                        updateCommand.Parameters.AddWithValue("@BirthDate", dBirthDate.Value.Date);
                        updateCommand.Parameters.AddWithValue("@PhoneNo1", txtPhoneNo1.Text);
                        updateCommand.Parameters.AddWithValue("@PhoneNo2", txtPhoneNo2.Text);
                        updateCommand.Parameters.AddWithValue("@Address", rtxtAddress.Text);
                        updateCommand.Parameters.AddWithValue("@StaffId", txtStaffNo.Text);
                        int result = DB.executeQuery(updateCommand);
                        if (result == 1)
                        {
                            btnAdd.Text = "Add";
                            btnDelete.Enabled = false;
                            foreach (DataGridViewRow row in dgvStaffInformation.Rows)
                            {
                                if (row.Cells[0].Value != null && (Convert.ToInt32(row.Cells[0].Value) == staffId))
                                {
                                    row.Cells[0].Value = staffId;
                                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                                    {
                                        imageData = File.ReadAllBytes(imagePath);
                                        row.Cells[1].Value = imageData;
                                    }
                                    else
                                    {
                                        row.Cells[1].Value = noImage;
                                    }
                                    row.Cells["Staff Name"].Value = txtStaffName.Text;
                                    row.Cells["Gender"].Value = GetGender();
                                    row.Cells["Age"].Value = txtAge.Text;
                                    row.Cells["Join From"].Value = dJoinDate.Value.Date;
                                    row.Cells["Staff Type"].Value = cbStaffType.SelectedItem.ToString();
                                    row.Cells["NRC No"].Value = txtNrcNo.Text;
                                    row.Cells["Phone No1"].Value = txtPhoneNo1.Text;
                                    row.Cells["Phone No2"].Value = txtPhoneNo2.Text;
                                    row.Cells["Address"].Value = rtxtAddress.Text;
                                    MessageBox.Show("Updating Staff Success");
                                    dgvStaffInformation.Rows[0].Selected = false;
                                    clear();
                                }
                            }
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Failed to Update Staff");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex);
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
                            int rowId = Convert.ToInt32(row["Staff No."]);
                            if (rowId >= id)
                            {
                                id = rowId + 1;
                            }
                        }
                    }
                    newRow["Staff No."] = id;
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        imageData = File.ReadAllBytes(imagePath);
                        newRow["Image"] = imageData;
                    }
                    else
                    {
                        newRow["Image"] = noImage;
                    }
                    newRow["Staff Name"] = txtStaffName.Text;
                    newRow["Gender"] = GetGender();
                    newRow["Age"] = txtAge.Text;
                    newRow["Join From"] = dJoinDate.Value.Date;
                    newRow["Staff Type"] = cbStaffType.SelectedItem.ToString();
                    newRow["NRC No"] = txtNrcNo.Text;
                    newRow["Phone No1"] = txtPhoneNo1.Text;
                    newRow["Phone No2"] = txtPhoneNo2.Text;
                    newRow["Address"] = rtxtAddress.Text;
                    staffDataTable.Rows.Add(newRow);
                    dgvStaffInformation.DataSource = staffDataTable;

                    SqlCommand insertCommand = new SqlCommand("INSERT INTO StaffInformation (Image,Name,JoinFrom,StaffType,NrcNo,Gender,BirthDate,PhoneNo1,PhoneNo2,Address) VALUES (@Image,@Name,@JoinFrom,@StaffType,@NrcNo,@Gender,@BirthDate,@PhoneNo1,@PhoneNo2,@Address)");
                    insertCommand.Parameters.AddWithValue("@Name", txtStaffName.Text);
                    insertCommand.Parameters.AddWithValue("@Image", imagePath);
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
                        currentPage = countPage;
                        LoadData();
                        btnPrevious.Enabled = true;
                        btnNext.Enabled = false;
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

        private void clickChooseFile(object sender, EventArgs e)
        {
            OpenFileDialog uploadImage = new OpenFileDialog();
            uploadImage.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;*.png;)|*.jpg;*.jpeg;.*.gif;*.png";
            if (uploadImage.ShowDialog() == DialogResult.OK)
            {
                imagePath = uploadImage.FileName;
                pbStaffPhoto.Image = new Bitmap(uploadImage.FileName);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            imagePath = "";
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
            btnAdd.Text = "Add";
            btnDelete.Enabled = false;
            dgvStaffInformation.Rows[0].Selected = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int staffId = 0;
            if (dgvStaffInformation.SelectedRows.Count > 0)
            {
                staffId = Convert.ToInt32(txtStaffNo.Text);
                SqlCommand query = new SqlCommand("DELETE FROM StaffInformation WHERE Id=" + staffId);
                int result = DB.executeQuery(query);
                if (result > 0)
                {
                    dgvStaffInformation.Rows.Remove(dgvStaffInformation.SelectedRows[0]);
                    MessageBox.Show("Deleted Successful");
                    clear();
                    dgvStaffInformation.Rows[0].Selected = false;
                    btnAdd.Text = "Add";
                    btnDelete.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Something Wrong!");
            }
        }

        private void first_load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            txtStaffName.Focus();
            btnDelete.Enabled = false;

            string countQuery = "SELECT COUNT(*) FROM StaffInformation;";
            totalRecords = Convert.ToInt32(DB.ExecuteScalar(countQuery));
            countPage = (int)Math.Ceiling((double)totalRecords / pageSize);
            txtPagination.Text = $"{currentPage}/{countPage}";

            int offset = (currentPage - 1) * pageSize;

            string query = $"SELECT * FROM StaffInformation ORDER BY [Id] OFFSET {offset} ROWS FETCH NEXT {pageSize} ROWS ONLY;";
            SqlDataReader reader = DB.readDatathroughReader(query);

            if (reader.HasRows)
            {
                staffDataTable.Clear(); // Clear existing data
                while (reader.Read())
                {
                    DataRow newRow = staffDataTable.NewRow();
                    newRow["Staff No."] = reader.GetInt32(0);
                    imagePath = reader.GetString(1);
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        imageData = File.ReadAllBytes(imagePath);
                        newRow["Image"] = imageData;
                    }
                    else
                    {
                        newRow["Image"] = noImage;
                    }
                    newRow["Staff Name"] = reader.GetString(2);
                    newRow["Join From"] = reader.GetDateTime(3).Date;
                    newRow["Staff Type"] = reader.GetString(4);
                    newRow["NRC No"] = reader.GetString(5);
                    newRow["Gender"] = reader.GetString(6);
                    newRow["Age"] = (DateTime.Today.Year - reader.GetDateTime(10).Year).ToString();
                    newRow["Phone No1"] = reader.GetInt32(7);
                    newRow["Phone No2"] = reader.GetInt32(8);
                    newRow["Address"] = reader.GetString(9);
                    staffDataTable.Rows.Add(newRow);
                    imageData = new byte[0];
                    clear();
                }
                dgvStaffInformation.Rows[0].Selected = false;
            }
            reader.Close();
        }


        private void StaffForm_click(object sender, EventArgs e)
        {
            txtStaffName.Focus();
            dgvStaffInformation.Rows[0].Selected = false;
            btnAdd.Text = "Add";
            btnDelete.Enabled = false;
            clear();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadData();
            if (currentPage == countPage)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }
            btnPrevious.Enabled = true;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
                btnNext.Enabled = true;
            }
            else
            {
                btnPrevious.Enabled = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData();
            btnPrevious.Enabled = false;
            btnNext.Enabled = true;
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            currentPage = countPage;
            LoadData();
            btnPrevious.Enabled = true;
            btnNext.Enabled = false;
        }
        
    }
}
