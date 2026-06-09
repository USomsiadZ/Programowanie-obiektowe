using ZamowieniaApp.Pracownicy;
using ZamowieniaApp.Produkty;
using ZamowieniaApp.Sala;
using ZamowieniaApp.Zamowienia;

namespace ZamowieniaApp.Menu;

public partial class Menu
{
    private Restauracja restauracja;
    private List<Produkt> oferta;
    private Zamowienie? zamowienie;
    private int kolejneId = 1;
    private int kolejneIdPracownika;

    public Menu()
    {
        restauracja = new Restauracja("U Łukaszka");
        restauracja.Zatrudnij(new Kelner(1, "Janek", 3000, 1));
        restauracja.Zatrudnij(new Kucharz(2, "Ania", 3500, "kuchnia"));
        restauracja.DodajStolik(new Stolik(1, 4));
        restauracja.DodajStolik(new Stolik(2, 2));
        
        kolejneIdPracownika = restauracja.readPracownicy.Count + 1;

        oferta = new List<Produkt>
        {
            new Danie("Pizza", 30, 15),
            new Danie("Pizza z szynką", 35, 15),
            new Napoj("Cola", 8, 0.5m),
            new Napoj("Piwo", 10, 0.5m),
            new Napoj("Woda", 5, 0.5m),
            new Napoj("Sok", 12, 0.5m),
            new Napoj("Wino", 20, 0.5m),
            new Napoj("Whisky", 30, 0.5m),
            new Napoj("Rum", 25, 0.5m),
            new Napoj("Gin", 22, 0.5m)
        };
    }

    private void Wyswietl()
    {
        Console.WriteLine("\n=== System Zarządzania Restauracją ===\n1. Zarządzaj zamówieniem\n2. Zarządzaj stolikiem\n3. Zarządzaj pracownikami\n4. Zarządzaj restauracją\n0. Wyjdź z systemu\nWybierz opcję: ");
    }

    public void Uruchom()
    {
        restauracja.Otworz();

        bool dziala = true;
        while (dziala)
        {
            Wyswietl();

            string wybor = Console.ReadLine() ?? "";
            switch (wybor)
            {
                case "1":
                    ZarzadzajZamowieniem();
                    break;
                case "2":
                    ZarzadzajStolikiem();
                    break;
                case "3":
                    PracownikMenu();
                    break;
                case "4":
                    ZarzadzajRestauracja();
                    break;
                case "0":
                    dziala = false;
                    Console.WriteLine("Zamykanie systemu...");
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór, spróbuj ponownie.");
                    break;
            }
        }

        restauracja.Zamknij();
    }
}