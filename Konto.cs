

namespace Inlämningsuppgift01Bankkonsolapplikation
{
    public  class Konto
    {

        public string Kontoinnehavarens { get; set; }

        public double Saldo { get; set; }
        public int KontoNumber { get; set; }
        public Konto(string kontoinnehavarens, double saldo, int kontoNumber)
        {
            Kontoinnehavarens = kontoinnehavarens;

            Saldo = saldo;

            KontoNumber = kontoNumber;

        }



        public virtual void Deposit(double ammount)
        {
            if (ammount > 0)
            {
                Saldo = Saldo + ammount;

                Console.WriteLine($"{ammount} kr has been inserted. New balance: {Saldo} kr.\n");
            }
            else
            {
                Console.WriteLine("Invalid amount. Try again.");
            }
        }

        public virtual void Draw(double ammount)

        {
            if (ammount > 0 && Saldo >= ammount)
            {
            Saldo = Saldo - ammount;

            Console.WriteLine($"you took out this much{ammount} from your account");

            Console.WriteLine($"Account balance is now : {Saldo}");

            }

            else
            {
                Console.WriteLine("Invalid amount or insufficient balance.");
            }

        }

        public  virtual void DisplayBalance()
        {
            Console.WriteLine($" Account numbe: {KontoNumber},is {Kontoinnehavarens}: has : {Saldo}");
        }

        //public  Konto  GetAccountByNumber (Konto bank, int kontonummer)
        //{
        //    // Assuming the bank class holds references to all three accounts
        //    if (bank.personKonto.KontoNumber == kontonummer)

        //        return bank.personKonto;

        //    else if (bank.sparKonto.KontoNumber == kontonummer)

        //        return bank.sparKonto;

        //    else if (bank.investeringsKonto.KontoNumber == kontonummer)

        //        return bank.investeringsKonto;
        //    else
        //    {
        //        Console.WriteLine("Kontonummer hittades inte.");
        //        return null;
        //    }
        //}


    }
}
