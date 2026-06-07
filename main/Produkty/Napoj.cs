namespace ZamowieniaApp.Produkty;

public class Napoj : Produkt
{
    private double litraz;
    private bool schlodzony;

    //public override string nazwa { get; set; }

    public string readNazwa => nazwa;
    public decimal readBazowa => bazowa;
    public double readLitraz => litraz;
    public bool readSchlodzony => schlodzony;

    public Napoj(string nazwa, decimal bazowa, double litraz)
        : base(nazwa, bazowa)
    {
        this.litraz = litraz;
        this.schlodzony = false;
    }

    public void Schlodz()
    {
        if (schlodzony)
        {
            Console.WriteLine("Napój jest już schłodzony.");
            return;
        }
        schlodzony = true;
        Console.WriteLine("Napój został schłodzony.");
    }

    public override decimal Cena()
    {
        return bazowa;
    }
}
