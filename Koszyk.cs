using System;
using System.Collections.Generic;
using System.Linq;

namespace SklepLibrary
{
    public static class Koszyk
    {
        public static List<Produkt> koszyk = new List<Produkt>();

        public static void zakupy(List<Dzial> dzialy, Dzial dzial)
        {
            try
            {
                Console.WriteLine("Czy chcesz coś stąd wsadzić do koszyka? \n y-tak n-nie\n");
                string za = Console.ReadLine();
                switch (za)
                {
                    case "y":
                        wybierzProdukt(dzialy, dzial);
                        break;
                    case "n":
                        Fix.wybieranieDzialu(dzialy);
                        break;
                    default:
                        Console.WriteLine("Wpisano niepoprawną opcję");
                        zakupy(dzialy, dzial);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
            }
        }

        public static void wybierzProdukt(List<Dzial> dzialy, Dzial dzial)
        {
            try
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
                            wybranyProdukt.Ilosc -= amount;
                            koszyk.Add(new Produkt(wybranyProdukt.Nazwa, amount, wybranyProdukt.Cena));
                            Console.WriteLine($"{amount} sztuk {wybranyProdukt.Nazwa} zostało dodanych do koszyka.");
                            zakupy(dzialy, dzial);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawna ilość.");
                        wybierzProdukt(dzialy, dzial);
                    }
                }
                else
                {
                    Console.WriteLine("Niepoprawny wybór produktu.");
                    wybierzProdukt(dzialy, dzial);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
            }
        }

        public static void PokazKoszyk()
        {
            try
            {
                if (koszyk.Count == 0)
                {
                    Console.WriteLine("Koszyk jest pusty.");
                }
                else
                {
                    Console.WriteLine("Zawartość koszyka:");
                    foreach (var produkt in koszyk)
                    {
                        Console.WriteLine(produkt);
                    }
                }
                Console.WriteLine("Czy chcesz coś wyjąć z koszyka? y-tak n-nie:\n");
                string remove = Console.ReadLine();

                switch (remove)
                {
                    case "y":
                        UsunZKoszyka();
                        break;
                    case "n":
                        Fix.Menu(new List<Dzial>());
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór.");
                        PokazKoszyk();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
            }
        }

        public static void UsunZKoszyka()
        {
            try
            {
                if (koszyk.Count > 0)
                {
                    Console.Write("Wybierz produkt do usunięcia (numer): ");
                    if (int.TryParse(Console.ReadLine(), out int productIndex) && productIndex >= 0 && productIndex < koszyk.Count)
                    {
                        Produkt usunietyProdukt = koszyk[productIndex];
                        koszyk.RemoveAt(productIndex);
                        Console.WriteLine($"{usunietyProdukt.Nazwa} został usunięty z koszyka.");
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawny wybór.");
                    }
                }
                PokazKoszyk();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
            }
        }
    }
}
