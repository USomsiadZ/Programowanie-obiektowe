using ZamowieniaApp.Zamowienia;

namespace ZamowieniaApp.Pracownicy;

public class Kelner : Pracownik
{
    private int rewir;
    private List<Zamowienie> zamowienia;
    public int readRewir => rewir;
    public List<Zamowienie> readZamowienia => zamowienia;

    public Kelner(int id, string imie, decimal pensja, int rewir)
        : base(id, imie, pensja)
    {
        this.rewir = rewir;
        this.zamowienia = new List<Zamowienie>();
    }


    public int LiczbaAktywnychZamowien()
    {
        int liczba = 0;
        foreach (var zamowienie in zamowienia)
        {
            if (zamowienie.readStan != Status.Zakonczone)
            {
                liczba++;
            }
        }
        return liczba;
    }

    public override void Pracuj()
    {
        Console.WriteLine($"{imie} obsługuje rewir {rewir}");
    }
}
