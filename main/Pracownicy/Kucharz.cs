using ZamowieniaApp.Produkty;

namespace ZamowieniaApp.Pracownicy;

public class Kucharz : Pracownik
{
    private string Sekcja { get; }

    public Kucharz(int id, string imie, decimal pensja, string sekcja)
        : base(id, imie, pensja)
    {
    }

    public void Gotuj(Danie danie)
    {
    }

    public bool Sprawdz(Danie danie)
    {
        return false;
    }

    protected override void Pracuj()
    {
    }
}
