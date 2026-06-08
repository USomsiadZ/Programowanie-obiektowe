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
		this.suma = 0;
    }

    public void Dodaj(Pozycja pozycja)
    {
		pozycje.Add(pozycja);
		suma = Podsumuj();
    }

    public void Usun(Pozycja pozycja)
    {
		pozycje.Remove(pozycja);
        suma = Podsumuj();
    }

    public void Zatwierdz()
    {
		stan = Status.Przygotowanie;
    }

    public decimal Oplac(Rabat rabat)
    {
		var podsumowanie = Podsumuj();
		suma = rabat.Oblicz(podsumowanie);
		stan = Status.Zakonczone;
		return suma;
    }

    public decimal Podsumuj()
    {
		decimal kwota = 0;
		foreach (var pozycja in pozycje) {
		kwota += pozycja.Sumuj();
		}
        return kwota;
    }

    public int LiczbaPozycji()
    {
        return pozycje.Count;
    }

    public void ZmienStan(Status nowy)
    {
		stan = nowy;  
    }
    
    public void AktualizujSume()
    {
	    suma = Podsumuj();
    }
}
