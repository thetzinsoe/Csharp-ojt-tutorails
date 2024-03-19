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
using Tutorial04;

namespace Tutorial03
{
    public partial class StaffInformation : Form
    {
        EncryptionHelper EncryptionHelper = new EncryptionHelper();
        private readonly DataTable staffDataTable = new DataTable();
        DBAccess DB = new DBAccess();
        DataTable userTable = new DataTable();
        string imagePath = "";
        byte[] imageData = new byte[0];
        byte[] noImage = File.ReadAllBytes(Environment.CurrentDirectory + "\\Images\\noImage.png");

        public StaffInformation(string username)
        {
            InitializeComponent();
            txtStaffName.Focus();
            dBirthDate.MaxDate = DateTime.Now;
            dBirthDate.Format = DateTimePickerFormat.Custom;
            dBirthDate.CustomFormat = "0 / 00 / 0000";
            txtAge.Text = "";
            dJoinDate.Value = dJoinDate.MinDate;
            dJoinDate.MaxDate = DateTime.Now;
            dJoinDate.Format = DateTimePickerFormat.Custom;
            dJoinDate.CustomFormat = "0 / 00 / 0000";
            loadData(username);
        }

        private void loadData(string username)
        {
            string query = "SELECT * FROM Tuto07 WHERE Name='" + username + "'";
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
                    txtPhoneNo1.Text = reader.GetInt32(7).ToString();
                    txtPhoneNo2.Text = reader.GetInt32(8).ToString();
                    rtxtAddress.Text = reader.GetString(9);
                    string ePass = reader.GetString(11);
                    string pPass = EncryptionHelper.Decrypt(ePass);
                    txtPassword.Text = pPass;
                    txtConfirmPassword.Text = pPass;
                }
            }
            else
            {
                MessageBox.Show("Something Wrong!");
            }
            reader.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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

            string numericPattern = @"^\d+$";
            if (Regex.IsMatch(txtPhoneNo1.Text, numericPattern) && txtPhoneNo1.Text.Length >= 5)
            {
                errorProviderCommon.SetError(txtPhoneNo1, "");
            }
            else
            {
                errorProviderCommon.SetError(txtPhoneNo1, "Invalid phone number format. Please enter a numeric value.");
            }

            bool errorsPresent = errorProviderCommon.ContainerControl.Controls
                .OfType<Control>()
                .Any(control => !string.IsNullOrEmpty(errorProviderCommon.GetError(control)));


            if (!errorsPresent)
            {
                try
                {
                    int staffId = 0;
                    var firstCellValue = txtStaffNo.Text;
                    staffId = Convert.ToInt32(firstCellValue);
                    string pPass = EncryptionHelper.Encrypt(txtPassword.Text.ToString());
                    SqlCommand updateCommand = new SqlCommand("UPDATE Tuto07 SET Image=@Image, Name=@Name, JoinFrom=@JoinFrom, StaffType=@StaffType, NrcNo=@NrcNo, Gender=@Gender, BirthDate=@BirthDate, PhoneNo1=@PhoneNo1, PhoneNo2=@PhoneNo2, Address=@Address,Password=@Password WHERE Id=" + staffId);

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
                    updateCommand.Parameters.AddWithValue("@Password", pPass);
                    int result = DB.executeQuery(updateCommand);
                    if (result == 1)
                    {
                        this.Hide();
                        StaffList sl = new StaffList();
                        sl.Show();
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
                MessageBox.Show("Someting Wrong", "Error!");
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
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void btnGtSt_Click(object sender, EventArgs e)
        {
            this.Hide();
            StaffList sl = new StaffList();
            sl.Show();
        }
    }
}
 
