using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        List<Dzial> dzialy = new List<Dzial>
        {
            new NabialowyDzial(),
            new MiesnyDzial(),
            new WarzywnyDzial(),
            new OwocowyDzial(),
            new PieczywaDzial(),
            new MrozonekDzial(),
            new SlodyczyDzial(),
            new NapojowDzial(),
            new ChemiiDzial()
        };

        dzialy[0].WyswietlProdukty(); 
        Menu(dzialy);
    }

    public static void Menu(List<Dzial> dzialy)
    {
        Console.WriteLine("Witaj w naszym sklepie!\n");
        Console.WriteLine("1 - Wejdź do sklepu");
        Console.WriteLine("2 - Pokaż koszyk");
        Console.WriteLine("3 - Idź do kasy");
        Console.WriteLine("4 - Magazyn");
        Console.WriteLine("5 - Wyjście");

        Console.Write("Wybierz opcję: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                wybieranieDzialu(dzialy);
                break;
            //case "2":
            //    pokazKoszyk();
            //    break;
            //case "3":
            //    kasa();
            //    break;
            case "4":
                // magazyn();
                break;
            case "5":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Niepoprawny wybór.");
                break;
        }
    }

    public static void wybieranieDzialu(List<Dzial> dzialy)
    {
        Console.WriteLine("Wybierz dział:\n");
        Console.WriteLine("1 - Nabiał");
        Console.WriteLine("2 - Mięsny");
        Console.WriteLine("3 - Warzywny");
        Console.WriteLine("4 - Owocowy");
        Console.WriteLine("5 - Pieczywa");
        Console.WriteLine("6 - Mrożonki");
        Console.WriteLine("7 - Słodycze");
        Console.WriteLine("8 - Napoje");
        Console.WriteLine("9 - Chemia Gospodarcza");
        Console.WriteLine("0 - Wyjście");

        Console.Write("Wybierz opcję: ");
        string choiceD = Console.ReadLine();

        Dzial selectedDzial = choiceD switch
        {
            "1" => dzialy.OfType<NabialowyDzial>().FirstOrDefault(),
            "2" => dzialy.OfType<MiesnyDzial>().FirstOrDefault(),
            "3" => dzialy.OfType<WarzywnyDzial>().FirstOrDefault(),
            "4" => dzialy.OfType<OwocowyDzial>().FirstOrDefault(),
            "5" => dzialy.OfType<PieczywaDzial>().FirstOrDefault(),
            "6" => dzialy.OfType<MrozonekDzial>().FirstOrDefault(),
            "7" => dzialy.OfType<SlodyczyDzial>().FirstOrDefault(),
            "8" => dzialy.OfType<NapojowDzial>().FirstOrDefault(),
            "9" => dzialy.OfType<ChemiiDzial>().FirstOrDefault(),
            "0" => null,
            _ => null
        };

        if (selectedDzial != null)
        {
            selectedDzial.WyswietlProdukty();
            Koszyk.zakupy(dzialy, selectedDzial);
        }
        else
        {
            Menu(dzialy); 
        }
        //Koszyk.zakupy(dzialy);
    }
}

public class Produkt
{
    public string Nazwa { get; set; }
    public int Ilosc { get; set; }
    public decimal Cena { get; set; }

    public Produkt(string nazwa, int ilosc, decimal cena)
    {
        Nazwa = nazwa;
        Ilosc = ilosc;
        Cena = cena;
    }

    public override string ToString()
    {
        return $"{Nazwa} - {Ilosc} sztuk - {Cena:C}";
    }
}

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
        foreach (var produkt in Produkty)
        {
            Console.WriteLine($"    {produkt}");
        }
        Console.WriteLine();
    }
}

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

public class OwocowyDzial : Dzial
{
    public OwocowyDzial() : base("Dział Owocowy", new Produkt[]
    {
        new Produkt("Truskawki", 25, 3m),
        new Produkt("Winogrona", 20, 4m),
        new Produkt("Pomarańcze", 30, 2m),
        new Produkt("Ananas", 15, 3m),
        new Produkt("Gruszki", 20, 2m)
    })
    { }
}

