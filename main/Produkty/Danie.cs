namespace ZamowieniaApp.Produkty;

public class Danie : Produkt
{
    private int Czas { get; }
    private List<Skladnik> Skladniki { get; }

    public Danie(string nazwa, decimal bazowa, int czas)
        : base(nazwa, bazowa)
    {
    }

    public void Przygotuj()
    {
    }

    protected override decimal Cena()
    {
        return 0;
    }
}
