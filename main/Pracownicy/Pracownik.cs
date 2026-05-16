namespace ZamowieniaApp.Pracownicy;

public abstract class Pracownik
{
    protected int Id { get; }
    protected string Imie { get; }
    protected decimal Pensja { get; set; }

    protected Pracownik(int id, string imie, decimal pensja)
    {
    }

    protected abstract void Pracuj();
}
