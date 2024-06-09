using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SklepLibrary
{
    public static class Kasa
    {
        public static decimal ObliczLacznaCene()
        {
            return Koszyk.koszyk.Sum(p => p.Cena * p.Ilosc);
        }

        public static void rachunek()
        {
            try
            {
                List<string> rachunekZawartosc = new List<string>();

                foreach (var produkt in Koszyk.koszyk)
                {
                    string produktInfo = produkt.ToString();
                    Console.WriteLine(produktInfo);
                    rachunekZawartosc.Add(produktInfo);
                }

                string lacznaCena = $"Łączna cena: {ObliczLacznaCene():C}";
                Console.WriteLine(lacznaCena);
                rachunekZawartosc.Add(lacznaCena);

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string fileName = $"rachunek_{timestamp}.txt";

                while (true)
                {
                    Console.WriteLine("Czy chcesz zachować rachunek?\n y- tak n - nie");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "y":
                            File.WriteAllLines(fileName, rachunekZawartosc);
                            Console.WriteLine($"Rachunek został zapisany do pliku '{fileName}'.");
                            break;
                        case "n":
                            return;
                        default:
                            Console.WriteLine("Nieprawidłowy wybór.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
            }
        }
    }
}