namespace ZamowieniaApp.Produkty;

public class Napoj : Produkt
{
    private decimal litraz;
    private bool schlodzony;
    public string readNazwa => nazwa;
    public decimal readBazowa => bazowa;
    public decimal readLitraz => litraz;
    public bool readSchlodzony => schlodzony;

    public Napoj(string nazwa, decimal bazowa, decimal litraz)
        : base(nazwa, bazowa)
    {
        this.litraz = litraz;
        this.schlodzony = false;
    }

    public void Schlodz()
    {
        if (schlodzony)
        {
            Console.WriteLine("Napój został już schłodzony");
            return;
        }
        schlodzony = true;
        Console.WriteLine("Napój został schłodzony");
    }

    public override decimal Cena()
    {
        return bazowa;
    }
}
