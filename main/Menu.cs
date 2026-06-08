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

            string wybor = Console.ReadLine();
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
                    UsunPozycje();
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
                decimal litraz = decimal.Parse(Console.ReadLine()!);
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
        bool dziala = true;
        while (dziala)
        {
            Console.WriteLine("=== Zarządzanie zamówieniami ===");
            Console.WriteLine("1. Przyjmij gości i utwórz nowe zamówienie");
            Console.WriteLine("2. Dodaj pozycję do zamówienia");
            Console.WriteLine("3. Usuń pozycję z zamówienia");
            Console.WriteLine("4. Pokaż aktualne zamówienie.");
            Console.WriteLine("5. Zleć przygotowanie zamówienia");
            Console.WriteLine("6. Przynieś zamówienie do stolika.");
            Console.WriteLine("7. Opłać zamówienie");
            Console.WriteLine("0. Powrót.");

            string wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":
                    NoweZamowienie();
                    break;
                case "2":
                    NoweDanie();
                    break;
                case "3":
                    UsunDanie();
                    break;
                case "4":
                    PokazZamowienie();
                    break;
                case "5":
                    ZlecPrzygotowanie();
                    break;
                case "6":
                    PodajDanie();
                    break;
                case "7":
                    OplacZamowienie();
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

    private void NoweZamowienie()
    {
        if (zamowienie != null)
        {
            Console.WriteLine("Nie można utworzyć nowego zamówienia. Powód: Istnieje już aktywne zamówienie. Dokończ jego obsługe.");
            return;
        }
        
        var pracownicy = restauracja.readPracownicy;
        var kelnerzy = pracownicy.OfType<Kelner>().ToList();

        if (kelnerzy.Count == 0)
        {
            Console.WriteLine("Brak kelnerów w systemie. ");
            return;
        }

        Console.WriteLine("Wybierz kelnera:");
        for (int i = 0; i < kelnerzy.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {kelnerzy[i].readImie} (Rewir: {kelnerzy[i].readRewir})");
        }
        Console.Write("Wybór: ");
        if (!int.TryParse(Console.ReadLine(), out int nrKelnera) || nrKelnera < 1 || nrKelnera > kelnerzy.Count)
        {
            Console.WriteLine("Niepoprawny wybór kelnera. Anulowano.");
            return;
        }
        Kelner wybranyKelner = kelnerzy[nrKelnera - 1];
        
        Console.WriteLine("Podaj ilość osób: ");
        if (!int.TryParse(Console.ReadLine(), out int liczbaOsob) || liczbaOsob <= 0)
        {
            Console.WriteLine("Niepoprawna liczba osób. Anulowano tworzenie zamówienia.");
            return;
        }
        Stolik? wybranyStolik = restauracja.ZnajdzWolnyStolik(liczbaOsob);

        if (wybranyStolik == null)
        {
            Console.WriteLine($"\nBłąd: Brak wolnego stolika, który pomieści {liczbaOsob} osób!");
            return;
        }
        
        zamowienie = new Zamowienie(kolejneId++, wybranyStolik, wybranyKelner);
        wybranyStolik.Rezerwuj(); 
        
        Console.WriteLine($"Pomyślnie przyjęto gości ({liczbaOsob} os.).");
        Console.WriteLine($"Automatycznie przydzielono Stolik nr {wybranyStolik.readNumer} (Liczba miejsc: {wybranyStolik.readMiejsca}).");
        Console.WriteLine($"Utworzono zamówienie ID: {zamowienie.readId}.");
    }
    
    private void NoweDanie()
    {
        if (zamowienie == null)
        {
            Console.WriteLine("Brak zamówienia. Utwórz nowe zamówienie."); 
            return;
        }
        
        if (oferta.Count == 0)
        {
            Console.WriteLine("Menu restauracji jest puste.");
            return;
        }

        PokazOferte();
        
        try
        {
            Console.Write("Numer produktu: ");
            int nr = int.Parse(Console.ReadLine()!);

            Console.Write("Ilość: ");
            int ilosc = int.Parse(Console.ReadLine()!);

            var produkt = oferta[nr - 1];
            zamowienie.Dodaj(new Pozycja(produkt, ilosc));
            
            Console.WriteLine($"Pomyślnie dodano {ilosc} x {produkt} do zamówienia.");
        }
        catch
        {
            Console.WriteLine("Błędne dane lub niepoprawny numer produktu z listy.");
        }
    }
    
    private void UsunDanie()
    {
        if (zamowienie == null)
        {
            Console.WriteLine("Brak zamówienia.");
            return;
        }

        var pozycje = zamowienie.readPozycje;
        if (pozycje.Count == 0)
        {
            Console.WriteLine("Zamówienie jest puste.");
            return;
        }

        Console.WriteLine("Pozycje w zamówieniu: ");
        for (int i = 0; i < pozycje.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pozycje[i].readProdukt} x{pozycje[i].readIlosc}");
        }

        try
        {
            Console.Write("Podaj numer pozycji do usunięcia: ");
            int nr = int.Parse(Console.ReadLine()!);
            var usuwanaPozycja = pozycje[nr - 1]; 

            Console.Write($"Ile sztuk usunąć? (obecnie masz: {usuwanaPozycja.readIlosc}): ");
            int iloscDoUsuniecia = int.Parse(Console.ReadLine()!);

            if (iloscDoUsuniecia <= 0)
            {
                Console.WriteLine("Ilość do usunięcia musi być większa niż 0.");
                return;
            }

            if (iloscDoUsuniecia > usuwanaPozycja.readIlosc)
            {
                Console.WriteLine("Ilość do usunięcia nie może być większa od ilości pozycji");
                return;   
            }
            
            if (iloscDoUsuniecia == usuwanaPozycja.readIlosc)
            {
                zamowienie.Usun(usuwanaPozycja);
                Console.WriteLine($"Całkowicie usunięto pozycję: {usuwanaPozycja.readProdukt}.");
            }
            else
            {
                usuwanaPozycja.ZmniejszIlosc(iloscDoUsuniecia);
                zamowienie.AktualizujSume();
                Console.WriteLine($"Zmniejszono ilość '{usuwanaPozycja.readProdukt}' o {iloscDoUsuniecia} szt.");
            }
        }
        catch
        {
            Console.WriteLine("Niepoprawny wybór.");
        }
    }
    
    private void ZlecPrzygotowanie()
    {
        if (zamowienie == null)
        {
            Console.WriteLine("Brak aktywnego zamówienia.");
            return;
        }
        
        if (zamowienie.readStan != Status.Nowe)
        {
            Console.WriteLine($"Nie można zlecić przygotowania. Obecny status zamówienia to: {zamowienie.readStan}. Tylko 'Nowe' zamówienia mogą trafić do kuchni!");
            return;
        }
        

        var pozycje = zamowienie.readPozycje;
        if (pozycje.Count == 0)
        {
            Console.WriteLine("Zamówienie jest puste! Dodaj pozycje do zamówienia.");
            return;
        }
        
        var kucharze = restauracja.readPracownicy.OfType<Kucharz>().ToList();
        if (kucharze.Count == 0)
        {
            Console.WriteLine("Brak kucharzy. Zatrudnij kucharza, aby przygotować posiłek!");
            return;
        }

        Console.WriteLine("Wybierz kucharza realizującego zamówienie:");
        for (int i = 0; i < kucharze.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {kucharze[i].readImie} (Sekcja: {kucharze[i].readSekcja})");
        }
        Console.Write("Wybór: ");
        if (!int.TryParse(Console.ReadLine(), out int nrKucharza) || nrKucharza < 1 || nrKucharza > kucharze.Count)
        {
            Console.WriteLine("Niepoprawny wybór.");
            return;
        }
        Kucharz wybranyKucharz = kucharze[nrKucharza - 1];
        
        zamowienie.Zatwierdz();
        Console.WriteLine($"Kucharz {wybranyKucharz.readImie} rozpoczyna pracę nad zamówieniem...");
        
        foreach (var poz in pozycje)
        {
            if (poz.readProdukt is Napoj napoj)
            {
                Console.WriteLine($"Czy chcesz schłodzić: {napoj.readNazwa}");
                Console.WriteLine("1. Tak/t");
                Console.WriteLine("2. Nie/n");
                string odpowiedz = Console.ReadLine()?.ToLower() ?? "";
                if (odpowiedz == "tak" || odpowiedz == "t" ||odpowiedz == "1")
                {
                    napoj.Schlodz();
                }

                else if (odpowiedz == "nie" || odpowiedz == "n" || odpowiedz == "2")
                {
                    Console.WriteLine($"Napój {napoj.readNazwa} nie będzie schłodzony.");
                }
                else
                {
                    Console.WriteLine("Niepoprawny wybór. Napój nie będzie schłodzony.");
                } 
            }
            else if (poz.readProdukt is Danie danie)
            {
                Console.Write($"\n -> [Danie] ");
                wybranyKucharz.Gotuj(danie);
                
                if (wybranyKucharz.Sprawdz(danie))
                {
                    Console.WriteLine($"    Danie '{danie.readNazwa}' przeszło kontrolę u kucharza ({wybranyKucharz.readImie}).");
                }
            }
        }
        
        zamowienie.ZmienStan(Status.Gotowe);
        Console.WriteLine("Zamówienie zostało przygotowane i jest gotowe do podania!");
    }

    private void PodajDanie()
    {
        if (zamowienie == null)
        {
            Console.WriteLine("Brak aktywnego zamówienia.");
            return;
        }

        if (zamowienie.readStan != Status.Gotowe)
        {
            Console.WriteLine("Zamówienie nie zostało jeszcze przygotowane.");
            return;
        }
        zamowienie.ZmienStan(Status.Podano);
        Console.WriteLine("Pomysłnie podano zamówienie do stolika.");
    }
    
    private void PokazZamowienie()
    {
        if (zamowienie == null)
        {
            Console.WriteLine("Brak zamówienia.");
            return;
        }

        foreach (var pozycja in zamowienie.readPozycje)
        {
            Console.WriteLine($"{pozycja.readProdukt} x{pozycja.readIlosc} = {pozycja.Sumuj()} zł");
        }
        Console.WriteLine($"Suma: {zamowienie.Podsumuj()} zł, stan: {zamowienie.readStan}");
    }

