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
        restauracja = new Restauracja("U Łukasza");
        restauracja.Zatrudnij(new Kelner(1, "Jan", 3000, 1));
        restauracja.Zatrudnij(new Kucharz(2, "Anna", 3500, "kuchnia"));
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
        Console.WriteLine("\n=== System Zarządzania Restauracją ===");
        Console.WriteLine("1. Zarządzaj zamówieniem.");
        Console.WriteLine("2. Zarządzaj stolikiem.");
        Console.WriteLine("3. Zarządzaj pracownikami.");
        Console.WriteLine("4. Zarządzaj restauracją.");
        Console.WriteLine("0. Wyjdź z systemu.");
        Console.Write("Wybór: ");
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
                    Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                    break;
            }
        }

        restauracja.Zamknij();
    }
}