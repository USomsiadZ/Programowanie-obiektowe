using ZamowieniaApp.Pracownicy;
using ZamowieniaApp.Produkty;
using ZamowieniaApp.Rabaty;
using ZamowieniaApp.Sala;
using ZamowieniaApp.Zamowienia;

namespace ZamowieniaApp;

public class MenuNowe
{
    private Restauracja restauracja;
    private Kelner kelner;
    private Kucharz kucharz;
    private List<Produkt> oferta;
    private Zamowienie? zamowienie;
    private int kolejneId = 1;
    private int kolejneIdPracownika = 1;

    public MenuNowe()
    {
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

            string wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":
                    Console.WriteLine("Wybrano zarządzanie zamówieniem...");
                    break;
                case "2":
                    Console.WriteLine("Wybrano zarządzanie stolikiem...");
                    ZarzadzajStolikiem();
                    break;
                case "3":
                    Console.WriteLine("Wybrano zarządzanie pracownikami...");
                    PracownikMenu();
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

    // Zarządzanie pracownikami

    public void PracownikMenu()
    {
        bool dziala = true;
        while (dziala)
        {
            Console.WriteLine("=== Zarządzanie pracownikami ===");
            Console.WriteLine("1. Sprawdz listę pracowników.");
            Console.WriteLine("2. Dodaj nowego pracownika.");
            Console.WriteLine("3. Zwolnij pracownika.");
            Console.WriteLine("0. Powrót.");

            string wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":
                    PokazPracownikow();
                    break;
                case "2":
                    DodajPracownika();
                    break;
                case "3":
                    ZwolnijPracownika();
                    break;
                case "0":
                    dziala = false;
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                    break;
            }
        }
    }

    private void PokazPracownikow()
    {
        var pracownicy = restauracja.readPracownicy;
        if (pracownicy.Count == 0)
        {
            Console.WriteLine("Brak pracowników.");
            return;
        }
        for (int i = 0; i < pracownicy.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pracownicy[i]}");
        }
    }

    private void DodajPracownika()
    {
        Console.WriteLine("Typ pracownika: 1. Kelner  2. Kucharz");
        Console.Write("Wybór: ");
        string typ = Console.ReadLine() ?? "";

        if (typ != "1" && typ != "2")
        {
            Console.WriteLine("Nieznany typ pracownika.");
            return;
        }

        try
        {
            int noweId = kolejneIdPracownika++;

            Console.Write("Imię: ");
            string imie = Console.ReadLine()!;

            Console.Write("Pensja: ");
            decimal pensja = decimal.Parse(Console.ReadLine()!);

            if (typ == "1")
            {
                Console.Write("Numer rewiru: ");
                int rewir = int.Parse(Console.ReadLine()!);
                restauracja.Zatrudnij(new Kelner(noweId, imie, pensja, rewir));
            }
            else
            {
                Console.Write("Sekcja: ");
                string sekcja = Console.ReadLine()!;
                restauracja.Zatrudnij(new Kucharz(noweId, imie, pensja, sekcja));
            }
        }
        catch
        {
            Console.WriteLine("Błędne dane.");
        }
    }

    private void ZwolnijPracownika()
    {
        var pracownicy = restauracja.readPracownicy;
        Console.Write("Podaj ID pracownika którego chcesz zwolnić: ");
        PokazPracownikow();
        try
        {
            int nr = int.Parse(Console.ReadLine()!);
            var pracownik = pracownicy[nr - 1];
            restauracja.Zwolnij(pracownik);
            Console.WriteLine($"Zwolniono: {pracownik}");
        }
        catch
        {
            Console.WriteLine("Niepoprawne ID pracownika.");
        }
    }

    // Zarządzanie stolikiem

    private void ZarzadzajStolikiem()
    {
        var stoliki = restauracja.readStoliki;
        bool wybierzStolik = true;
        
        while (wybierzStolik)
        {
            Console.WriteLine("\n=== Zarządzanie stolikiem ===");
            for (int i = 0; i < stoliki.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Stolik {stoliki[i].readNumer} - {stoliki[i].readStatus}");
            }
            Console.WriteLine("0. Powrót.");
            Console.Write("Wybierz numer stolika: ");

            string wejscie = Console.ReadLine() ?? "";
            if (wejscie == "0")
            {
                wybierzStolik = false;
                continue;
            }

            if (!int.TryParse(wejscie, out int nr) || nr < 1 || nr > stoliki.Count)
            {
                Console.WriteLine("Niepoprawny numer stolika.");
                continue;
            }

            var stolik = stoliki[nr - 1];
            bool akcjaStolik = true;
            
            while (akcjaStolik)
            {
                Console.WriteLine($"\nStolik nr {stolik.readNumer} - Aktualny status: {stolik.readStatus}");
                Console.WriteLine("Wybierz akcję:");
                Console.WriteLine("1. Rezerwuj.");
                Console.WriteLine("2. Zwolnij.");
                Console.WriteLine("3. Oznacz jako brudny.");
                Console.WriteLine("4. Posprzątaj.");
                Console.WriteLine("0. Powrót do wyboru stolika.");
                Console.Write("Wybór: ");

                string akcja = Console.ReadLine() ?? "";
                switch (akcja)
                {
                    case "1":
                        stolik.Rezerwuj();
                        Console.WriteLine($"Pomyślnie zarezerwowano stolik nr {stolik.readNumer}.");
                        wybierzStolik = false;
                        akcjaStolik = false;
                        return;
                    case "2":
                        stolik.Zwolnij();
                        Console.WriteLine($"Pomyślnie zwolniono stolik nr {stolik.readNumer}.");
                        wybierzStolik = false;
                        akcjaStolik = false;
                        return;
                    case "3":
                        stolik.OznaczJakoBrudny();
                        Console.WriteLine($"Pomyślnie oznaczono stolik nr {stolik.readNumer} jako brudny.");
                        wybierzStolik = false;
                        akcjaStolik = false;
                        return;
                    case "4":
                        stolik.Posprzataj();
                        Console.WriteLine($"Stolik nr {stolik.readNumer} został posprzątany.");
                        wybierzStolik = false;
                        akcjaStolik = false;
                        return;
                    case "0":
                        akcjaStolik = false;
                        break;
                    default:
                        Console.WriteLine("Niepoprawna opcja.");
                        break;
                }
            }
        }
    }
    
    // Zarządzanie zamówieniem

    private void ZarzadzajZamowieniem()
    {
        
    }
    
    
    
    
}