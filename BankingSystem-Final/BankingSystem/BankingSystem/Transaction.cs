using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem
{
    // Transaction class hold record of every funds transfer
    public class Transaction
    {
        // Variable to store Sending account information
        public SavingAccount accountFrom { get; set; }
        // Variable to store Receiving account information
        public SavingAccount accountTo { get; set; }
        // Variable to store Transfered amount details
        public double amount { get; set; }

        // Transaction class Constructor
        public Transaction(SavingAccount a1, SavingAccount a2, double amt)
        {
            this.accountFrom = a1;
            this.accountTo = a2;
            this.amount = amt;
        }
    }
}