public class PieczywaDzial : Dzial
{
    public PieczywaDzial() : base("Dział Pieczywa", new Produkt[]
    {
        new Produkt("Bułki", 100, 1m),
        new Produkt("Bagietki", 30, 1m),
        new Produkt("Rogale", 50, 1m),
        new Produkt("Chleb", 20, 2m),
        new Produkt("Drożdżówki", 40, 2m)
    })
    { }
}

public class MrozonekDzial : Dzial
{
    public MrozonekDzial() : base("Dział Mrożonek", new Produkt[]
    {
        new Produkt("Pizza", 30, 3m),
        new Produkt("Lody", 20, 5m),
        new Produkt("Warzywa", 50, 2m),
        new Produkt("Frytki", 40, 2m),
        new Produkt("Filety", 25, 4m)
    })
    { }
}

public class SlodyczyDzial : Dzial
{
    public SlodyczyDzial() : base("Dział Słodyczy", new Produkt[]
    {
        new Produkt("Czekolada", 100, 2m),
        new Produkt("Batoniki", 200, 1m),
        new Produkt("Ciastka", 50, 2m),
        new Produkt("Żelki", 100, 1m),
        new Produkt("Lizaki", 150, 1m)
    })
    { }
}

public class NapojowDzial : Dzial
{
    public NapojowDzial() : base("Dział Napojów", new Produkt[]
    {
        new Produkt("Woda", 200, 1m),
        new Produkt("Cola", 100, 2m),
        new Produkt("Sok", 50, 2m),
        new Produkt("Piwo", 100, 2m),
        new Produkt("Wino", 50, 10m)
    })
    { }
}

public class ChemiiDzial : Dzial
{
    public ChemiiDzial() : base("Dział Chemii Gospodarczej", new Produkt[]
    {
        new Produkt("PłynDoNaczyń", 50, 2m),
        new Produkt("ProszekDoPrania", 30, 8m),
        new Produkt("PłynDoPodłóg", 40, 3m),
        new Produkt("PapierToaletowy", 100, 2m),
        new Produkt("WorkiNaŚmieci", 50, 1m)
    })
    { }
}

public class Koszyk
{
    public static List<Produkt> koszyk = new List<Produkt>();
    public static void zakupy(List<Dzial> dzialy, Dzial dzial)
    {
        
        Console.WriteLine("Czy chcesz coś stąd wsadzić do koszyka? \n y-tak n-nie\n");
        string za = Console.ReadLine();
        switch (za)
        {
            case "y":
                wybierzProdukt(dzialy, dzial);
                break;
            case "n":
                Program.wybieranieDzialu(dzialy);
                break;
            default:
                Console.WriteLine("wpisano niepoprawną opcję");
                zakupy(dzialy, dzial);
                break;
        }
   
            
    }
    public static void wybierzProdukt(List <Dzial> dzialy, Dzial dzial)
    {


        Console.Write("Wybierz produkt (numer): ");
        if (int.TryParse(Console.ReadLine(), out int productIndex) && productIndex >= 0 && productIndex < dzial.Produkty.Length)
        {

            Produkt wybranyProdukt = dzial.Produkty[productIndex];
            Console.Write("Podaj ilość: ");
            if (int.TryParse(Console.ReadLine(), out int amount))
            {
                int wybranaIlosc = wybranyProdukt.Ilosc;

                if (amount > wybranaIlosc)
                {
                    Console.WriteLine("Nie ma wystarczającej ilości produktu.");
                    wybierzProdukt(dzialy, dzial); 
                }
                else
                {
                    wybranyProdukt.Ilosc -= amount; // Zmniejszamy ilość produktu w magazynie
                    koszyk.Add(new Produkt(wybranyProdukt.Nazwa, amount, wybranyProdukt.Cena));
                    Console.WriteLine($"{amount} sztuk {wybranyProdukt.Nazwa} zostało dodanych do koszyka.");
                    zakupy(dzialy, dzial);
                }
            }
        else
        {
            Console.WriteLine("Niepoprawny wybór produktu.");
            wybierzProdukt(dzialy, dzial);
        }
        
        
           
        
    }
        




    }

}


