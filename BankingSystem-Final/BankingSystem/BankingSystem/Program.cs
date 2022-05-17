using System;
using System.IO;
using System.Threading;
using Authenticate;
using System.Collections.Generic;
using InterestCalculation;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variable to store Operations names
            Stack<ICommand> operationList = new Stack<ICommand>();

            // Variable to store transaction Record
            Stack<Transaction> transactionsList = new Stack<Transaction>();

            // Variable throught which we can invoke external library function to calculate Interest
            Interest interest = new Interest();
            while (true)
            {
                // Function to Display Welcome Menu
                welcomeMenu();
                // Taking inout from User
                string option = Console.ReadLine();

                // If User press "Login" option
                if (option == "1")
                {
                    // Taking Login details from User
                    Console.Write("\n\tEnter User Name : ");
                    string name = Console.ReadLine();
                    Console.Write("\n\tEnter Password : ");
                    string pass = Console.ReadLine();
                    Console.Write("\n\tEnter User Type(User or Employee): ");
                    string type = Console.ReadLine();

                    // External Library use to verify details of required User
                    UserVerification allUser = new UserVerification(@"C:\Users\garhg\Desktop\cpts321-in-class-exercise\BankingSystem-Final\BankingSystem\File.txt");

                    // If Login details are correct then Move forward
                    if (allUser.find(name, pass, type))
                    {
                        // Creating Accounts for this project
                        SavingAccount account = new SavingAccount("123asd");
                        LoanAccount account1 = new LoanAccount("123asd");

                        while (true)
                        {
                            // Clear The Console
                            Console.Clear();
                            // Display Main Menu
                            mainMenu();
                            // Taking Input from User
                            option = Console.ReadLine();

                            // If the User wants "Check Account"
                            if (option == "1")
                            {
                                // Push Operation on Stack to keep record
                                operationStack(operationList, 1);
                                // Calling checkAccount Function in Seprate Thread
                                Thread thread = new Thread(() => checkAccount(account, operationList));
                                thread.Start();
                            }
                            // If the User wants "Saving Account"
                            else if (option == "2")
                            {
                                // Calculate Year Interest Amount
                                account.yearlyInterestAmount = interest.getYearlyInterestPayment(account.currentBalance, account.interestRate);
                                // Push Operation on Stack to keep record
                                operationStack(operationList, 2);
                                // Calling SavingAccount Function in Seprate Thread
                                Thread thread = new Thread(() => savingAccount(account, transactionsList));
                                thread.Start();
                            }
                            // If the User wants "Loan Accounts"
                            else if (option == "3")
                            {
                                // Push Operation on Stack to keep record
                                operationStack(operationList, 3);
                                // Calling LoanAccount Function in Seprate Thread
                                Thread thread = new Thread(() => loanAccount(account1, interest.getInterestRate(account1.totalBalance, account1.interestRate)));
                                thread.Start();

                            }
                            // If the User wants "Funds Transfer"
                            else if (option == "4")
                            {
                                // Calculate Year Interest Amount
                                account.yearlyInterestAmount = interest.getYearlyInterestPayment(account.currentBalance, account.interestRate);
                                // Push Operation on Stack to keep record
                                operationStack(operationList, 4);
                                // Calling Funds Transfer Function
                                fundsTransfer(account, transactionsList);
                            }
                            // If User Wants "Exits"
                            else if (option == "5")
                            {
                                break;
                            }
                            else
                                Console.WriteLine("\n\nKindly! enter correct Option...");

                            // Sleep for 5 Seconds to see details properly
                            Thread.Sleep(4000);

                            // Clear The Console
                            Console.Clear();
                        }
                    }
                    // If Login Details are incorrect
                    else
                        Console.WriteLine("Kindly! enter Correct details...");

                }
                // If User press "Exit" then Program terminats
                else if (option == "2")
                {
                    break;
                }
                // If User press Invalid option
                else
                    Console.WriteLine("\n\nKindly! enter correct Option...");
                // Sleep for 3 Seconds to see details properly
                Thread.Sleep(2000);
                // Clear The Console
                Console.Clear();
            }
        }

        // Function to Display Welcome Message
        static public void welcomeMenu()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t#     # ##### #      ####   ###  ##    ## #####");
            Console.WriteLine("\t\t#     # #     #     #      #   # # #  # # #    ");
            Console.WriteLine("\t\t#  #  # ####  #     #      #   # #  ##  # #### ");
            Console.WriteLine("\t\t# # # # #     #     #      #   # #      # #    ");
            Console.WriteLine("\t\t##   ## ##### #####  ####   ###  #      # #####");
            Console.WriteLine("\n\n\t 1. Login");
            Console.WriteLine("\n\t 2. Exit");
            Console.Write("\n\tEnter the Choice : ");
        }

        // Function to Display Main Menu
        static public void mainMenu()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t1. Check Account ");
            Console.WriteLine("\t2. Saving Account");
            Console.WriteLine("\t3. Loans ");
            Console.WriteLine("\t4. Funds Transfer");
            Console.WriteLine("\t5. Exit\n");
            Console.Write("\tEnter the Choice : ");

        }

        // Function to Puch Operation according to user Action
        static public void operationStack(Stack<ICommand> operationList, int number)
        {
            if (number == 1)
                operationList.Push(new Operation("Check Account"));
            else if (number == 2)
                operationList.Push(new Operation("Saving Account"));
            else if (number == 3)
                operationList.Push(new Operation("Loans"));
            else if (number == 4)
                operationList.Push(new Operation("Funds Transfer"));
            if (operationList.Count > 10)
                operationList.Pop();
        }

        // Function to deal with Check Account Option to display all required details
        static public void checkAccount(Account account, Stack<ICommand> operationList)
        {
            Console.WriteLine("\n\tAccount Number : " + account.accountNumber);
            Console.WriteLine("\tCurrent Balance : " + account.currentBalance);
            Console.WriteLine("\n");
            Console.WriteLine("\t Op. No\t Operation Name");
            Console.WriteLine("\t ------\t --------------");

            // Display all Operations
            if (operationList.Count > 0)
            {
                int count = 1;
                foreach (var i in operationList)
                {
                    Console.WriteLine("\t   " + count + "  \t  " + i.Execute());
                    count++;
                }
            }
            else
                Console.WriteLine("No Record Found...");
        }

        // Function to deal with Saving Account option to display all required details
        static public void savingAccount(SavingAccount account, Stack<Transaction> transactionsList)
        {
            Console.WriteLine("\n\tAccount Number : " + account.accountNumber);
            Console.WriteLine("\tCurrent Balance : " + account.currentBalance);
            Console.WriteLine("\tInterest Rate : " + account.interestRate);
            Console.WriteLine("\tYearly Interest Payment : " + account.yearlyInterestAmount);
            Console.WriteLine("\n");
            Console.WriteLine("\t Trans. No\t From\t To\t Amount");
            Console.WriteLine("\t ----------\t ----\t---\t ------");
            int count = 1;

            // Display all available Transaction
            if (transactionsList.Count > 0)
            {
                foreach (var i in transactionsList)
                {
                    Console.WriteLine("\t    " + count + "\t\t" + i.accountFrom.accountNumber + "\t" + i.accountTo.accountNumber + "\t" + i.amount);
                    count++;
                }
            }
            else
                Console.WriteLine("No Record Found...");
        }

        // Function to deal with Loan Account option to display all required details
        static public void loanAccount(LoanAccount account, double interest)
        {

            Console.WriteLine("\n\tAccount Number : " + account.accountNumber);
            Console.WriteLine("\tTotal Balance : " + account.totalBalance);
            Console.WriteLine("\tCurrent Balance : " + account.currentBalance);
            Console.WriteLine("\tInterest Rate : " + account.interestRate);
            Console.WriteLine("\n");
            Console.WriteLine("\t Pay. No\t Total Balance\t Current Balance \t Interest Gain");
            Console.WriteLine("\t --------\t -------------\t-----------------\t ------------");

            // Display all analysis according to available data
            double balance = account.currentBalance + interest;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(" \t   " + (i + 1) + "  \t\t    " + account.totalBalance + "\t\t" + balance + "\t\t\t" + interest);
                balance += interest;
            }
        }

        // Function to deal with Funds Transfer option to tansfer required legal ammount
        static public void fundsTransfer(SavingAccount account1, Stack<Transaction> transactionsList)
        {
            Console.Write("\nEnter the Account Number : ");
            string accNbr = Console.ReadLine();
            Console.Write("Enter the Amount : ");
            double amount = double.Parse(Console.ReadLine());
            // If transfer amount is legal
            if (amount <= account1.currentBalance)
            {
                bool flag = undoRedoTransaction();
                if (flag)
                {
                    SavingAccount account2 = new SavingAccount(accNbr);
                    // Duducting amount from one account
                    account1.currentBalance -= amount;
                    // Adding amount in other account
                    account2.currentBalance += amount;
                    transactionsList.Push(new Transaction(account1, account2, amount));
                    Console.Write("$" + amount + " was Successfully Transfered to Acc/No " + accNbr);
                }
                else
                    Console.WriteLine("ok. Your Transaction is Reversed");
            }
            else
                Console.WriteLine("Sorry! you have Insufficient Balance...");

        }

        // Function to use Undo/Redo the transaction
        static public bool undoRedoTransaction()
        {
            Console.WriteLine("\n1. Undo Transaction");
            Console.WriteLine("\nEnter the Choice : ");
            CountdownEvent obj = new CountdownEvent(10);

            object input = null;
            var t1 = new Thread(() =>
            {
                input = Console.ReadLine();
            });
            var t2 = new Thread(() =>
            {
                for(int i=0; i<10;i++)
                {
                    obj.Signal();
                    Thread.Sleep(1000);
                }
            });
            t1.Start();
            t2.Start();
            while (true)
            {
                if (obj.CurrentCount == 0)
                    return true;
                else if (Convert.ToString(input) == "1")
                    return false;
                Thread.Sleep(2000);
            }

        }
    }
}
