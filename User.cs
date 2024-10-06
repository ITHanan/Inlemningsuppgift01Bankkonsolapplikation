

using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace Inlämningsuppgift01Bankkonsolapplikation
{
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }





        public PersonalKonto PersonalAccount { get; private set; }

        public SparKonto SavingAccount { get; private set; }

        public InvesteringsKonto InvestmentAccount { get; private set; }

        public string Kontoinnehavarens { get; set; }
        public double Saldo { get; set; }
        public int KontoNumber { get; set; }



        public User(string name, string email)
        {
            UserName = name;
            Email = email;

            PersonalAccount = new PersonalKonto("Hanan's personal Account", 60000, 111);
            SavingAccount = new SparKonto("Hanan's Saving Accaount", 40000, 222);
            InvestmentAccount = new InvesteringsKonto("Hanan's investment Account ", 10000, 333);
        }
        //public User(string kontoinnehavarens, double saldo, int kontoNumber)

        //{
        //    Kontoinnehavarens = kontoinnehavarens;
        //    Saldo = saldo;
        //    KontoNumber = kontoNumber;


        //}
        public Konto ChoosedKonto()
        {
            while (true) {
                Console.WriteLine("\n welcome to Hanan bank ");
                Console.WriteLine("please choose one of the accounts below:");
                Console.WriteLine("1 - Personal Account ");
                Console.WriteLine("2 - Saving Account");
                Console.WriteLine("3 - Investerings");
                Console.WriteLine("4 - End ");

                Console.Write("Enter your choice: ");
                string Choosedkonto = Console.ReadLine()!;

                //    User newuser = new User("hanna", 50000, 123456);

                switch (Choosedkonto)
                {
                    case "1":
                        Console.WriteLine("You have selected  personal account ");
                        PersonalAccount.DisplayBalance();
                        return PersonalAccount;


                    case "2":

                        Console.WriteLine("You have selected  saving  account ");
                        SavingAccount.DisplayBalance();
                        return SavingAccount;


                    case "3":

                        Console.WriteLine("You have selected  saving  account ");
                        InvestmentAccount.DisplayBalance();
                        return InvestmentAccount;


                    case "4":
                        Console.WriteLine("Thank you for using Hanan Bank. Goodbye!");
                        return null;


                    default:
                        Console.WriteLine("The selected account does not exist. Please try again.");
                        return ChoosedKonto();

                }
            }
        }

        public void Deposit(double ammount)
        {
            if (ammount > 0)
            {
                Saldo = Saldo + ammount;

                Console.WriteLine($"{ammount} kr Invalid amount. Try again. {Saldo} kr.\n");
            }
            else
            {
                Console.WriteLine("Invalid amount or insufficient balance.");
            }
        }


        public void DisplayBalance()
        {
            Console.WriteLine($"Account Number: {KontoNumber}");
            Console.WriteLine($"Witch Account:   {UserName}");
            Console.WriteLine($"Current Balanse {Saldo}");
        }


        public void Draw(double ammount) {
            if (ammount > 0 && Saldo >= ammount)

            {
                Saldo = Saldo - ammount;

                Console.WriteLine($"you took out this much{ammount} from your account");

                Console.WriteLine($"Account balance is now : {Saldo}");
            }
            else 
            {
                Console.WriteLine("Invalid amount or insufficient funds.");
            }

        }
       

        public void  Transfer(int fromAccountNumber, int toAccountNumber, double ammount)
        {
            try
            {  // Fetch sender and receiver accounts based on account numbers
                Konto FråmKonto = GetAccountByNumber(fromAccountNumber);
                Konto tillKonto = GetAccountByNumber(toAccountNumber);


                if (FråmKonto == null)
                {
                    Console.WriteLine($"Sender account number {fromAccountNumber} not found.");
                    return;
                }

                if (tillKonto == null)
                {
                    Console.WriteLine($"Receiver account number {toAccountNumber} not found.");
                    return;
                }
                if (ammount <= 0)
                {
                    Console.WriteLine("Invalid amount. Please try again.");
                    return;
                }

                // Ensure both accounts exist

                // Check if the sender has enough balance for the withdrawal
                if (FråmKonto.Saldo >= ammount)
                {
                    // Perform the transfer by withdrawing from the sender and depositing into the receiver

                    FråmKonto.Draw(ammount);  // Withdraw from sender

                    tillKonto.Deposit(ammount);  // Deposit into receiver

                    Console.WriteLine($"Transfer of {ammount} kr from account {fromAccountNumber} to account {toAccountNumber} completed.");
                }
                else
                {
                    // Insufficient funds in the sender's account
                    Console.WriteLine("Insufficient funds in the sender's account.");
                }
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine($"Fel: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Fel: {ex.Message}");
            }
            
            catch (Exception ex)
            {
                Console.WriteLine($"Ett oväntat fel uppstod: {ex.Message}");
            }

        }

        private Konto GetAccountByNumber(int kontonummer)
        {
            // Assuming the bank class holds references to all three accounts
            if (PersonalAccount.KontoNumber == kontonummer)

                return PersonalAccount;

            else if (SavingAccount.KontoNumber == kontonummer)
                
                return SavingAccount;

            else if (InvestmentAccount.KontoNumber == kontonummer)

                return InvestmentAccount;

            return null;

        }


    }
}
// for att overfora pengerna jag muste matcha konto nummber till ret konto och kalla på respective draw och deposit metoden 