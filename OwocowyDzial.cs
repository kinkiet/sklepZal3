using System;

namespace SklepLibrary.Dzialy
{
    public class OwocowyDzial : Dzial
    {
        public OwocowyDzial() : base("Dział Owocowy", new Produkt[]
        {
            new Produkt("Jabłko", 100, 1.2m),
            new Produkt("Banan", 50, 1.5m),
            new Produkt("Pomarańcza", 70, 2m),
            new Produkt("Truskawki", 30, 3m),
            new Produkt("Gruszka", 60, 1.8m)
        })
        { }
    }
}