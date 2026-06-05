namespace ZamowieniaApp.Pracownicy;

public abstract class Pracownik
{
    protected int id;
    protected string imie;
    protected decimal pensja;

    protected Pracownik(int id, string imie, decimal pensja)
    {
        this.id = id;
        this.imie = imie;
        this.pensja = pensja;
    }

    protected abstract void Pracuj();

    public override string ToString()
    {
        return imie;
    }
}
