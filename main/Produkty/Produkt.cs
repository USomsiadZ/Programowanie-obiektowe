namespace ZamowieniaApp.Produkty;

public abstract class Produkt
{
    protected string Nazwa { get; }
    protected decimal Bazowa { get; }

    protected Produkt(string nazwa, decimal bazowa)
    {
    }

    protected abstract decimal Cena();
}
