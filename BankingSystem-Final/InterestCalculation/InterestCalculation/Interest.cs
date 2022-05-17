namespace InterestCalculation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // class to calculate Interest payment
    public class Interest
    {
        public Interest()
        { }

        // Function to return Yearly Interest Payment
        public double getYearlyInterestPayment(double amount, double rate)
        {
            double total = (amount * rate) / 100;
            total *= 12;
            return total;
        }

        // Function to return Monthly Interest Payment
        public double getInterestRate(double amount, double rate)
        {
            return (amount * rate) / 100;
        }
    }
}
