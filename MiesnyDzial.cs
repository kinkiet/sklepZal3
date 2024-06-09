using System;
namespace SklepLibrary.Dzialy
{
    public class MiesnyDzial : Dzial
    {
        public MiesnyDzial() : base("Dział Mięsny", new Produkt[]
        {
            new Produkt("Kurczak", 30, 4m),
            new Produkt("Wołowina", 20, 6m),
            new Produkt("Szynka", 25, 5m),
            new Produkt("Boczek", 15, 7m),
            new Produkt("Kiełbasa", 40, 3m)
        })
        { }
    }
}