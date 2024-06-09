using System;

namespace SklepLibrary.Dzialy
{
    public class ChemiiDzial : Dzial
    {
        public ChemiiDzial() : base("Dział Chemii Gospodarczej", new Produkt[]
        {
            new Produkt("Proszek do prania", 20, 15m),
            new Produkt("Płyn do mycia naczyń", 30, 5m),
            new Produkt("Środek do czyszczenia", 25, 7m),
            new Produkt("Płyn do płukania", 15, 10m),
            new Produkt("Worki na śmieci", 50, 2m)
        })
        { }
    }
}