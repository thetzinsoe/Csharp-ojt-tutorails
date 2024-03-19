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
using Tutorial03;
using Tutorial4;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Tutorial04
{
    public partial class Login : Form
    {
        DBAccess DB = new DBAccess();
        DataTable userTable = new DataTable();
        EncryptionHelper EncryptionHelper = new EncryptionHelper();
        string username="";
       
        public Login()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register re = new Register();
            re.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            username = txtUsername.Text;
            string password = txtPassword.Text;
            bool LoginAuth = false;
            string query = "SELECT * FROM Tuto07 WHERE Name='" + username + "'";
            DB.readDatathroughAdapter(query, userTable);
            if (userTable.Rows.Count > 0)
            {
                foreach (DataRow row in userTable.Rows)
                {
                    string dbPass = (string)(row["Password"]);
                    string dcPass = EncryptionHelper.Decrypt(dbPass);
                    if (dcPass == txtPassword.Text)
                    {
                        errorProviderLg.SetError(txtPassword, "");
                        LoginAuth = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Password!", "Try Again");
                        errorProviderLg.SetError(txtPassword, "Worng Password");
                        LoginAuth = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("User Not Found!", "Error!");
            }
            if (LoginAuth)
            {
                this.Hide();
                StaffInformation staffInformation = new StaffInformation(username);
                staffInformation.Show();
            }
        }
    }
}
