using System;

namespace SklepLibrary.Dzialy
{
    public class WarzywnyDzial : Dzial
    {
        public WarzywnyDzial() : base("Dział Warzywny", new Produkt[]
        {
            new Produkt("Pomidor", 50, 1m),
            new Produkt("Ogórek", 30, 1m),
            new Produkt("Marchew", 40, 1m),
            new Produkt("Ziemniaki", 100, 1m),
            new Produkt("Cebula", 50, 1m)
        })
        { }
    }
}