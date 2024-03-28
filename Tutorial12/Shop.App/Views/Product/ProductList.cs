using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO.Common;
using Shop.App.Views.Login;

namespace Shop.App.Views.Product
{
    public partial class ProductList : Form
    {
        LoginInfo loginInfo = new LoginInfo();
        public ProductList()
        {
            InitializeComponent();
        }

        private void ProductList_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = loginInfo.id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginInfo.id = 0;
            this.Hide();
        }
    }
}
