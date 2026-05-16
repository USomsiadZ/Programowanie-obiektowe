using ZamowieniaApp.Produkty;

namespace ZamowieniaApp.Pracownicy;

public class Kucharz : Pracownik
{
    private string sekcja;

    public int readId => id;
    public string readImie => imie;
    public decimal readPensja => pensja;
    public string readSekcja => sekcja;

    public Kucharz(int id, string imie, decimal pensja, string sekcja)
        : base(id, imie, pensja)
    {
        this.sekcja = sekcja;
    }

    public void Gotuj(Danie danie)
    {
    }

    public bool Sprawdz(Danie danie)
    {
        return false;
    }

    public bool MaSkladniki(Danie danie)
    {
        return false;
    }

    protected override void Pracuj()
    {
    }
}
