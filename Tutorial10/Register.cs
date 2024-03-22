using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Tutorial09_linq_
{
    public partial class Register : Form
    {
        string username = "";
        string imagePath = "";
        byte[] imageData = new byte[0];
        byte[] noImage = File.ReadAllBytes(Environment.CurrentDirectory + "\\Images\\noImage.png");
        EncryptionHelper EncryptionHelper = new EncryptionHelper();
        private const string EncryptionKey = "YourEncryptionKey"; // Change this key to your own secure key
        StaffDataDataContext DB = new StaffDataDataContext();
        public Register()
        {
            InitializeComponent();
            txtStaffName.Select();
            dBirthDate.MaxDate = DateTime.Now;
            dBirthDate.Format = DateTimePickerFormat.Custom;
            dBirthDate.CustomFormat = "0 / 00 / 0000";
            txtAge.Text = "0";
            dJoinDate.Value = dJoinDate.MinDate;
            dJoinDate.MaxDate = DateTime.Now;
            dJoinDate.Format = DateTimePickerFormat.Custom;
            dJoinDate.CustomFormat = "0 / 00 / 0000";
        }

        public Register(Tuto10 data)
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

        public void LoadDataToUpdate(Tuto10 data)
        {

            txtStaffNo.Text = data.Id.ToString();
            if (!string.IsNullOrEmpty(data.Image))
            {
                imagePath = data.Image;
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

            txtStaffName.Text = data.Name;
            dJoinDate.Value = data.JoinFrom.Date;
            cbStaffType.Text = data.StaffType;
            txtNrcNo.Text = data.NrcNo;
            dBirthDate.Value = data.BirthDate.Date;
            txtAge.Text = (DateTime.Today.Year - data.BirthDate.Date.Year).ToString();
            string gender = data.Gender;
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
            txtPhoneNo1.Text = data.PhoneNo1.ToString();
            txtPhoneNo2.Text = data.PhoneNo2.ToString();
            rtxtAddress.Text = data.Address;
            string ePass = data.Password;
            string pPass = EncryptionHelper.Decrypt(ePass);
            txtPassword.Text = pPass;
            txtConfirmPassword.Text = pPass;
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

            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                errorProviderCommon.SetError(txtEmail, "Email address is required.");
            }
            else if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errorProviderCommon.SetError(txtEmail, "Invalid email address.");
            }
            else
            {
                errorProviderCommon.SetError(txtEmail, "");
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
                string  staffName = txtStaffName.Text.ToString();
                string  staffEmail = txtEmail.Text.ToString();
                string image = imagePath;
                DateTime joinFrom = dJoinDate.Value.Date;
                DateTime birthDate = dBirthDate.Value.Date;
                string staffType = cbStaffType.Text;
                string nrcNo = txtNrcNo.Text;
                string gender = GetGender();
                int phoneNo1 = int.Parse(txtPhoneNo1.Text);
                int phoneNo2 = 0;
                if (!string.IsNullOrWhiteSpace(txtPhoneNo2.Text))
                {
                     phoneNo2 = int.Parse(txtPhoneNo2.Text);
                }
                string adderss = rtxtAddress.Text;
                string password = EncryptionHelper.Encrypt(txtPassword.Text);
                if (btnRegister.Text == "Register")
                {
                    try
                    {
                        var st = new Tuto10
                        {
                            Image = image,
                            Email = staffEmail,
                            Name = staffName,
                            JoinFrom = joinFrom,
                            BirthDate = birthDate,
                            StaffType = staffType,
                            NrcNo = nrcNo,
                            Gender = gender,
                            PhoneNo1 = phoneNo1,
                            PhoneNo2 = phoneNo2,
                            Password = password,
                        };
                        DB.Tuto10s.InsertOnSubmit(st);
                        DB.SubmitChanges();
                        MessageBox.Show("Staff Adding successful");
                        clear();
                        this.Hide();
                        StaffList staff = new StaffList();
                        staff.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
                else
                {
                    int staffId = Convert.ToInt32(txtStaffNo.Text);
                    var dt = (from s in DB.Tuto10s
                              where s.Id == staffId
                              select s).First();
                    dt.Image = image;
                    dt.Name = staffName;
                    dt.Email = staffEmail;
                    dt.JoinFrom = joinFrom;
                    dt.BirthDate = birthDate;
                    dt.StaffType = staffType;
                    dt.NrcNo = nrcNo;
                    dt.Gender = gender;
                    dt.PhoneNo1 = phoneNo1;
                    dt.PhoneNo2 = phoneNo2;
                    dt.Password = password;
                    try
                    {
                        DB.SubmitChanges();
                        MessageBox.Show("Staff Update successful");
                        clear();
                        this.Hide();
                        StaffList staff = new StaffList();
                        staff.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating staff: " + ex.Message);
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

        private void label15_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnRegister.Text == "Register")
            {
                Close();
            }
            else
            {
                this.Hide();
                StaffList st = new StaffList();
                st.Show();
            }
           
        }
    }
}
