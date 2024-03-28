using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Common;
using System.Windows.Forms;
using Shop.App.Views.Shop;

namespace Shop.App.Views.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            LoginInfo loginInfo = new LoginInfo();
            loginInfo.id=int.Parse(txtPassword.Text);
            this.Hide();
            ShopList sl = new ShopList();
            sl.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
