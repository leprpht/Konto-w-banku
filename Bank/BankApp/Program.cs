namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var accounts = new List<object>();
            while (true)
            {
                UserInterface.MainScreen(accounts);
            }
        }
    }
}
