namespace ZamowieniaApp.Produkty;

public class Danie : Produkt
{
    private int czas;
    private List<Skladnik> skladniki;
    private bool gotowe;

    public string readNazwa => nazwa;
    public decimal readBazowa => bazowa;
    public int readCzas => czas;
    public List<Skladnik> readSkladniki => skladniki;
    public bool readGotowe => gotowe;

    public Danie(string nazwa, decimal bazowa, int czas)
        : base(nazwa, bazowa)
    {
        this.czas = czas;
        this.skladniki = new List<Skladnik>();
    }

    public void Przygotuj()
    {
    }

    public override decimal Cena()
    {
        return 0;
    }
}
