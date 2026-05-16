using ZamowieniaApp.Sala;
using ZamowieniaApp.Zamowienia;

namespace ZamowieniaApp.Pracownicy;

public class Kelner : Pracownik
{
    private int Rewir { get; }
    private List<Zamowienie> Zamowienia { get; }

    public Kelner(int id, string imie, decimal pensja, int rewir)
        : base(id, imie, pensja)
    {
    }

    public Zamowienie Obsluz(Stolik stolik)
    {
        return null!;
    }

    public decimal Inkasuj(Zamowienie zamowienie)
    {
        return 0;
    }

    protected override void Pracuj()
    {
    }
}
