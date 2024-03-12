namespace Tutorial02_Loan_Window_Form_App__Thetzinsoe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal loanAmount = numUpLoan.Value;
            decimal interestRate = numUpInterest.Value;
            decimal duration = numUpDuration.Value;
            if (loanAmount == 0 || loanAmount==null)
            {
                MessageBox.Show(" Please fill correct Loan Amount!","Invalid!");
                return;
            }else if (interestRate <= 0 ||interestRate==null )
            {
                MessageBox.Show(" Please fill correct Interest Rate!", "Invalid!");
                return;
            }
            else if(duration <= 0|| duration==null)
            {
                MessageBox.Show(" Please fill correct Duration!", "Invalid!");
                return; 
            }
            decimal result = Convert.ToDecimal(string.Format("{0:0.00}", (loanAmount * interestRate / 100) * duration));
            txtInterest.Text = result.ToString();
            txtTotal.Text = (result + loanAmount).ToString();
        }
    }
}
