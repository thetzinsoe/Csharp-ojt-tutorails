using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Entities.Staff;
using Services.Staff;
using Services.PassEncrypt;
using System.IO;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Tuto11.App.Views
{
    public partial class Register : Form
    {
        public string ID
        { set { txtStaffNo.Text = value; } }
        EncryptionHelper EncryptionHelper = new EncryptionHelper();
        StaffService staffService = new StaffService();
        StaffList stafflist = new StaffList();
        string username = "";
        string imagePath = "";
        byte[] imageData = new byte[0];
        byte[] noImage = File.ReadAllBytes(Environment.CurrentDirectory + "\\Images\\noImage.png");



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

        public Register(DataTable data)
        {
            InitializeComponent();
            txtStaffName.Select();
            btnRegister.Text = "Update";
            lbRegister.Text = "Update";
            dBirthDate.MaxDate = DateTime.Now;
            dBirthDate.Format = DateTimePickerFormat.Custom;
            dBirthDate.CustomFormat = "0 / 00 / 0000";
            txtAge.Text = "0";
            dJoinDate.Value = dJoinDate.MinDate;
            dJoinDate.MaxDate = DateTime.Now;
            dJoinDate.Format = DateTimePickerFormat.Custom;
            dJoinDate.CustomFormat = "0 / 00 / 0000";
            LoadDataToUpdate(data);
        }

        public void LoadDataToUpdate(DataTable data)
        {
            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0]; // Assuming you're only loading data for one staff member

                txtStaffNo.Text = row["Id"].ToString(); // Assuming "Id" is a column name in your DataTable

                // Handle image loading
                if (!string.IsNullOrEmpty(row["Image"].ToString()))
                {
                    imagePath = row["Image"].ToString();
                    if (File.Exists(imagePath))
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

                txtStaffName.Text = row["Name"].ToString();
                dJoinDate.Value = Convert.ToDateTime(row["JoinFrom"]);
                cbStaffType.Text = row["StaffType"].ToString();
                txtNrcNo.Text = row["NrcNo"].ToString();
                dBirthDate.Value = Convert.ToDateTime(row["BirthDate"]);
                txtAge.Text = (DateTime.Today.Year - Convert.ToDateTime(row["BirthDate"]).Year).ToString();

                // Handle gender
                string gender = row["Gender"].ToString().ToLower();
                switch (gender)
                {
                    case "male":
                        rdMale.Checked = true;
                        break;
                    case "female":
                        rdfemale.Checked = true;
                        break;
                    case "other":
                        rdOther.Checked = true;
                        break;
                    default:
                        rdMale.Checked = false;
                        rdfemale.Checked = false;
                        rdOther.Checked = false;
                        break;
                }

                txtPhoneNo1.Text = row["PhoneNo1"].ToString();
                txtPhoneNo2.Text = row["PhoneNo2"].ToString();
                rtxtAddress.Text = row["Address"].ToString();

                // Decrypt password assuming you have a method named Decrypt in your EncryptionHelper
                string ePass = row["Password"].ToString();
                string pPass = EncryptionHelper.Decrypt(ePass);
                txtPassword.Text = pPass;
                txtConfirmPassword.Text = pPass;
            }
        }


        private void btnRegister_Click(object sender, EventArgs e)
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


            bool errorsPresent = errorProviderCommon.ContainerControl.Controls
              .OfType<Control>()
              .Any(control => !string.IsNullOrEmpty(errorProviderCommon.GetError(control)));

            if (!errorsPresent)
            {
                AddorUpdate();
            }
        }

        private void AddorUpdate()
        {
            StaffService staffService = new StaffService();
            StaffEntity staffEntity = CreateData();
            bool success = false;

            if (String.IsNullOrEmpty(txtStaffNo.Text))
            {
                success = staffService.Insert(staffEntity);
                if (success)
                {
                    MessageBox.Show("Save Success.", "Success", MessageBoxButtons.OK);
                    this.Hide();
                    stafflist.Show();
                }
            }
            else
            {
                success = staffService.Update(staffEntity);
                if (success)
                {
                    MessageBox.Show("Update Success.", "Success", MessageBoxButtons.OK);
                    this.Hide();
                    stafflist.Show();
                }
            }
        }

        private StaffEntity CreateData()
        {
            
                StaffEntity staffEntity = new StaffEntity(); ;
                if (!String.IsNullOrEmpty(txtStaffNo.Text))
                {
                    staffEntity.staffId = Convert.ToInt32(txtStaffNo.Text);
                }
                string pPass = txtPassword.Text.ToString();
                string pass = EncryptionHelper.Encrypt(pPass);
                staffEntity.name = txtStaffName.Text;
                staffEntity.image = imagePath;
                staffEntity.joinDate = dBirthDate.Value.Date;
                staffEntity.staffType = cbStaffType.SelectedItem.ToString();
                staffEntity.nrcNo = txtNrcNo.Text;
                staffEntity.gender = GetGender().ToString();
                staffEntity.birthDate = dBirthDate.Value.Date;
                staffEntity.phoneNo1 = txtPhoneNo1.Text;
                staffEntity.phoneNo2 = txtPhoneNo2.Text;
                staffEntity.address = rtxtAddress.Text;
                staffEntity.password = pass;
                return staffEntity;
          
        }

        private string GetGender()
        {
            return rdMale.Checked ? "Male" : (rdfemale.Checked ? "Female" : (rdOther.Checked ? "Other" : ""));
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

        private void btnChooseFile_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog uploadImage = new OpenFileDialog();
            uploadImage.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;*.png;)|*.jpg;*.jpeg;.*.gif;*.png";
            if (uploadImage.ShowDialog() == DialogResult.OK)
            {
                imagePath = uploadImage.FileName;
                pbStaffPhoto.Image = new Bitmap(uploadImage.FileName);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            clear();
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

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }
    }
}
