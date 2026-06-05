using ZamowieniaApp.Produkty;
using ZamowieniaApp.Rabaty;

namespace ZamowieniaApp.Zamowienia;

public class Pozycja
{
    private int ilosc;
    private decimal cena;
    private Produkt produkt;

    public int readIlosc => ilosc;
    public decimal readCena => cena;
    public Produkt readProdukt => produkt;

    public Pozycja(Produkt produkt, int ilosc)
    {
        this.produkt = produkt;
        this.ilosc = ilosc;
        this.cena = produkt.Cena();
    }

    public decimal Sumuj()
    {
        return ilosc * cena;
    }

    public void Rabatuj(Rabat rabat)
    {
        cena = rabat.Oblicz(cena);
    }
}
