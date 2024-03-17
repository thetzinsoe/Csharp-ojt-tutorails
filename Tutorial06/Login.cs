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
using Tutorial4;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Tutorial04
{
    public partial class Login : Form
    {
        DBAccess DB = new DBAccess();
        DataTable userTable = new DataTable();
       EncryptionHelper EncryptionHelper = new EncryptionHelper();
        public static string name, pass;
       
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
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string dpassword = EncryptionHelper.Decrypt(password);
            string query = "SELECT * FROM UserTable Where Name='" + username + "' and Password='"+dpassword+"' ";
            DB.readDatathroughAdapter(query, userTable);

            foreach(DataRow row in userTable.Rows)
            {
                MessageBox.Show(row[0] + ""+ row[1] + "" + row[2]);
                return;
            }
            if (userTable.Rows.Count > 0)
            {
                name = userTable.Rows[0]["Name"].ToString();
                pass = userTable.Rows[0]["Pass"].ToString();
               
                MessageBox.Show("Name is : " + name + "\nPassword is : " + pass );
              
            }
            else
            {
                MessageBox.Show("Login Fail");
            }
        }
    }
}
