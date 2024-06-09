using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SklepLibrary.Dzialy
    {
        public class NabialowyDzial : Dzial
        {
            public NabialowyDzial() : base("Dział Nabiałowy", new Produkt[]
            {
            new Produkt("Masło", 15, 2.5m),
            new Produkt("Ser", 10, 4m),
            new Produkt("Śmietana", 20, 1m),
            new Produkt("Mleko", 10, 1.5m),
            new Produkt("Kefir", 12, 1.2m)
            })
            { }
        }
    }


