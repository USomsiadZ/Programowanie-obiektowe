namespace ZamowieniaApp.Produkty;

public class Napoj : Produkt
{
    private decimal Litraz { get; }

    public Napoj(string nazwa, decimal bazowa, decimal litraz)
        : base(nazwa, bazowa)
    {
    }

    public void Schlodz()
    {
    }

    protected override decimal Cena()
    {
        return 0;
    }
}
