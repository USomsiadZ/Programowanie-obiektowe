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
            new Napoj("Cola", 8, 0.5)
        };
    }

    public void Uruchom()
    {
        restauracja.Otworz();

        bool dziala = true;
        while (dziala)
        {
            Console.WriteLine();
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Pokaż ofertę");
            Console.WriteLine("2. Nowe zamówienie");
            Console.WriteLine("3. Dodaj pozycję");
            Console.WriteLine("4. Pokaż zamówienie");
            Console.WriteLine("5. Opłać zamówienie");
            Console.WriteLine("6. Aktywne zamówienia kelnera");
            Console.WriteLine("0. Wyjście");
            Console.Write("Wybór: ");

            string? wybor = Console.ReadLine();
            if (wybor == null)
            {
                Console.WriteLine("Nieprawidłowy wybór.");
                break;
            }
            switch (wybor)
            {
                case "1": PokazOferte(); break;
                case "2": NoweZamowienie(); break;
                case "3": DodajPozycje(); break;
                case "4": PokazZamowienie(); break;
                case "5": Oplac(); break;
                case "6": Console.WriteLine($"Aktywne zamówienia: {kelner.LiczbaAktywnychZamowien()}"); break;
                case "0": dziala = false; break;
                default: Console.WriteLine("Nieznana opcja."); break;
            }
        }

        restauracja.Zamknij();
    }

    private void PokazOferte()
    {
        for (int i = 0; i < oferta.Count; i++)
        {
            var produkt = oferta[i];
            Console.WriteLine($"{i + 1}. {produkt} - {produkt.Cena()} zł");
        }
    }

    private void NoweZamowienie()
    {
        var stolik = restauracja.ZnajdzWolnyStolik(2);
        if (stolik == null)
        {
            Console.WriteLine("Brak wolnych stolików.");
            return;
        }

        zamowienie = new Zamowienie(kolejneId, stolik, kelner);
        kolejneId++;
        kelner.readZamowienia.Add(zamowienie);
        Console.WriteLine($"Utworzono zamówienie nr {zamowienie.readId}");
    }

    private void DodajPozycje()
    {
        if (zamowienie == null)
        {
            Console.WriteLine("Najpierw utwórz zamówienie (opcja 2).");
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
            Console.WriteLine($"Dodano {ilosc} x {produkt}");
        }
        catch
        {
            Console.WriteLine("Błędne dane.");
        }
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

    private void Oplac()
    {
        if (zamowienie == null)
        {
            Console.WriteLine("Brak zamówienia.");
            return;
        }

        zamowienie.Zatwierdz();
        Console.WriteLine("Rabat: 1. Procentowy (10%)  2. Zestaw (15% od 3 pozycji)  3. Bez rabatu");
        Console.Write("Wybór: ");
        string wybor = Console.ReadLine() ?? "";

        Rabat rabat;
        if (wybor == "1")
        {
            rabat = new ProcentowyRabat(10);
        }
        else if (wybor == "2")
        {
            rabat = new ZestawRabat(3, 15, zamowienie.LiczbaPozycji());
        }
        else
        {
            rabat = new ProcentowyRabat(0);
        }

        Console.WriteLine($"Do zapłaty: {zamowienie.Oplac(rabat)} zł");
        zamowienie = null;
    }
}
