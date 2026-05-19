using ZamowieniaApp.Pracownicy;
using ZamowieniaApp.Sala;

namespace ZamowieniaApp;

public class Restauracja
{
    private string nazwa;
    private bool czyOtwarta;
    private List<Pracownik> pracownicy;
    private List<Stolik> stoliki;

    public string readNazwa => nazwa;
    public bool readCzyOtwarta => czyOtwarta;
    public List<Pracownik> readPracownicy => pracownicy;
    public List<Stolik> readStoliki => stoliki;

    public Restauracja(string nazwa)
    {
        this.nazwa = nazwa;
        this.pracownicy = new List<Pracownik>();
        this.stoliki = new List<Stolik>();
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

    public Stolik? ZnajdzWolnyStolik(int miejsca)
    {
        return null;
    }
}
