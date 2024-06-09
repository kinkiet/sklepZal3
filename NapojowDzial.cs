using System;

namespace SklepLibrary.Dzialy
{
    public class NapojowDzial : Dzial
    {
        public NapojowDzial() : base("Dział Napojów", new Produkt[]
        {
            new Produkt("Woda", 100, 1m),
            new Produkt("Sok", 50, 2.5m),
            new Produkt("Cola", 30, 3m),
            new Produkt("Herbata", 40, 2m),
            new Produkt("Kawa", 25, 4m)
        })
        { }
    }
}
