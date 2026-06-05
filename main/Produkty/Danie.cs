namespace ZamowieniaApp.Produkty;

public class Danie : Produkt
{
    private int czas;
    private bool gotowe;

    public string readNazwa => nazwa;
    public decimal readBazowa => bazowa;
    public int readCzas => czas;
    public bool readGotowe => gotowe;

    public Danie(string nazwa, decimal bazowa, int czas)
        : base(nazwa, bazowa)
    {
        this.czas = czas;
        this.gotowe = false;
    }


    public void Przygotuj()
    {
        gotowe = true;
    }

    public override decimal Cena()
    {
        return bazowa;
    }
}
