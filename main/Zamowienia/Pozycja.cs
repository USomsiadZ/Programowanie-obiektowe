using ZamowieniaApp.Produkty;

namespace ZamowieniaApp.Zamowienia;

public class Pozycja
{
    private int Ilosc { get; set; }
    private decimal Cena { get; }
    private Produkt Produkt { get; }

    public Pozycja(Produkt produkt, int ilosc)
    {
    }

    public decimal Sumuj()
    {
        return 0;
    }

    public void Rabatuj()
    {
    }
}
