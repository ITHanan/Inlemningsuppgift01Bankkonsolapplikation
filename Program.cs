using System;

namespace Inlämningsuppgift01Bankkonsolapplikation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            User newuser = new User("Hanan", "ithanan@gmail.com");
            
            //newuser.InvestmentAccount.transaktionHistorik.förstaTransaktion = DateTime.Now;

            //newuser.PersonalAccount.transaktionHistorik.sistaTransaktion = DateTime.Now;

            //newuser.SavingAccount.transaktionHistorik.förstaTransaktion = DateTime.Now;

           



            while (true)
            {

                Konto selectedAccount = newuser.ChoosedKonto();
                if (selectedAccount == null ) 
                    break;


                Console.WriteLine("\nWhat would you like to do? ");
                Console.WriteLine("Select form the list below: ");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdrawal");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Show balance");
                Console.WriteLine("5. Back to Account Selection");
                Console.WriteLine("6. Exit ");

                Console.Write("Enter your choice: ");


                string optin = Convert.ToString(Console.ReadLine())!;

                switch (optin)

                {

                    case "1":

                        //the user write account number 

                         Console.Write("Enter ammount to deposit: ");


                        // the user enter an ammount of money that he want to put in the selected account 


                        string DepositMoneyString = Console.ReadLine()!;
                        int Deposit = Convert.ToInt32(DepositMoneyString);

                        selectedAccount.Deposit(Deposit);
                        break;


                    case "2":


                        Console.Write("Enter amount to withdraw: ");

                        string WithdrawalMoneyString = Console.ReadLine()!;
                        int Draw = Convert.ToInt32(WithdrawalMoneyString);

                        selectedAccount.Draw(Draw);

                        break;


                     case "3":



                        Console.WriteLine("vilken konto vil du skika penger ifron ");

                        int FråmKontoNumber =  AccountEnteredByUser();

                        Console.WriteLine("Enter  the ammount of money that you want to transfer to");

                        int transferMoney = Convert.ToInt32(Console.ReadLine()!);

                        Console.WriteLine("Which account you want to send money to ");

                        int kontoTillNumber = AccountEnteredByUser();

                        newuser.Transfer(FråmKontoNumber, kontoTillNumber, transferMoney);


                        break;

                        case "4":

                        selectedAccount.DisplayBalance();

                        break;


                        case "5":
                        // Avsluta
                        Console.WriteLine("Thank you for using our banking service!");
                        return;

                        default:
                        Console.WriteLine("Invalid selection. Try again.");
                        break;

                }
            }

            Console.WriteLine("Application terminated.");

        }

        private static int AccountEnteredByUser()
        {
            Console.WriteLine("Enter account Number Whether it's Personal account ,Saving account or investing account\n");

            int accountNumberEntredfromUser = Convert.ToInt32(Console.ReadLine()!);

            return accountNumberEntredfromUser;
        }
    }
}