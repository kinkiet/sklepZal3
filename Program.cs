using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

public class Program
{
    private static List<Koszyk> koszyk = new List<Koszyk>();
    public static void Main(string[] args)
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
            case "2":
                pokazKoszyk();
                break;
            case "3":
                kasa();
                break;
            case "4":
                magazyn();
                break;
            case "5":
                Environment.Exit(0); 
                break;
            default:
                Console.WriteLine("Niepoprawny wybór.");
                break;
        }
       
    }
    private static void wybieranieDzialu()
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

        switch (choiceD)
        {
            case "1":
                wybieranieDzialu();
                break;
            case "2":
                pokazKoszyk();
                break;
            case "3":
                kasa();
                break;
            case "4":
                magazyn();
                break;
            case "5":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Niepoprawny wybór.");
                break;

        }
    private static void pokazKoszyk()
    {

    }
    private static void kasa()
    {

    }
    private static void magazyn()
    {

    }
}

