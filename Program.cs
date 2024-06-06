using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

public class Program
{
    //private static List<Koszyk> koszyk = new List<Koszyk>();
    public static void Main(string[] args)
    {

        Menu();


    }


    private static void Menu()
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
                wybieranieDzialu();
                break;
            //case "2":
            //    pokazKoszyk();
            //    break;
            //case "3":
            //    kasa();
            //    break;
            //case "4":
            //    magazyn();
            //    break;
            case "5":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Niepoprawny wybór.");
                break;

        }



        static void wybieranieDzialu()
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

            List<string> magazynL = new List<string>();

            try
            {

                if (File.Exists(path))
                {
                    magazynL = new List<string>(File.ReadAllLines(path));
                }
                else
                {
                    Console.WriteLine("Plik nie istnieje.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd podczas odczytu pliku: " + ex.Message);
            }

            switch (choiceD)
            {
                case "1":
                    int[] dzial1 = { 1, 2, 3, 4, 5, 6, 7 };
                    ZawartoscDzialu(magazynL, dzial1);
                    break;
                case "2":
                    int[] dzial2 = { 9, 10, 11, 12, 13, 14, 15 };
                    ZawartoscDzialu(magazynL, dzial2);
                    break;
                case "3":
                    int[] dzial3 = { 17, 18, 19, 20, 21, 22, 23 };
                    ZawartoscDzialu(magazynL, dzial3);
                    break;
                case "4":
                    int[] dzial4 = { 25, 26, 27, 28, 29, 30, 31 };
                    ZawartoscDzialu(magazynL, dzial4);
                    break;
                case "5":
                    int[] dzial5 = { 33, 34, 35, 36, 37, 38, 39 };
                    ZawartoscDzialu(magazynL, dzial5);
                    break;
                case "6":
                    int[] dzial6 = { 41, 42, 43, 44, 45, 46, 47 };
                    ZawartoscDzialu(magazynL, dzial6);
                    break;
                case "7":
                    int[] dzial7 = { 49, 50, 51, 52, 53, 54, 55 };
                    ZawartoscDzialu(magazynL, dzial7);
                    break;
                case "8":
                    int[] dzial8 = { 57, 58, 59, 60, 61, 62, 63 };
                    ZawartoscDzialu(magazynL, dzial8);
                    break;
                case "9":
                    int[] dzial9 = { 65, 66, 67, 68, 69, 70, 71 };
                    ZawartoscDzialu(magazynL, dzial9);
                    break;
                case "0":

                    Menu(); 
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
            //private static void magazyn()
            //{

            //}
        }
    }
}

