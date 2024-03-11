using System;

class Program
{
    public static void Main(string[] Args)
    {
        Console.WriteLine("*** Loan Calculation ***");
        decimal loanAmount = GetValidNumber("Loan Amount");
        decimal interestRate = GetValidInterestRate();
        decimal duration = GetValidLoanDuration();
        decimal result = Convert.ToDecimal(string.Format("{0:0.00}", (loanAmount * interestRate / 100) * (duration / 12)));
        Console.WriteLine("Interest Amount : " + result);
        Console.WriteLine("Total Amount : " + (result + loanAmount));
    }

    static decimal GetValidNumber(string fieldName)
    {
        string input;
        decimal result;
        do
        {
            Console.Write($"Enter {fieldName}: ");
            input = Console.ReadLine();
        } while (!decimal.TryParse(input, out result) || result <= 0);
        return result;
    }

    static decimal GetValidInterestRate()
    {
        decimal result;
        do
        {
            result = GetValidNumber("Interest Rate(%)");
        } while (result < 1 || result > 100);
        return result;
    }

    static decimal GetValidLoanDuration()
    {
        decimal result;
        do
        {
            result = GetValidNumber("Loan Duration(Months)");
        } while (result < 1 || result > 12);
        return result;
    }
}
