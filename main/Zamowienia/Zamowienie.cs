using ZamowieniaApp.Pracownicy;
using ZamowieniaApp.Rabaty;
using ZamowieniaApp.Sala;

namespace ZamowieniaApp.Zamowienia;

public class Zamowienie
{
    private int Id { get; }
    private DateTime Data { get; }
    private decimal Suma { get; set; }
    private Status Stan { get; set; }
    private List<Pozycja> Pozycje { get; }
    private Stolik Stolik { get; }
    private Kelner Kelner { get; }

    public Zamowienie(int id)
    {
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
}
