using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tutorial09_linq_
{
    public partial class Login : Form
    {
        EncryptionHelper EncryptionHelper = new EncryptionHelper();
        StaffDataDataContext DB = new StaffDataDataContext();
        public Login()
        {
            InitializeComponent();
            txtStaffName.Select();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register re = new Register();
            re.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        public void login()
        {
            string staffName = txtStaffName.Text.Trim().ToLower();
            var staff = DB.Tuto07s.FirstOrDefault(s => s.Name.ToLower() == staffName);
            if (staff != null)
            {

                string password = staff.Password;
                string pass = EncryptionHelper.Decrypt(password);
                if (txtPassword.Text.ToString() == pass)
                {
                    this.Hide();
                    StaffList st = new StaffList();
                    st.Show();
                }
                else
                {
                    MessageBox.Show("Wrong password!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Staff name does not exist in the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStaffName.Text = "";
            txtPassword.Text= "";
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
    }
}
