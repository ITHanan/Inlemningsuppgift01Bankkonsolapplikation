

namespace Inlämningsuppgift01Bankkonsolapplikation
{
    public class PersonalKonto : Konto
    {

        public PersonalKonto(string kontoinnehavarens, double saldo, int kontoNumber) : base(kontoinnehavarens, saldo, kontoNumber)
        {




        }
        public int Kontonumber;

        public TransaktionHistorik transaktionHistorik;

   

       
    }
}
