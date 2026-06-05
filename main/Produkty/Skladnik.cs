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
        if (ile > ilosc)
            throw new InvalidOperationException($"Za mało {nazwa}: mamy {ilosc} {miara}, potrzeba {ile}");
        ilosc -= ile;
    }

    public void Uzupelnij(decimal ile)
    {
        if (ile <= 0)
            throw new ArgumentException("Ilość uzupełnienia musi być większa od zera");
        ilosc += ile;
    }
}
