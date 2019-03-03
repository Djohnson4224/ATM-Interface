using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMinterface
{
    class Program
    {
        public static decimal balance = 105.99m;

        static void Main(string[] args)
        {
            AccountLogin();
            InsideAccountInteraction();
        }

        //System login information, gives multiple attempts locking out after 3 failed attempts
        public static void AccountLogin() { 
            int accountNum = 11;
            int accountPin = 8;
            int enteredAccountNum;
            int enteredPin;

            for (int attempts = 0; attempts <= 3; attempts++)
            {
                if (attempts == 1)
                {
                    Console.WriteLine("You have 2 attempts remaining...");
                }
                if (attempts == 2)
                {
                    Console.WriteLine("You have 1 attempt remaining...");
                }
                if (attempts == 3)
                {
                    Console.WriteLine("You have attempted too many times, the system will lock you out for 5 seconds");
                    System.Threading.Thread.Sleep(5000);
                    attempts = 0;
                }

                
                Console.WriteLine("Enter the account number...");
                enteredAccountNum = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the account PIN...");
                enteredPin = Convert.ToInt32(Console.ReadLine());
                    

                if (enteredAccountNum != accountNum)
                {
                    Console.WriteLine("Your user information was not correct...");
                }
                if (enteredAccountNum == accountNum && enteredPin != accountPin)
                {
                    Console.WriteLine("Your password does not match your user information...");
                }
                if (enteredAccountNum == accountNum && enteredPin == accountPin)
                {
                    Console.WriteLine("You have successfully entered your information!");
                    Console.WriteLine("Accessing your account...");
                    System.Threading.Thread.Sleep(2000);
                    return;
                }
            }
        }

        // All the functions for inside the ATM system
        public static void InsideAccountInteraction()
        {
            decimal deposit, withdraw;
            string action;

            do {
                Console.Clear();
                Console.WriteLine("What would you like to do? \n" +
                    "a) Withdraw\n" +
                    "b) Deposit\n" +
                    "c) Exit");
                action = Console.ReadLine();



                // Withdraw function
                while (action == "a")
                {
                    Console.WriteLine("You currently have: ${0} \nHow much would you like to withdraw?", balance);
                    withdraw = Convert.ToDecimal(Console.ReadLine());
                    if (balance - withdraw >= 0)
                    {
                        balance = balance - withdraw;
                        Console.WriteLine("Your money is being processed. You have ${0} remaining", balance);
                    }
                    else
                    {
                        Console.WriteLine("You have insufficient funds.");
                    }
                    Console.WriteLine("Would you like to make another withdrawal? yes/no");
                    string anotherWithdrawal = Console.ReadLine();
                    do
                    {

                        if (anotherWithdrawal == "yes")
                        {
                            Console.WriteLine("Preparing for another withdrawal...");
                        }
                        if (anotherWithdrawal == "no")
                        {
                            Console.WriteLine("Exiting to main menu...");
                            System.Threading.Thread.Sleep(2000);
                            action = "main menu";
                        }
                        if (anotherWithdrawal != "yes" && anotherWithdrawal != "no")
                        {
                            Console.WriteLine("You have entered an incorrect value.\n" +
                                "Would you like to make another withdrawal? yes/no");
                            anotherWithdrawal = Console.ReadLine();
                        }
                    } while (anotherWithdrawal != "yes" && anotherWithdrawal != "no");
                }

                // Deposit function
                while (action == "b")
                {

                    Console.WriteLine("How much would you like to deposit?");
                    deposit = Convert.ToDecimal(Console.ReadLine());
                    balance = balance + deposit;
                    Console.WriteLine("You have deposited ${0} \nYour new balance is: ${1}", deposit, balance);
                    Console.WriteLine("Would you like to make another deposit? yes/no");
                    string anotherDeposit = Console.ReadLine();
                    do
                    {
                        if (anotherDeposit == "yes")
                        {
                            Console.WriteLine("Preparing for another deposit...");
                        }

                        if (anotherDeposit == "no")
                        {
                            Console.WriteLine("Exiting to main menu...");
                            System.Threading.Thread.Sleep(2000);
                            action = "main menu";
                        }

                        if (anotherDeposit != "yes" && anotherDeposit != "no")
                        {
                            Console.WriteLine("You have entered an incorrect value.\n" +
                                "Would you like to make another deposit? yes/no");
                        }
                    } while (anotherDeposit != "yes" && anotherDeposit != "no");
                }

                
            } while (action != "c");

            Console.WriteLine("Thank you for using our ATM.\n" +
                    "Have a nice day.");
            System.Threading.Thread.Sleep(2000);
            System.Environment.Exit(0);
        }
    }
}
