using ZamowieniaApp.Sala;
using ZamowieniaApp.Zamowienia;

namespace ZamowieniaApp.Pracownicy;

public class Kelner : Pracownik
{
    private int rewir;
    private List<Zamowienie> zamowienia;

    public int readId => id;
    public string readImie => imie;
    public decimal readPensja => pensja;
    public int readRewir => rewir;
    public List<Zamowienie> readZamowienia => zamowienia;

    public Kelner(int id, string imie, decimal pensja, int rewir)
        : base(id, imie, pensja)
    {
        this.rewir = rewir;
        this.zamowienia = new List<Zamowienie>();
    }

    public Zamowienie Obsluz(Stolik stolik)
    {
        return null!;
    }

    public int LiczbaAktywnychZamowien()
    {
        return 0;
    }

    protected override void Pracuj()
    {
    }
}
