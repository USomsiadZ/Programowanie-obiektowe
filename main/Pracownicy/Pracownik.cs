namespace ZamowieniaApp.Pracownicy;

public abstract class Pracownik
{
    protected int id;
    protected string imie;
    protected decimal pensja;
    
    public int readId => id;
    public string readImie => imie;
    public decimal readPensja => pensja;

    protected Pracownik(int id, string imie, decimal pensja)
    {
        this.id = id;
        this.imie = imie;
        this.pensja = pensja;
    }

    public abstract void Pracuj();

    public override string ToString()
    {
        return $"Imię: {imie}, Stanowisko: {this.GetType().Name}, Pensja: {pensja} zł";
    }
}
