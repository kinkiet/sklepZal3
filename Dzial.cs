using System;

namespace SklepLibrary
{
    public class Dzial
    {
        public string Nazwa { get; set; }
        public Produkt[] Produkty { get; set; }

        public Dzial(string nazwa, Produkt[] produkty)
        {
            Nazwa = nazwa;
            Produkty = produkty;
        }

        public void WyswietlProdukty()
        {
            Console.WriteLine(Nazwa);
            for (int i = 0; i < Produkty.Length; i++)
            {
                Console.WriteLine($"{i} - {Produkty[i]}");
            }
            Console.WriteLine();
        }
    }
}