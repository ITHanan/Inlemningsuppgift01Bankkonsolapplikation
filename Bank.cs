

namespace Inlämningsuppgift01Bankkonsolapplikation
{
    public class Bank
    {
        public PersonalKonto personKonto;

        public SparKonto sparKonto;

        public InvesteringsKonto investeringsKonto;


        public Bank(string kontoname, double startPersonKontoSaldo,double startSparKontoSaldo,double StartInvesteringsKontoSaldo)
        {
            personKonto = new PersonalKonto( kontoname, startPersonKontoSaldo,1111);

            sparKonto = new SparKonto(kontoname, startSparKontoSaldo, 2222);

            investeringsKonto = new InvesteringsKonto (kontoname, StartInvesteringsKontoSaldo, 3333);

        }

        public void Transfering(Konto FrånKonto, Konto tillKonto, double ammount)
        {
            if (FrånKonto.Saldo >= ammount && ammount > 0)
            {
                FrånKonto.Draw(ammount);
                tillKonto.Deposit(ammount);
                Console.WriteLine($"{ammount} kr has been transferred from {FrånKonto.KontoNumber} till {tillKonto.KontoNumber}\n ");

            }

            else 
            {
                Console.WriteLine("Transfer failed. Check balance and amount.");
            }
        }

        public void ShowKontoinformation() 
        {
            Console.WriteLine("PersonKonto:");

            personKonto.DisplayBalance();

            Console.WriteLine("Sparkonto:");

            sparKonto.DisplayBalance();

            Console.WriteLine("InvesteringsKonto");

            investeringsKonto.DisplayBalance();
        }

    }
}
