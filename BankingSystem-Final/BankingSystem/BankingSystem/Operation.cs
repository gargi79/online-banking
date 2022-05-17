using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem
{
    class Operation : ICommand
    {
        // test to store the operation name
        private string text;

        // Constructure of the class
        public Operation(string txt)
        {
            this.text = txt;
        }

        // Execute method of thr ICommand class
        public string Execute()
        {
            return text;
        }
    }
}
