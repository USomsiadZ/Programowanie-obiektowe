using ZamowieniaApp.Pracownicy;
using ZamowieniaApp.Sala;
using ZamowieniaApp.Zamowienia;

namespace ZamowieniaApp;

public class Restauracja
{
    private string nazwa;
    private bool czyOtwarta;
    private List<Pracownik> pracownicy;
    private List<Stolik> stoliki;
    private List<Zamowienie> zamowienia;

    public string readNazwa => nazwa;
    public bool readCzyOtwarta => czyOtwarta;
    public List<Pracownik> readPracownicy => pracownicy;
    public List<Stolik> readStoliki => stoliki;
    public List<Zamowienie> readZamowienia => zamowienia;

    public Restauracja(string nazwa)
    {
        this.nazwa = nazwa;
        this.pracownicy = new List<Pracownik>();
        this.stoliki = new List<Stolik>();
        this.zamowienia = new List<Zamowienie>();
    }

    public void Otworz()
    {
    }

    public void Zamknij()
    {
    }

    public void Zatrudnij(Pracownik pracownik)
    {
    }

    public void Zwolnij(Pracownik pracownik)
    {
    }

    public void DodajStolik(Stolik stolik)
    {
    }

    public void PrzyjmijZamowienie(Zamowienie zamowienie)
    {
    }

    public Stolik? ZnajdzWolnyStolik(int miejsca)
    {
        return null;
    }
}
