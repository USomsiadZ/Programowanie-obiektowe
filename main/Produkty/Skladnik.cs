namespace ZamowieniaApp.Produkty;

public class Skladnik
{
    private string Nazwa { get; }
    private string Miara { get; }
    private decimal Ilosc { get; set; }

    public Skladnik(string nazwa, string miara, decimal ilosc)
    {
    }

    public void Zuzyj(decimal ile)
    {
    }

    public void Uzupelnij(decimal ile)
    {
    }
}
