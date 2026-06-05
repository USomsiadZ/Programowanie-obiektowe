using ZamowieniaApp.Pracownicy;
using ZamowieniaApp.Produkty;
using ZamowieniaApp.Rabaty;
using ZamowieniaApp.Sala;
using ZamowieniaApp.Zamowienia;

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
        if (czyOtwarta)
        {
            Console.WriteLine("Błąd: Restauracja jest już otwarta!"); // zmienic na blad
        }
        else
        {
            czyOtwarta = true;
            Console.WriteLine("Restauracja została otwarta!");
        }
    }

    public void Zamknij()
    {
        if (czyOtwarta)
        {
            czyOtwarta = false;
            Console.WriteLine("Restauracja została zamknięta."); // zmienic na blad
        }
        else
        {
            Console.WriteLine("Restauracja jest już zamknięta!");
        }
    }

    public void Zatrudnij(Pracownik pracownik)
    {
        if (pracownik == null)
        {
            throw new ArgumentNullException(nameof(pracownik));
        }
        if (!pracownicy.Contains(pracownik))
        {
            pracownicy.Add(pracownik);
            Console.WriteLine($"Pomyslnie zatrudniono {pracownik}");
        }

    }

    public void Zwolnij(Pracownik pracownik)
    {
        if (pracownik == null) throw new ArgumentNullException(nameof(pracownik));
        pracownicy.Remove(pracownik);
    }

    public void DodajStolik(Stolik stolik)
    {
        if (stolik == null) throw new ArgumentNullException(nameof(stolik));
        if (!stoliki.Contains(stolik))
        {
            stoliki.Add(stolik);
        }
    }

    public Stolik? ZnajdzWolnyStolik(int miejsca)
    {
        foreach (var stolik in stoliki)
        {
            if (stolik.CzyWolny() && stolik.readMiejsca >= miejsca)
            {
                return stolik;
            }
        }
        return null;
    }

    public static void Main(string[] args)
    {
        var menu = new Menu();
        menu.Uruchom();
    }
}