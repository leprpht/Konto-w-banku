using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.InterfaceButtons
{
    public class Help
    {
        public static void HelpScreen()
        {
            Console.Clear();
            Console.Write("Press ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("N ");
            Console.ResetColor();
            Console.Write("to create a new account by choosing the account type, inserting the name and active balance.\nPress ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("A ");
            Console.ResetColor();
            Console.Write("to perform actions on an existing account: deposit or withdraw, block or unblock, change\nthe account type or see the account info.\nPress ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Q ");
            Console.ResetColor();
            Console.WriteLine("to quit.");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
