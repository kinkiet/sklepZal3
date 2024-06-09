using System;

namespace SklepLibrary.Dzialy
{
    public class PieczywaDzial : Dzial
    {
        public PieczywaDzial() : base("Dział Pieczywa", new Produkt[]
        {
            new Produkt("Chleb", 40, 3m),
            new Produkt("Bułka", 80, 1m),
            new Produkt("Bagietka", 30, 2.5m),
            new Produkt("Rogal", 20, 1.5m),
            new Produkt("Tosty", 25, 2m)
        })
        { }
    }
}