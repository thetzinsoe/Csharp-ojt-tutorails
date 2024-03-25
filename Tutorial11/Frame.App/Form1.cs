using Services.Test;
using Frame.App;
namespace Frame.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void rtxtTest_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtxtTest.Text = "";
        }
    }
}
