namespace Encapsulation
{
    internal class Program
    {
        public class BankAccount
        {
            private string ownerName;
            private double balance;

            public BankAccount(string ownerName, double initialBalance)
            {
                this.ownerName = ownerName;
                this.balance = initialBalance;
            }

            // Owner Name — পড়া যাবে, কিন্তু change করা যাবে না
            public string OwnerName
            {
                get { return ownerName; }
            }

            // Balance — শুধু পড়া যাবে, সরাসরি change করা যাবে না
            public double Balance
            {
                get { return balance; }
            }

            // টাকা জমা দেওয়া — validation সহ
            public void Deposit(double amount)
            {
                if (amount > 0)
                {
                    balance += amount;
                    Console.WriteLine($"{amount} Taka deposited. Current Balance: {balance}");
                }
                else
                {
                    Console.WriteLine("Error: জমার পরিমাণ 0-এর বেশি হতে হবে!");
                }
            }

            // টাকা তোলা — validation সহ
            public void Withdraw(double amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Error: তোলার পরিমাণ 0-এর বেশি হতে হবে!");
                }
                else if (amount > balance)
                {
                    Console.WriteLine($"Error: পর্যাপ্ত balance নেই! বর্তমান Balance: {balance}");
                }
                else
                {
                    balance -= amount;
                    Console.WriteLine($"{amount} Taka Withdrawed Current Balance: {balance}");
                }
            }
        }

        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("Saiful", 50000);
            
            Console.WriteLine(account.OwnerName);  // Output: Saiful
            Console.WriteLine(account.Balance);    // Output: 50000

            account.Deposit(10000);
            account.Withdraw(20000);
           
        }
    }
}