private void OplacZamowienie()
    {
        if (zamowienie == null)
        {
            Console.WriteLine("Brak aktywnego zamówienia do opłacenia.");
            return;
        }

        if (zamowienie.readStan != Status.Podano)
        {
            Console.WriteLine("Nie można opłacić zamówienia, które nie zostało podane do stolika.");
            return;
        }

        PokazZamowienie();
        decimal kwotaPodstawowa = zamowienie.Podsumuj();

        Console.WriteLine("Czy chcesz naliczyć rabat do tego zamówienia?");
        Console.WriteLine("1. Tak/t");
        Console.WriteLine("2. Nie/n");
        string decyzjaRabatu = Console.ReadLine()?.ToLower() ?? "";
        
        Rabat wybranyRabat = new ProcentowyRabat(0); 

        if (decyzjaRabatu == "t" || decyzjaRabatu == "tak" || decyzjaRabatu == "1")
        {
            bool poprawnyRabat = false;
            
            while (!poprawnyRabat)
            {
                Console.WriteLine("Wybierz opcje:");
                Console.WriteLine("1. Rabat procentowy ");
                Console.WriteLine("2. Rabat za zestaw (15% zniżki od 3 pozycji)");
                Console.Write("Wybór: ");
                string opcjaRabatu = Console.ReadLine() ?? "";

                if (opcjaRabatu == "1")
                {
                    Console.Write("Podaj wartość rabatu w %: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal procent) && procent >= 0 && procent <= 100)
                    {
                        wybranyRabat = new ProcentowyRabat(procent);
                        poprawnyRabat = true;
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawną wartość! Spróbuj ponownie.");
                    }
                }
                else if (opcjaRabatu == "2")
                {
                    int minPozycje = 3; 
                    decimal znizkaZestawu = 15; 
                    int aktualnaLiczbaPozycji = zamowienie.LiczbaPozycji();
                    
                    wybranyRabat = new ZestawRabat(minPozycje, znizkaZestawu, aktualnaLiczbaPozycji);
                    poprawnyRabat = true;
                }
                else
                {
                    Console.WriteLine("Niepoprawna opcja. Spróbuj jeszcze raz");
                }
            }
            
            decimal kwotaPoRabacie = wybranyRabat.Oblicz(kwotaPodstawowa);
            
            if (kwotaPoRabacie < kwotaPodstawowa)
            {
                Console.WriteLine($"Rabat został przyznany! Kwota do zapłaty: {kwotaPoRabacie} zł)");
            }
            else
            {
                Console.WriteLine($"Warunki zniżki NIE zostały spełnione. Kwota do zapłaty: {kwotaPodstawowa} zł");
            }
        }
        else
        {
            Console.WriteLine($"Do zapłaty: {kwotaPodstawowa} zł");
        }

        string formaPlatnosci = "";
        while (formaPlatnosci == "")
        {
            Console.WriteLine("Wybierz formę płatności:");
            Console.WriteLine("1. Gotówka");
            Console.WriteLine("2. Karta");
            Console.Write("Wybór: ");
            string formaPlatnosciWybor = Console.ReadLine() ?? "";
            
            if (formaPlatnosciWybor == "1") formaPlatnosci = "Gotówka";
            else if (formaPlatnosciWybor == "2") formaPlatnosci = "Karta";
            else Console.WriteLine("Niepoprawny wybór. Wpisz 1 lub 2.");
        }
        
        decimal kwotaKoncowa = zamowienie.Oplac(wybranyRabat);
        
        Console.WriteLine($" Zamówienie ID: {zamowienie.readId} zostało OPŁACONE.");
        Console.WriteLine($" Metoda płatności: {formaPlatnosci}");
        Console.WriteLine($" Kwota: {kwotaKoncowa} zł.");

        zamowienie.readStolik.OznaczJakoBrudny();
        zamowienie = null; 
    }
    
}
    