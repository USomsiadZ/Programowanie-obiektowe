namespace ZamowieniaApp.Produkty;

public abstract class Produkt
{
    protected string nazwa;
    protected decimal bazowa;

    protected Produkt(string nazwa, decimal bazowa)
    {
        this.nazwa = nazwa;
        this.bazowa = bazowa;
    }

    public abstract decimal Cena(); // czy tu powinno byc protected?
}
