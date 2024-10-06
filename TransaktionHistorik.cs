

namespace Inlämningsuppgift01Bankkonsolapplikation
{
    public class TransaktionHistorik
    {

        public DateTime förstaTransaktion { get; set; }

        public DateTime sistaTransaktion { get; set; }

        public TransaktionHistorik() 
        {
            förstaTransaktion = DateTime.Now;
            sistaTransaktion = DateTime.Now;
        }

        public void UppdateSistaTransaction() 
        {
            sistaTransaktion = DateTime.Now;
        }


    }
}
