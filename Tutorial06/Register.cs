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

namespace Tutorial04
{
    public partial class Register : Form
    {
        DBAccess DB = new DBAccess();
        EncryptionHelper EncryptionHelper = new EncryptionHelper();
        private const string EncryptionKey = "YourEncryptionKey"; // Change this key to your own secure key

        public Register()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string cfPassword = txtConfirmPassword.Text;
            if (username == null || username.Length < 4)
            {
                errorProviderRe.SetError(txtUsername, "Name require!");
            }
            else
            {
                errorProviderRe.SetError(txtUsername, "");
            }


            if (cfPassword != password)
            {
                errorProviderRe.SetError(txtPassword, "Passwords are not match!");
                errorProviderRe.SetError(txtConfirmPassword, "Passwords are not match!");
            }
            else
            {
                if (cfPassword.Length >= 6)
                {
                    errorProviderRe.SetError(txtPassword, "");
                    errorProviderRe.SetError(txtConfirmPassword, "");
                }
                else
                {
                    errorProviderRe.SetError(txtPassword, "Password too short!");
                    errorProviderRe.SetError(txtConfirmPassword, "Password too short!");
                }
            }
            bool errorsPresent = errorProviderRe.ContainerControl.Controls
            .OfType<Control>()
            .Any(control => !string.IsNullOrEmpty(errorProviderRe.GetError(control)));

            if (!errorsPresent)
            {
                string data = EncryptionHelper.Encrypt(password);
                SqlCommand insertCommand = new SqlCommand("INSERT INTO UserTable (Name,Password) VALUES (@Name,@Password)");
                insertCommand.Parameters.AddWithValue("@Name", txtUsername.Text);
                insertCommand.Parameters.AddWithValue("@Password", data);
                int result = DB.executeQuery(insertCommand);
                if (result == 1)
                {
                    MessageBox.Show("Adding User Success");
                    this.Hide();
                    StaffInformation staffInformation = new StaffInformation();
                    staffInformation.Show();
                }
                else
                {
                    MessageBox.Show("Fail");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Error occour", "Error!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }
    }
}
   