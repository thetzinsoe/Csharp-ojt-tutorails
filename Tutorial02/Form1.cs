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
            decimal result = Convert.ToDecimal(string.Format("{0:0.00}", (loanAmount * interestRate / 100) * (duration / 12)));
            txtInterest.Text = result.ToString();
            txtTotal.Text = (result + loanAmount).ToString();
        }
    }
}
