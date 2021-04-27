// Challenge to creat a bankAccount program

using System;

namespace Progchallenge
{
    abstract class BankAccont
    {
        private string AccountOwner;
        private string lastName;
        public decimal Balance;

        public BankAccont(string f, string l, decimal la)
        {
            AccountOwner = f;
            lastName = l;
            Balance = la;  }

        public abstract void Deposit(decimal amount);



        public abstract void Withdraw(decimal amount);



        class SavingsAcct : BankAccont

        {
            public int count = 0;


            public SavingsAcct(string f, string l, decimal la) : base(f, l, la)
            {


                AccountOwner = f;
                lastName = l;
                Balance = la;
            }

            public override void Deposit(decimal amount)
            {
                if (amount > Balance)
                {
                     Console.WriteLine("Denied");

                }
                else
                {
                    Balance += amount;

                     Console.WriteLine("accepted");
                }
            }

            public override void Withdraw(decimal amount)
            {
                if (amount > Balance)
                {
                    Console.WriteLine("Denied");

                }
                else
                {
                    Balance -= amount;
                    count++;
                    Console.WriteLine("accepted");


                    if (count > 3)
                        Balance = Balance - 2;



                }

            }
        }



            class CheckingAcct : BankAccont
            {
            public int count = 0;

            public CheckingAcct(string f, string l, decimal la) : base(f, l, la)
                {

                    AccountOwner = f;
                    lastName = l;
                    Balance = la;
                }

                public override void Deposit(decimal amount)
                {
                    if (amount > Balance)
                    {
                          Console.WriteLine("Denied");

                    }
                    else
                    {
                        Balance += amount;
                    
                          Console.WriteLine("accepted");
                    }
                }

                public override void Withdraw(decimal amount)
                {
                    if (amount > Balance)
                    {
                          Console.WriteLine("Denied");

                    }
                    else
                    {

                        Balance -= amount;
                    count++;

                    if (count > 3)
                        Balance = Balance - 2;
                      Console.WriteLine("accepted");




                }

                }


            }


            static void Main(string[] args)
            {

                // Create the Checking Account with initial balance
                CheckingAcct checking = new CheckingAcct("Ahmad", "Nasser", 2500.0m);
                // Create the Savings Account with interest and initial balance
                SavingsAcct saving = new SavingsAcct("Ahmad", "Nasser", 1000.0m);
                  

                // Check the balances
                // Expected output should be 2500 and 1000 at this point
                Console.WriteLine($"Checking balance is {checking.Balance:C2}");
                Console.WriteLine($"Savings balance is {saving.Balance:C2}");
                // Print the account owner information. Expected output: 
                // "Checking owner: Ahmad Nasser"
                // "Savings owner: Ahmad Nasser"
                Console.WriteLine($"Checking owner: {checking.AccountOwner}");
                Console.WriteLine($"Savings owner: {saving.AccountOwner}");
                // Deposit some money in each account
                checking.Deposit(200.0m);
                saving.Deposit(150.0m);
                // Check the balances
                // Expected output should be 2700 and 1150 at this point
                Console.WriteLine($"Checking balance is {checking.Balance:C2}");
                Console.WriteLine($"Savings balance is {saving.Balance:C2}");
                // Make some withdrawals from each account
                checking.Withdraw(50.0m);
                saving.Withdraw(125.0m);
                // Check the balances
                // Expected output should be 2650 and 1025 at this point
                Console.WriteLine($"Checking balance is {checking.Balance:C2}");
                Console.WriteLine($"Savings balance is {saving.Balance:C2}");
                // More than 3 Savings withdrawals should result in 2.00 charge
                saving.Withdraw(10.0m);
                saving.Withdraw(20.0m);
                saving.Withdraw(30.0m);
                // Savings balance should now be 988.63
                Console.WriteLine($"Savings balance is {saving.Balance:C2}");
                // try to overdraw savings - this should be denied and print message
                saving.Withdraw(2000.0m);
                // try to overdraw checking - this should be denied and print message
                checking.Withdraw(3000.0m);


                // 2.650 and 988.63
                Console.WriteLine($"Checking balance is {checking.Balance:C2}");
                Console.WriteLine($"Savings balance is {saving.Balance:C2}");
            }
        
    }
}
