namespace ZamowieniaApp.Produkty;

public class Skladnik
{
    private string nazwa;
    private string miara;
    private decimal ilosc;

    public string readNazwa => nazwa;
    public string readMiara => miara;
    public decimal readIlosc => ilosc;

    public Skladnik(string nazwa, string miara, decimal ilosc)
    {
        this.nazwa = nazwa;
        this.miara = miara;
        this.ilosc = ilosc;
    }

    public void Zuzyj(decimal ile)
    {
    }

    public void Uzupelnij(decimal ile)
    {
    }
}
