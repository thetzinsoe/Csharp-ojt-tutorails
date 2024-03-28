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
using Shop.App.Views.Product;

namespace Shop.App.Views.Shop
{
    public partial class ShopList : Form
    {
        LoginInfo lg = new LoginInfo();
        public ShopList()
        {
            InitializeComponent();
        }

        private void ShopList_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = lg.id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lg.id.ToString() + "");
            this.Hide();
            ProductList productList = new ProductList();
            productList.Show();
        }
    }
}
