using SklepLibrary.Dzialy;
using SklepLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepLibrary
{
    public class Fix
    {
        public static void Menu(List<Dzial> dzialy)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Witaj w naszym sklepie!\n");
                    Console.WriteLine("1 - Wejdź do sklepu");
                    Console.WriteLine("2 - Pokaż koszyk");
                    Console.WriteLine("3 - Idź do kasy");
                    Console.WriteLine("4 - Wyjście");

                    Console.Write("Wybierz opcję: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            wybieranieDzialu(dzialy);
                            break;
                        case "2":
                            Koszyk.PokazKoszyk();
                            break;
                        case "3":
                            Kasa.rachunek();
                            break;
                        case "4":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Niepoprawny wybór.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                }
            }
        }

        public static void wybieranieDzialu(List<Dzial> dzialy)
        {
            try
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                Menu(dzialy);
            }
        }
    }


}

