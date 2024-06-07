using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

public class Program
{
    //private static List<Koszyk> koszyk = new List<Koszyk>();
    public static void Main(string[] args)
    {
        Dzial dzialNabialowy = new Dzial("Dział Nabiałowy", new Produkt[]
        {
            new Produkt("Masło", 15, 2.5m),
            new Produkt("Ser", 10, 4m),
            new Produkt("Śmietana", 20, 1m),
            new Produkt("Mleko", 10, 1.5m),
            new Produkt("Kefir", 12, 1.2m)
        });

        Dzial dzialMiesny = new Dzial("Dział Mięsny", new Produkt[]
        {
            new Produkt("Kurczak", 30, 4m),
            new Produkt("Wołowina", 20, 6m),
            new Produkt("Szynka", 25, 5m),
            new Produkt("Boczek", 15, 7m),
            new Produkt("Kiełbasa", 40, 3m)
        });

        Dzial dzialWarzywny = new Dzial("Dział Warzywny", new Produkt[]
        {
            new Produkt("Pomidor", 50, 1m),
            new Produkt("Ogórek", 30, 1m),
            new Produkt("Marchew", 40, 1m),
            new Produkt("Ziemniaki", 100, 1m),
            new Produkt("Cebula", 50, 1m)
        });

        Dzial dzialOwocowy = new Dzial("Dział Owocowy", new Produkt[]
        {
            new Produkt("Truskawki", 25, 3m),
            new Produkt("Winogrona", 20, 4m),
            new Produkt("Pomarańcze", 30, 2m),
            new Produkt("Ananas", 15, 3m),
            new Produkt("Gruszki", 20, 2m)
        });

        Dzial dzialPieczywa = new Dzial("Dział Pieczywa", new Produkt[]
        {
            new Produkt("Bułki", 100, 1m),
            new Produkt("Bagietki", 30, 1m),
            new Produkt("Rogale", 50, 1m),
            new Produkt("Chleb", 20, 2m),
            new Produkt("Drożdżówki", 40, 2m)
        });

        Dzial dzialMrozonek = new Dzial("Dział Mrożonek", new Produkt[]
        {
            new Produkt("Pizza", 30, 3m),
            new Produkt("Lody", 20, 5m),
            new Produkt("Warzywa", 50, 2m),
            new Produkt("Frytki", 40, 2m),
            new Produkt("Filety", 25, 4m)
        });

        Dzial dzialSlodyczy = new Dzial("Dział Słodyczy", new Produkt[]
        {
            new Produkt("Czekolada", 100, 2m),
            new Produkt("Batoniki", 200, 1m),
            new Produkt("Ciastka", 50, 2m),
            new Produkt("Żelki", 100, 1m),
            new Produkt("Lizaki", 150, 1m)
        });

        Dzial dzialNapojow = new Dzial("Dział Napojów", new Produkt[]
        {
            new Produkt("Woda", 200, 1m),
            new Produkt("Cola", 100, 2m),
            new Produkt("Sok", 50, 2m),
            new Produkt("Piwo", 100, 2m),
            new Produkt("Wino", 50, 10m)
        });

        Dzial dzialChemiiGospodarczej = new Dzial("Dział Chemii Gospodarczej", new Produkt[]
        {
            new Produkt("PłynDoNaczyń", 50, 2m),
            new Produkt("ProszekDoPrania", 30, 8m),
            new Produkt("PłynDoPodłóg", 40, 3m),
            new Produkt("PapierToaletowy", 100, 2m),
            new Produkt("WorkiNaŚmieci", 50, 1m)
        });
        var dzialy = new List<Dzial> { dzialNabialowy, dzialMiesny };
        dzialNabialowy.WyswietlProdukty();
        Menu(dzialy);
    }


    private static void Menu(List <Dzial> dzialy)
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

        

         void wybieranieDzialu(List <Dzial> dzialy)
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

            string path = "magazyn.txt";

            //List<string> magazynL = new List<string>();

            //try
            //{

            //    if (File.Exists(path))
            //    {
            //        magazynL = new List<string>(File.ReadAllLines(path));
            //    }
            //    else
            //    {
            //        Console.WriteLine("Plik nie istnieje.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Wystąpił błąd podczas odczytu pliku: " + ex.Message);
            //}

            switch (choiceD)
            {
                case "1":
                    var dzialNabialowy = dzialy.FirstOrDefault(d => d.Nazwa == "Dział Nabiałowy");

                    dzialNabialowy.WyswietlProdukty();
                    //int[] dzial1 = { 1, 2, 3, 4, 5, 6, 7 };
                    //ZawartoscDzialu(magazynL, dzial1);
                    break;
                //case "2":
                //    int[] dzial2 = { 9, 10, 11, 12, 13, 14, 15 };
                //    ZawartoscDzialu(magazynL, dzial2);
                //    break;
                //case "3":
                //    int[] dzial3 = { 17, 18, 19, 20, 21, 22, 23 };
                //    ZawartoscDzialu(magazynL, dzial3);
                //    break;
                //case "4":
                //    int[] dzial4 = { 25, 26, 27, 28, 29, 30, 31 };
                //    ZawartoscDzialu(magazynL, dzial4);
                //    break;
                //case "5":
                //    int[] dzial5 = { 33, 34, 35, 36, 37, 38, 39 };
                //    ZawartoscDzialu(magazynL, dzial5);
                //    break;
                //case "6":
                //    int[] dzial6 = { 41, 42, 43, 44, 45, 46, 47 };
                //    ZawartoscDzialu(magazynL, dzial6);
                //    break;
                //case "7":
                //    int[] dzial7 = { 49, 50, 51, 52, 53, 54, 55 };
                //    ZawartoscDzialu(magazynL, dzial7);
                //    break;
                //case "8":
                //    int[] dzial8 = { 57, 58, 59, 60, 61, 62, 63 };
                //    ZawartoscDzialu(magazynL, dzial8);
                //    break;
                //case "9":
                //    int[] dzial9 = { 65, 66, 67, 68, 69, 70, 71 };
                //    ZawartoscDzialu(magazynL, dzial9);
                    break;
                case "0":

                    Menu(dzialy);
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór.");
                    break;

            }

            static void ZawartoscDzialu(List<string> magazynL, int[] dzialy)
            {
                foreach (int index in dzialy)
                {
                    if (index >= 0 && index < magazynL.Count)
                    {
                        Console.WriteLine(magazynL[index]);
                    }
                    else
                    {
                        Console.WriteLine($"Indeks {index} jest poza zakresem.");
                    }
                }
            }

            static void Kupowanie()
            {


            }

            //private static void pokazKoszyk()
            //{

            //}
            //private static void kasa()
            //{

            //}

        }
    }
    

    static void Koszyk()
    {


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
    Dzial[] dzialy;

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

public class Zawartosc
{


}

public class Koszyk
{
    //public List<Zawartosc> Zawartosc { get; set; } = new List<Zawartosc>


}


