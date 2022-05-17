using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem
{
    // Saving Account class to deal with saving account portion
    public class SavingAccount : Account
    {
        // Variable to hold year gain according to Current Balance and Interest Rate
        public double yearlyInterestAmount { get; set; }

        // constructor of the Saving account class
        public SavingAccount(string accNumber) :  base(accNumber)
        {}
    }
}
