using ZamowieniaApp.Pracownicy;
using ZamowieniaApp.Produkty;
using ZamowieniaApp.Rabaty;
using ZamowieniaApp.Sala;
using ZamowieniaApp.Zamowienia;

namespace ZamowieniaApp.Menu;

public partial class Menu
{
    private void ZarzadzajZamowieniem()
    {
        bool dziala = true;
        while (dziala)
        {
            Console.WriteLine("\n=== Zarządzanie zamówieniami ===");
            Console.WriteLine("1. Przyjmij gości i utwórz nowe zamówienie.");
            Console.WriteLine("2. Dodaj pozycję do zamówienia.");
            Console.WriteLine("3. Usuń pozycję z zamówienia.");
            Console.WriteLine("4. Pokaż aktualne zamówienie.");
            Console.WriteLine("5. Zleć przygotowanie zamówienia.");
            Console.WriteLine("6. Przynieś zamówienie do stolika.");
            Console.WriteLine("7. Opłać zamówienie.");
            Console.WriteLine("0. Powrót.");
            Console.Write("Wybór: ");

            string wybor = Console.ReadLine() ?? "";
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
            Console.WriteLine("Istnieje już aktywne zamówienie. Dokończ jego obsługę.");
            return;
        }

        var kelnerzy = restauracja.readPracownicy.OfType<Kelner>().ToList();
        if (kelnerzy.Count == 0)
        {
            Console.WriteLine("Brak kelnerów w systemie.");
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

        Console.Write("Podaj ilość osób: ");
        if (!int.TryParse(Console.ReadLine(), out int liczbaOsob) || liczbaOsob <= 0)
        {
            Console.WriteLine("Niepoprawna liczba osób. Anulowano.");
            return;
        }

        Stolik? wybranyStolik = restauracja.ZnajdzWolnyStolik(liczbaOsob);
        if (wybranyStolik == null)
        {
            Console.WriteLine($"Brak wolnego stolika dla {liczbaOsob} osób.");
            return;
        }

        zamowienie = new Zamowienie(kolejneId++, wybranyStolik, wybranyKelner);
        wybranyStolik.Zajmij();
        wybranyKelner.readZamowienia.Add(zamowienie);

        Console.WriteLine($"Pomyślnie przyjęto gości ({liczbaOsob} os.).");
        Console.WriteLine($"Przydzielono stolik nr {wybranyStolik.readNumer} ({wybranyStolik.readMiejsca} miejsca).");
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
        catch (FormatException)
        {
            Console.WriteLine("Niepoprawny wybór.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Podano niepoprawny numer produktu.");
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

        Console.WriteLine("Pozycje w zamówieniu:");
        for (int i = 0; i < pozycje.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pozycje[i].readProdukt} x{pozycje[i].readIlosc}");
        }

        try
        {
            Console.Write("Podaj numer pozycji do usunięcia: ");
            int nr = int.Parse(Console.ReadLine()!);
            var usuwanaPozycja = pozycje[nr - 1];

            Console.Write($"Ile sztuk usunąć? (obecnie: {usuwanaPozycja.readIlosc}): ");
            int iloscDoUsuniecia = int.Parse(Console.ReadLine()!);

            if (iloscDoUsuniecia <= 0 || iloscDoUsuniecia > usuwanaPozycja.readIlosc)
            {
                Console.WriteLine("Niepoprawna ilość.");
                return;
            }

            if (iloscDoUsuniecia == usuwanaPozycja.readIlosc)
            {
                zamowienie.Usun(usuwanaPozycja);
                Console.WriteLine($"Usunięto pozycję: {usuwanaPozycja.readProdukt}.");
            }
            else
            {
                usuwanaPozycja.ZmniejszIlosc(iloscDoUsuniecia);
                zamowienie.AktualizujSume();
                Console.WriteLine($"Zmniejszono ilość '{usuwanaPozycja.readProdukt}' o {iloscDoUsuniecia} szt.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Niepoprawny wybór.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Podano niepoprawny numer produktu.");
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
            Console.WriteLine($"Zamówienie ma status '{zamowienie.readStan}'. Tylko 'Nowe' można zlecić do kuchni.");
            return;
        }

        var pozycje = zamowienie.readPozycje;
        if (pozycje.Count == 0)
        {
            Console.WriteLine("Zamówienie jest puste. Dodaj pozycje przed zleceniem.");
            return;
        }

        var kucharze = restauracja.readPracownicy.OfType<Kucharz>().ToList();
        if (kucharze.Count == 0)
        {
            Console.WriteLine("Brak kucharzy. Zatrudnij kucharza, aby przygotować posiłek.");
            return;
        }

        Console.WriteLine("Wybierz kucharza:");
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
        wybranyKucharz.Pracuj();

        zamowienie.Zatwierdz();
        Console.WriteLine($"Kucharz {wybranyKucharz.readImie} rozpoczyna pracę nad zamówieniem...");

        foreach (var poz in pozycje)
        {
            if (poz.readProdukt is Napoj napoj)
            {
                Console.Write($"Schłodzić {napoj.readNazwa}? (t/n): ");
                string odp = Console.ReadLine() ?? "";
                if (odp == "t" || odp == "1")
                    napoj.Schlodz();
            }
            else if (poz.readProdukt is Danie danie)
            {
                Console.Write(" -> [Danie] ");
                wybranyKucharz.Gotuj(danie);
                if (wybranyKucharz.Sprawdz(danie))
                    Console.WriteLine($"   '{danie.readNazwa}' gotowe.");
            }
        }

        zamowienie.ZmienStan(Status.Gotowe);
        Console.WriteLine("Zamówienie gotowe do podania!");
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
            Console.WriteLine("Zamówienie nie jest jeszcze gotowe.");
            return;
        }

        zamowienie.ZmienStan(Status.Podano);
        Console.WriteLine("Pomyślnie podano zamówienie do stolika.");
    }

    private void PokazZamowienie()
    {
        if (zamowienie == null)
        {
            Console.WriteLine("Brak zamówienia.");
            return;
        }

        Console.WriteLine($"Zamówienie ID: {zamowienie.readId} | Stan: {zamowienie.readStan}");
        foreach (var pozycja in zamowienie.readPozycje)
        {
            Console.WriteLine($"  {pozycja.readProdukt} x{pozycja.readIlosc} = {pozycja.Sumuj()} zł");
        }
        Console.WriteLine($"Suma: {zamowienie.Podsumuj()} zł");
    }

    private void OplacZamowienie()
    {
        if (zamowienie == null)
        {
            Console.WriteLine("Brak aktywnego zamówienia.");
            return;
        }

        if (zamowienie.readStan != Status.Podano)
        {
            Console.WriteLine("Nie można opłacić zamówienia, które nie zostało podane do stolika.");
            return;
        }

        PokazZamowienie();

        Console.WriteLine("Wybierz rabat:");
        Console.WriteLine("1. Rabat procentowy.");
        Console.WriteLine("2. Rabat za zestaw (15% od 3 pozycji).");
        Console.WriteLine("3. Brak rabatu.");
        Console.Write("Wybór: ");
        string opcjaRabatu = Console.ReadLine() ?? "";

        Rabat wybranyRabat;
        if (opcjaRabatu == "1")
        {
            Console.Write("Podaj wartość rabatu w %: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal procent) || procent < 0 || procent > 100)
            {
                Console.WriteLine("Niepoprawna wartość rabatu. Anulowano.");
                return;
            }
            wybranyRabat = new ProcentowyRabat(procent);
        }
        else if (opcjaRabatu == "2")
        {
            wybranyRabat = new ZestawRabat(3, 15, zamowienie.LiczbaPozycji());
        }
        else
        {
            wybranyRabat = new ProcentowyRabat(0);
        }

        Console.WriteLine("Wybierz formę płatności:");
        Console.WriteLine("1. Gotówka.");
        Console.WriteLine("2. Karta.");
        Console.Write("Wybór: ");
        string formaPlatnosci = Console.ReadLine() == "1" ? "Gotówka" : "Karta";

        decimal kwotaKoncowa = zamowienie.Oplac(wybranyRabat);

        Console.WriteLine($"Zamówienie ID: {zamowienie.readId} opłacone.");
        Console.WriteLine($"Metoda płatności: {formaPlatnosci}");
        Console.WriteLine($"Kwota: {kwotaKoncowa} zł.");

        zamowienie.readStolik.OznaczJakoBrudny();
        zamowienie = null;
    }
}