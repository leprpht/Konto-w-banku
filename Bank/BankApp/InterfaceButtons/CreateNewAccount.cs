using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.InterfaceButtons
{
    public class CreateNewAccount
    {
        public static void AccountCreation(List<object> accountList)
        {
            ConsoleKeyInfo keyInfo;
            Console.Clear();
            Console.WriteLine("=====   Choose your account type   =====\n1 - Konto\n2 - KontoPlus\n3 - KontoLimit");
            string accountType;
            bool accountHasLimit = false;
            while (true)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
                {
                    accountType = "Konto";
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad2)
                {
                    accountType = "KontoPlus";
                    accountHasLimit = true;
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad3)
                {
                    accountType = "KontoLimit";
                    accountHasLimit = true;
                    break;
                }
            }
            Console.Clear();
            string name;
            while (true)
            {
                Console.Write("Enter the name: ");
                name = Console.ReadLine().Trim();
                if (name == null || name.Length == 0)
                    Console.WriteLine("Name cannot be empty.");
                else
                    break;
            }
            Console.Clear();
            decimal balance;
            while (true)
            {
                Console.Write("Enter the balance: ");
                string stringBalance = Console.ReadLine().Trim();
                if (decimal.TryParse(stringBalance, out decimal balanceResult))
                {
                    if (balanceResult < 0)
                        Console.WriteLine("Balance cannot be negative.");
                    else
                    {
                        balance = balanceResult;
                        break;
                    }
                }
                else
                    Console.WriteLine("Invalid balance.");
            }
            decimal limit = 0;
            if (accountHasLimit)
            {
                Console.Clear();
                while (true)
                {
                    Console.Write("Enter the limit: ");
                    string limitString = Console.ReadLine().Trim();
                    if (decimal.TryParse(limitString, out decimal limitResult))
                    {
                        if (limitResult < 0)
                            Console.WriteLine("Limit cannot be negative.");
                        else
                        {
                            limit = limitResult;
                            break;
                        }
                    }
                    else
                        Console.WriteLine("Invalid limit.");
                }
            }
            if (accountType == "Konto")
            {
                var account = new Konto(name, balance);
                accountList.Add(account);
            }
            else if (accountType == "KontoPlus")
            {
                var account = new KontoPlus(name, limit, balance);
                accountList.Add(account);
            }
            else if (accountType == "KontoLimit")
            {
                var kontoInAccount = new Konto(name, balance);
                var account = new KontoLimit(kontoInAccount, limit);
                accountList.Add(account);
            }
            Console.Clear();
            return;
        }
    }
}
