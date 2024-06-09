namespace SklepLibrary
{
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
}