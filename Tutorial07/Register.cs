using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial04;
using System.Windows.Forms;
using Tutorial4;
using System.Security.Cryptography;
using Tutorial03;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Tutorial04
{
    public partial class Register : Form
    {
        string username = "";
        string imagePath = "";
        byte[] imageData = new byte[0];
        byte[] noImage = File.ReadAllBytes(Environment.CurrentDirectory + "\\Images\\noImage.png");
        DBAccess DB = new DBAccess();
        EncryptionHelper EncryptionHelper = new EncryptionHelper();
        private const string EncryptionKey = "YourEncryptionKey"; // Change this key to your own secure key

        public Register()
        {
            InitializeComponent();
            txtStaffName.Focus();
            dBirthDate.MaxDate = DateTime.Now;
            dBirthDate.Format = DateTimePickerFormat.Custom;
            dBirthDate.CustomFormat = "0 / 00 / 0000";
            txtAge.Text = "0";
            dJoinDate.Value = dJoinDate.MinDate;
            dJoinDate.MaxDate = DateTime.Now;
            dJoinDate.Format = DateTimePickerFormat.Custom;
            dJoinDate.CustomFormat = "0 / 00 / 0000";
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
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
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
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

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errorProviderCommon.SetError(txtConfirmPassword, "Password Wrong");
            }
            else
            {
                errorProviderCommon.SetError(txtConfirmPassword, "");
            }

            if (txtPassword.Text == "" || txtPassword.Text.Length <= 5)
            {
                errorProviderCommon.SetError(txtPassword, "Invalid staff name.");
            }
            else
            {
                errorProviderCommon.SetError(txtPassword, "");
            }

            DataTable userTable = new DataTable();
            username = txtStaffName.Text;
            string findUser = "SELECT * FROM Tuto07 WHERE Name='" + username + "'";
            DB.readDatathroughAdapter(findUser, userTable);

            if (userTable.Rows.Count > 0)
            {
                foreach (DataRow row in userTable.Rows)
                {
                    if (row["Name"].ToString() == username)
                    {
                        //MessageBox.Show("Name already exists: " + row["Name"]);
                        errorProviderCommon.SetError(txtStaffName, "This Name is already created!");
                        return;
                    }
                }
            }
            else
            {
                // MessageBox.Show("No matching records found.");
                errorProviderCommon.SetError(txtStaffName, "");
            }


            bool errorsPresent = errorProviderCommon.ContainerControl.Controls
                .OfType<Control>()
                .Any(control => !string.IsNullOrEmpty(errorProviderCommon.GetError(control)));


            if (!errorsPresent)
            {
                string pPass = txtPassword.Text.ToString();
                string pass = EncryptionHelper.Encrypt(pPass);
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Tuto07 (Image,Name,JoinFrom,StaffType,NrcNo,Gender,BirthDate,PhoneNo1,PhoneNo2,Address,Password) VALUES (@Image,@Name,@JoinFrom,@StaffType,@NrcNo,@Gender,@BirthDate,@PhoneNo1,@PhoneNo2,@Address,@Password)");
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
                insertCommand.Parameters.AddWithValue("@Password", pass);
                int result = DB.executeQuery(insertCommand);
                if (result == 1)
                {
                    MessageBox.Show("Register Success");
                    clear();
                    this.Hide();
                    StaffInformation staffInformation = new StaffInformation(username);
                    staffInformation.Show();
                }
                else
                {
                    MessageBox.Show("Fail");
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dJoinFrom_valueChange(object sender, EventArgs e)
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

        private void dBirthDate_valueChange(object sender, EventArgs e)
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

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog uploadImage = new OpenFileDialog();
            uploadImage.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;*.png;)|*.jpg;*.jpeg;.*.gif;*.png";
            if (uploadImage.ShowDialog() == DialogResult.OK)
            {
                imagePath = uploadImage.FileName;
                pbStaffPhoto.Image = new Bitmap(uploadImage.FileName);
            }
        }
    }
}
   