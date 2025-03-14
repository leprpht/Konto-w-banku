using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class UserInterface
    {
        public static void MainScreen(List<object> accounts)
        {
            Console.WriteLine("=====   Choose the operation type   =====\n\nN - Create a new account\nA - Actions on an existing account\nH - Help\nQ - Quit");
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.N)
                {
                    InterfaceButtons.CreateNewAccount.AccountCreation(accounts);
                    return;
                }
                else if (keyInfo.Key == ConsoleKey.A)
                {
                    InterfaceButtons.AlterAnAccount.AccountWork(accounts);
                    return;
                }
                else if (keyInfo.Key == ConsoleKey.H)
                {
                    InterfaceButtons.Help.HelpScreen();
                    return;
                }
                else if (keyInfo.Key == ConsoleKey.Q)
                {
                    Environment.Exit(0);
                    return;
                }
            }
        }
    }
}
