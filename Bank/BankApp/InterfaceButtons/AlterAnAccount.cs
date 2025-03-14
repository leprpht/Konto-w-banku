using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.InterfaceButtons
{
    public class AlterAnAccount
    {
        public static void AccountWork(List<object> accounts)
        {
            Console.Clear();
            if (accounts.Count == 0)
            {
                Console.WriteLine("No accounts available.");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            else
            {
                AccountActions(AccountChoose(accounts), accounts);
                Console.Clear();
                return;
            }
        }


        public static object AccountChoose(List<object> accounts)
        {
            foreach (var account in accounts)
            {
                Console.Write($"{accounts.IndexOf(account)}. ");
                if (account is KontoPlus)
                {
                    var kontoAccount = (KontoPlus)account;
                    Console.WriteLine($"{kontoAccount.Nazwa} KontoPlus");
                }
                else if (account is Konto)
                {
                    var kontoAccount = (Konto)account;
                    Console.WriteLine($"{kontoAccount.Nazwa} - Konto");
                }
                else if (account is KontoLimit)
                {
                    var kontoAccount = (KontoLimit)account;
                    Console.WriteLine($"{kontoAccount.Konto.Nazwa} KontoLimit");
                }
            }
            int accountID;
            while (true)
            {
                Console.WriteLine("Insert an account id: ");
                string accountIdString = Console.ReadLine().Trim();
                if (accountIdString != null && accountIdString.Length != 0 && int.TryParse(accountIdString, out int AccountIdInt))
                {
                    if (AccountIdInt >= 0 && AccountIdInt < accounts.Count)
                    {
                        accountID = AccountIdInt;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid account id.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid account id.");
                }
            }
            var accountResult = accounts[accountID];
            Console.Clear();
            return accountResult;
        }


        public static void AccountActions(object account, List<object> accountList)
        {
            Console.Clear();
            Console.WriteLine("=====   Choose the operation type   =====\n\n" +
                "1 - Deposit               2 - Withdrawal\n" +
                "3 - Block the account     4 - Unblock the account\n" +
                "5 - Show info             6 - Change account type\n" +
                "Q - Quit");
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    var newAccount = new object();
                    decimal deposit;
                    while (true)
                    {
                        Console.Write("Enter the deposit amount: ");
                        string depositString = Console.ReadLine().Trim();
                        if (decimal.TryParse(depositString, out decimal depositResult))
                        {
                            if (depositResult < 0)
                                Console.WriteLine("Deposit amount cannot be negative.");
                            else
                            {
                                deposit = depositResult;
                                break;
                            }
                        }
                        else
                            Console.WriteLine("Invalid deposit amount.");
                    }
                    if (account is KontoPlus)
                    {
                        var kontoAccount = (KontoPlus)account;
                        kontoAccount.Wplata(deposit);
                        newAccount = kontoAccount;
                    }
                    else if (account is Konto)
                    {
                        var kontoAccount = (Konto)account;
                        kontoAccount.Wplata(deposit);
                        newAccount = kontoAccount;
                    }
                    else if (account is KontoLimit)
                    {
                        var kontoAccount = (KontoLimit)account;
                        kontoAccount.Wplata(deposit);
                        newAccount = kontoAccount;
                    }
                    int index = accountList.IndexOf(account);
                    accountList.Remove(account);
                    accountList.Insert(index, newAccount);
                    return;
                }
                else if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    var newAccount = new object();
                    decimal withdrawal;
                    while (true)
                    {
                        Console.Write("Enter the withdrawal amount: ");
                        string withdrawalString = Console.ReadLine().Trim();
                        if (decimal.TryParse(withdrawalString, out decimal withdrawalResult))
                        {
                            if (withdrawalResult < 0)
                                Console.WriteLine("Withdrawal amount cannot be negative.");
                            else
                            {
                                withdrawal = withdrawalResult;
                                break;
                            }
                        }
                        else
                            Console.WriteLine("Invalid withdrawal amount.");
                    }
                    if (account is KontoPlus)
                    {
                        var kontoAccount = (KontoPlus)account;
                        if (kontoAccount.Zablokowane)
                        {
                            Console.WriteLine("Account is blocked.");
                            Console.ReadKey(true);
                            return;
                        }
                        if (withdrawal > kontoAccount.Bilans)
                        {
                            if (withdrawal > kontoAccount.LimitJednorazowy)
                            {
                                Console.WriteLine("Withdrawal amount exceeds the one-time debit limit.");
                                Console.ReadKey(true);
                                return;
                            }
                        }
                        kontoAccount.Wyplata(withdrawal);
                        newAccount = kontoAccount;
                    }
                    else if (account is Konto)
                    {
                        var kontoAccount = (Konto)account;
                        if (kontoAccount.Zablokowane)
                        {
                            Console.WriteLine("Account is blocked.");
                            Console.ReadKey(true);
                            return;
                        }
                        if (withdrawal > kontoAccount.Bilans)
                        {
                            Console.WriteLine("Withdrawal amount exceeds the account balance.");
                            Console.ReadKey(true);
                            return;
                        }
                        kontoAccount.Wyplata(withdrawal);
                        newAccount = kontoAccount;
                    }
                    else if (account is KontoLimit)
                    {
                        var kontoAccount = (KontoLimit)account;
                        if (kontoAccount.Konto.Zablokowane)
                        {
                            Console.WriteLine("Account is blocked.");
                            Console.ReadKey(true);
                            return;
                        }
                        if (withdrawal > kontoAccount.Konto.Bilans)
                        {
                            if (withdrawal > kontoAccount.Limit)
                            {
                                Console.WriteLine("Withdrawal amount exceeds the one-time debit limit.");
                                Console.ReadKey(true);
                                return;
                            }
                        }
                        kontoAccount.Wyplata(withdrawal);
                        newAccount = kontoAccount;
                    }
                    int index = accountList.IndexOf(account);
                    accountList.Remove(account);
                    accountList.Insert(index, newAccount);
                    return;
                }
                else if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad3)
                {
                    var newAccount = new object();
                    if (account is KontoPlus)
                    {
                        var kontoAccount = (KontoPlus)account;
                        kontoAccount.BlokujKonto();
                        newAccount = kontoAccount;
                    }
                    else if (account is Konto)
                    {
                        var kontoAccount = (Konto)account;
                        kontoAccount.BlokujKonto();
                        newAccount = kontoAccount;
                    }
                    else if (account is KontoLimit)
                    {
                        var kontoAccount = (KontoLimit)account;
                        kontoAccount.BlokujKonto();
                        newAccount = kontoAccount;
                    }
                    int index = accountList.IndexOf(account);
                    accountList.Remove(account);
                    accountList.Insert(index, newAccount);
                    return;
                }
                else if (keyInfo.Key == ConsoleKey.D4 || keyInfo.Key == ConsoleKey.NumPad4)
                {
                    var newAccount = new object();
                    if (account is KontoPlus)
                    {
                        var kontoAccount = (KontoPlus)account;
                        kontoAccount.OdblokujKonto();
                        newAccount = kontoAccount;
                    }
                    else if (account is Konto)
                    {
                        var kontoAccount = (Konto)account;
                        kontoAccount.OdblokujKonto();
                        newAccount = kontoAccount;
                    }
                    else if (account is KontoLimit)
                    {
                        var kontoAccount = (KontoLimit)account;
                        kontoAccount.OdblokujKonto();
                        newAccount = kontoAccount;
                    }
                    int index = accountList.IndexOf(account);
                    accountList.Remove(account);
                    accountList.Insert(index, newAccount);
                    return;
                }
                else if (keyInfo.Key == ConsoleKey.D5 || keyInfo.Key == ConsoleKey.NumPad5)
                {
                    Console.Clear();
                    if (account is KontoPlus)
                    {
                        var kontoAccount = (KontoPlus)account;
                        Console.WriteLine($"Account info:\nAccount type: KontoPlus\nName: {kontoAccount.Nazwa}\nRemaining funds: {kontoAccount.Bilans}\nLimit: {kontoAccount.LimitJednorazowy}\nIs blocked: {kontoAccount.Zablokowane}");
                    }
                    else if (account is Konto)
                    {
                        var kontoAccount = (Konto)account;
                        Console.WriteLine($"Account info:\nAccount type: Konto\nName: {kontoAccount.Nazwa}\nRemaining funds: {kontoAccount.Bilans}\nIs blocked: {kontoAccount.Zablokowane}");
                    }
                    else if (account is KontoLimit)
                    {
                        var kontoAccount = (KontoLimit)account;
                        Console.WriteLine($"Account info:\nAccount type: KontoLimit\nName: {kontoAccount.Konto.Nazwa}\nRemaining funds: {kontoAccount.Konto.Bilans}\nLimit: {kontoAccount.Limit}\nIs blocked: {kontoAccount.Konto.Zablokowane}");
                    }
                    Console.ReadKey(true);
                    return;
                }
                else if (keyInfo.Key == ConsoleKey.D6 || keyInfo.Key == ConsoleKey.NumPad6)
                {
                    Console.Clear();
                    var newAccount = new object();
                    if (account is KontoPlus)
                    {
                        Console.WriteLine("Account types available:\n1 - Konto\n2 - KontoLimit");
                        while (true)
                        {
                            keyInfo = Console.ReadKey(true);
                            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
                            {
                                newAccount = new Konto(((KontoPlus)account).Nazwa, ((KontoPlus)account).Bilans);
                                break;
                            }
                            else if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad2)
                            {
                                newAccount = new KontoLimit(new Konto(((KontoPlus)account).Nazwa, ((KontoPlus)account).Bilans), ((KontoPlus)account).LimitJednorazowy);
                                break;
                            }
                        }
                    }
                    else if (account is Konto)
                    {
                        Console.WriteLine("Account types available:\n1 - KontoPlus\n2 - KontoLimit");
                        while (true)
                        {
                            keyInfo = Console.ReadKey(true);
                            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
                            {
                                newAccount = new KontoPlus(((Konto)account).Nazwa, 0, ((Konto)account).Bilans);
                                break;
                            }
                            else if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad2)
                            {
                                newAccount = new KontoLimit(new Konto(((Konto)account).Nazwa, ((Konto)account).Bilans), 0);
                                break;
                            }
                        }
                    }
                    else if (account is KontoLimit)
                    {
                        Console.WriteLine("Account types available:\n1 - Konto\n2 - KontoPlus");
                        while (true)
                        {
                            keyInfo = Console.ReadKey(true);
                            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
                            {
                                newAccount = new Konto(((KontoLimit)account).Konto.Nazwa, ((KontoLimit)account).Konto.Bilans);
                                break;
                            }
                            else if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad2)
                            {
                                newAccount = new KontoPlus(((KontoLimit)account).Konto.Nazwa, ((KontoLimit)account).Limit, ((KontoLimit)account).Konto.Bilans);
                                break;
                            }
                        }
                    }
                    int index = accountList.IndexOf(account);
                    accountList.Remove(account);
                    accountList.Insert(index, newAccount);
                    return;
                }
                else if (keyInfo.Key == ConsoleKey.Q)
                {
                    Console.Clear();
                    return;
                }
            }
        }
    }
}
