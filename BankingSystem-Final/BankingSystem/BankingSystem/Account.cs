using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem
{
    // Account class hold the details of the account
    public class Account
    {
        // variable to store the account number
        public string accountNumber { get; set; }
        // Variable to store the Current Balance
        public double currentBalance { get; set; }
        // Variable to store the Interest rate
        public double interestRate { get; set; }

        // Constructor of the Account class
        public Account(string account)
        {
            this.accountNumber = account;
            this.currentBalance = 15000;
            this.interestRate = 0.5;
        }
    }
}
