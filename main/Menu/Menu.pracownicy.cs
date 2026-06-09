using ZamowieniaApp.Pracownicy;

namespace ZamowieniaApp.Menu;

public partial class Menu
{
    private void PracownikMenu()
    {
        bool dziala = true;
        while (dziala)
        {
            Console.WriteLine("=== Zarządzanie pracownikami ===\n1. Sprawdź obecną listę pracowników\n2. Dodaj nowego pracownika\n3. Zwolnij pracownika\n0. Powrót\nWybierz opcję: ");
            string wybor = Console.ReadLine() ?? "";
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
                    Console.WriteLine("Niepoprawny wybór, spróbuj ponownie");
                    break;
            }
        }
    }

    private void PokazPracownikow()
    {
        var pracownicy = restauracja.readPracownicy;
        if (pracownicy.Count == 0)
        {
            Console.WriteLine("Brak pracowników");
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
        Console.WriteLine("Typ pracownika:\n1. Kelner\n2. Kucharz");
        Console.Write("Wybierz opcję: ");
        string typ = Console.ReadLine() ?? "";

        if (typ != "1" && typ != "2")
        {
            Console.WriteLine("Niepoprawny wybór, spróbuj ponownie");
            return;
        }

        try
        {
            int noweId = kolejneIdPracownika++;

            Console.Write("Podaj imię pracownika: ");
            string imie = Console.ReadLine()!;

            Console.Write("Podaj pensję pracownika: ");
            decimal pensja = decimal.Parse(Console.ReadLine()!);

            if (typ == "1")
            {
                Console.Write("Podaj numer rewiru: ");
                int rewir = int.Parse(Console.ReadLine()!);
                restauracja.Zatrudnij(new Kelner(noweId, imie, pensja, rewir));
            }
            else
            {
                Console.Write("Podaj sekcję pracy kucharza: ");
                string sekcja = Console.ReadLine()!;
                restauracja.Zatrudnij(new Kucharz(noweId, imie, pensja, sekcja));
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Niepoprawne dane, spróbuj ponownie");
        }
    }

    private void ZwolnijPracownika()
    {
        var pracownicy = restauracja.readPracownicy;
        if (pracownicy.Count == 0)
        {
            Console.WriteLine("Brak pracowników");
            return;
        }
        PokazPracownikow();

        Console.Write("Podaj ID pracownika do zwolnienia: ");
        try
        {
            int nr = int.Parse(Console.ReadLine()!);
            var pracownik = pracownicy[nr - 1];
            restauracja.Zwolnij(pracownik);
            Console.WriteLine($"Pomyślnie zwolniono pracownika: {pracownik}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Niepoprawne dane, spróbuj ponownie");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Podano niepoprawny ID pracownika, spróbuj ponownie");
        }
    }
}