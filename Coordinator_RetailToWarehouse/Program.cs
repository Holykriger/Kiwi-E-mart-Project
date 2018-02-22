using System;

namespace Coordinator_RetailToWarehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dette projekt er skabt som koordineringsbindeled fra Retail til Warehouse.
            //For at fremskaffe et relevant Warehouse til den retail der spørger.
            //Det kan vi bruge i Oles fag som en Y-akse skalering.
            Console.WriteLine("Hello World!");
            //Vi kan bruge topic til områdeinddeling, så f.eks. en coordinator lytter til Warehouse.*, måske Warehouse.# hvis der kommer mere end 1 ekstra ord på.
        }
    }
}
