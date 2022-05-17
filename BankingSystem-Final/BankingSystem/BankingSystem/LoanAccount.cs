using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem
{
    // loan Account class to deal with Loan account portion
    public class LoanAccount : Account
    {
        // Variable to hold total Loan amount Details
        public double totalBalance;

        // Loan class constructor
        public LoanAccount(string accNumber) : base(accNumber)
        {
            this.totalBalance = 30000;
            base.currentBalance = this.totalBalance;
        }
    }
}
