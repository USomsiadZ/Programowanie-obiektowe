using ZamowieniaApp.Pracownicy;
using ZamowieniaApp.Produkty;
using ZamowieniaApp.Rabaty;
using ZamowieniaApp.Sala;
using ZamowieniaApp.Zamowienia;

namespace ZamowieniaApp;

public class Menu
{
    private Restauracja restauracja;
    private Kelner kelner;
    private Kucharz kucharz;
    private List<Produkt> oferta;
    private Zamowienie? zamowienie;
    private int kolejneId = 1;
    private int kolejneIdPracownika = 1;

    public Menu()
    {
        restauracja = new Restauracja("U Łukasza");
        kelner = new Kelner(1, "Jan", 3000, 1);
        kucharz = new Kucharz(2, "Anna", 3500, "kuchnia");
        restauracja.Zatrudnij(kelner);
        restauracja.Zatrudnij(kucharz);
        restauracja.DodajStolik(new Stolik(1, 4));
        restauracja.DodajStolik(new Stolik(2, 2));

        oferta = new List<Produkt>
        {
            new Danie("Pizza", 30, 15),
            new Danie("Pizza z szynką", 35, 15),
            new Napoj("Cola", 8, 0.5),
            new Napoj("Piwo", 10, 0.5),
            new Napoj("Woda", 5, 0.5),
            new Napoj("Sok", 12, 0.5),
            new Napoj("Wino", 20, 0.5),
            new Napoj("Whisky", 30, 0.5),
            new Napoj("Rum", 25, 0.5),
            new Napoj("Gin", 22, 0.5)
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

            string wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":
                    Console.WriteLine("Wybrano zarządzanie zamówieniem...");
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
        Console.WriteLine("Aktualna lista pracowników:");
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
            Console.WriteLine("Niepoprawny wybór.");
            return;
        }

        try
        {
            int noweId = kolejneIdPracownika++;

            Console.Write("Podaj imię pracownika: ");
            string imie = Console.ReadLine()!;

            Console.Write("Podaj pensja pracownika: ");
            decimal pensja = decimal.Parse(Console.ReadLine()!);

            if (typ == "1")
            {
                Console.Write("Podaj numer rewiru: ");
                int rewir = int.Parse(Console.ReadLine()!);
                restauracja.Zatrudnij(new Kelner(noweId, imie, pensja, rewir));
            }
            else
            {
                Console.Write("Podaj sekcje pracy kucharza: ");
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
        Console.WriteLine("Podaj ID pracownika którego chcesz zwolnić: ");
        PokazPracownikow();
        try
        {
            int nr = int.Parse(Console.ReadLine()!);
            var pracownik = pracownicy[nr - 1];
            restauracja.Zwolnij(pracownik);
            Console.WriteLine($"Pomyślnie zwolniono pracownika: {pracownik}");
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
    
    // Zarządzanie restauracja

    private void ZarzadzajRestauracja()
    {
        bool dziala = true;
        while (dziala)
        {
            Console.WriteLine("=== Zarządzanie restauracją ===");
            Console.WriteLine("1. Otwórz restauracje.");
            Console.WriteLine("2. Zamknij restauracje.");
            Console.WriteLine("3. Wyświetl aktualne menu.");
            Console.WriteLine("4. Dodaj nową pozycje do menu.");
            Console.WriteLine("5. Usun pozycję z menu.");
            Console.WriteLine("0. Powrót do menu.");
            Console.Write("Wybierz opcje: ");

            string wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":
                    restauracja.Otworz();
                    break;
                case "2":
                    restauracja.Zamknij();
                    break;
                case "3":
                    PokazOferte();
                    break;
                case "4":
                    DodajPozycje();
                    break;
                case "5":
                    break;
                case "0":
                    dziala = false;
                    break;
            }
        }
    }
    
    private void PokazOferte()
    {
        Console.WriteLine("Menu: ");
        if (oferta.Count == 0)
        {
            Console.WriteLine("Brak pozycji w menu.");
            return;
        }

        for (int i = 0; i < oferta.Count; i++)
        {
            var produkt = oferta[i];
            Console.WriteLine($"{i + 1}. {produkt} | Cena: {produkt.Cena()} zł");
        }
    }

    private void DodajPozycje()
    {
        Console.WriteLine("Jaką pozycję chcesz dodać?");
        Console.WriteLine("1. Danie");
        Console.WriteLine("2. Napój");
        Console.Write("Wybór: ");
        
        string typ = Console.ReadLine() ?? "";
        if (typ != "1" && typ != "2")
        {
            Console.WriteLine("Nieznany typ. Anulowano dodawanie.");
            return;
        }
        
        try
        {
            Console.Write("Podaj nazwę: ");
            string nazwa = Console.ReadLine() ?? "Brak nazwy";

            Console.Write("Podaj cenę bazową: ");
            decimal cena = decimal.Parse(Console.ReadLine()!);

            if (typ == "1")
            {
                Console.Write("Podaj czas przygotowania (w minutach): ");
                int czas = int.Parse(Console.ReadLine()!);
                oferta.Add(new Danie(nazwa, cena, czas));
            }
            else
            {
                Console.Write("Podaj pojemność napoju w litrach: ");
                double litraz = double.Parse(Console.ReadLine()!);
                oferta.Add(new Napoj(nazwa, cena, litraz));
            }

            Console.WriteLine($"Pomyślnie dodano '{nazwa}' do menu.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Błąd: Niepoprawne dane.");
        }
    }
    
    private void UsunPozycje()
    {
        if (oferta.Count == 0)
        {
            Console.WriteLine("\nMenu jest puste.");
            return;
        }
        
        PokazOferte();
        Console.WriteLine("Podaj numer pozycji do usunięcia: ");
        string numerPozycji = Console.ReadLine() ?? "";

        if (int.TryParse(numerPozycji, out int numer) && numer > 0 && numer <= oferta.Count)
        {
            var usuwanyProdukt = oferta[numer - 1]; 
            oferta.RemoveAt(numer - 1);
            Console.WriteLine($"Pomyślnie usunięto produkt: {usuwanyProdukt}");
        }
        else
        {
            Console.WriteLine("Niepoprawny numer produktu.");
        }
    }
    
    // Zarządzanie zamówieniem

    private void ZarzadzajZamowieniem()
    {
        
    }
    
    
}