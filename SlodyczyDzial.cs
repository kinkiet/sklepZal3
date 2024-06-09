using System;

namespace SklepLibrary.Dzialy
{
    public class SlodyczyDzial : Dzial
    {
        public SlodyczyDzial() : base("Dział Słodyczy", new Produkt[]
        {
            new Produkt("Czekolada", 50, 2.5m),
            new Produkt("Cukierki", 60, 1.5m),
            new Produkt("Ciastka", 40, 3m),
            new Produkt("Baton", 30, 2m),
            new Produkt("Wafle", 20, 1.8m)
        })
        { }
    }
}