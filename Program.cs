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
            InsideAccount();

        }

        //System login information, gives multiple attempts locking out after 3 failed attempts
        static public void AccountLogin() { 
            int[] accountInfo = { 11, 8 };
            int[] enteredInfo = { 1, 1 };
            int b = 0;

            for (int i = 0; i <= 3; i++)
            {
                if (i == 1)
                {
                    Console.WriteLine("You have 2 attempts remaining...");
                    b = 0;
                }
                if (i == 2)
                {
                    Console.WriteLine("You have 1 attempt remaining...");
                    b = 0;
                }
                if (i == 3)
                {
                    Console.WriteLine("You have attempted too many times, the system will lock you out for 5 seconds");
                    System.Threading.Thread.Sleep(5000);
                    i = 0;
                    b = 0;
                }

                while (b < 1)
                {
                    Console.WriteLine("Enter the account number...");
                    enteredInfo[0] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the account PIN...");
                    enteredInfo[1] = Convert.ToInt32(Console.ReadLine());
                    b = 1;
                }

                if (enteredInfo[0] != accountInfo[0])
                {
                    Console.WriteLine("Your user information was not correct...");
                    b = 0;
                }
                if (enteredInfo[0] == 11 && enteredInfo[1] != 8)
                {
                    Console.WriteLine("Your password does not match your user information...");
                    b = 0;
                }
                if (enteredInfo[0] == accountInfo[0] && enteredInfo[1] == accountInfo[1])
                {
                    Console.WriteLine("You have successfully entered your information!");
                    return;
                }
            }
        }

        // All the functions for inside the ATM system
        static void InsideAccount()
        {
            decimal deposit, withdraw;
            string action;
            int i = 0;

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
                string tempaction = Console.ReadLine();
                while (i == 0)
                {

                    if (tempaction == "yes")
                    {
                        action = "a";
                        break;
                    }
                    if (tempaction == "no")
                    {
                        Console.WriteLine("Exiting to main menu...");
                        InsideAccount();
                    }
                    else
                    {
                        Console.WriteLine("You have entered an incorrect value" +
                            "\nWould you like to make another transaction? yes/no");
                        tempaction = Console.ReadLine();
                    }
                }
            }

            // Deposit function
            while (action == "b")
            {
                
                Console.WriteLine("How much would you like to deposit?");
                deposit = Convert.ToDecimal(Console.ReadLine());
                balance = balance + deposit;
                Console.WriteLine("You have deposited ${0} \nYour new balance is: ${1}", deposit, balance);
                Console.WriteLine("Would you like to make another deposit? yes/no");
                string tempaction = Console.ReadLine();
                if (tempaction == "no")
                {
                    InsideAccount();
                }
                if (tempaction == "yes")
                {
                    
                }
                else
                {
                    Console.WriteLine("You have entered an incorrect value. Exiting to main menu");
                    InsideAccount();
                }
            }
            if (action == "c")
            {
                Console.WriteLine("Thank you for using our ATM.\n" +
                    "Have a nice day.");
                System.Threading.Thread.Sleep(2000);
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("You have entered an incorrect value. Please choose an option from the menu...");
                InsideAccount();
            }
        }
    }
}
