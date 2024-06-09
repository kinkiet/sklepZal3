using System;

namespace SklepLibrary.Dzialy
{
    public class MrozonekDzial : Dzial
    {
        public MrozonekDzial() : base("Dział Mrożonek", new Produkt[]
        {
            new Produkt("Pizza mrożona", 15, 5m),
            new Produkt("Frytki mrożone", 20, 3m),
            new Produkt("Lody", 25, 4m),
            new Produkt("Mrożone warzywa", 30, 2m),
            new Produkt("Mrożone owoce", 10, 3.5m)
        })
        { }
    }

}