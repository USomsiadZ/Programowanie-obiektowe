using ZamowieniaApp.Pracownicy;
using ZamowieniaApp.Rabaty;
using ZamowieniaApp.Sala;

namespace ZamowieniaApp.Zamowienia;

public class Zamowienie
{
    private int id;
    private DateTime data;
    private decimal suma;
    private Status stan;
    private List<Pozycja> pozycje;
    private Stolik stolik;
    private Kelner kelner;

    public int readId => id;
    public DateTime readData => data;
    public decimal readSuma => suma;
    public Status readStan => stan;
    public List<Pozycja> readPozycje => pozycje;
    public Stolik readStolik => stolik;
    public Kelner readKelner => kelner;

    public Zamowienie(int id, Stolik stolik, Kelner kelner)
    {
        this.id = id;
        this.data = DateTime.Now;
        this.stolik = stolik;
        this.kelner = kelner;
        this.pozycje = new List<Pozycja>();
        this.stan = Status.Nowe;
    }

    public void Dodaj(Pozycja pozycja)
    {
    }

    public void Usun(Pozycja pozycja)
    {
    }

    public void Zatwierdz()
    {
    }

    public decimal Oplac(Rabat rabat)
    {
        return 0;
    }

    public decimal Podsumuj()
    {
        return 0;
    }

    public int LiczbaPozycji()
    {
        return 0;
    }

    public void ZmienStan(Status nowy)
    {
    }
}
