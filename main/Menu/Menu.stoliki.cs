namespace ZamowieniaApp.Menu;

public partial class Menu
{
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
                        return;
                    case "2":
                        stolik.Zwolnij();
                        Console.WriteLine($"Pomyślnie zwolniono stolik nr {stolik.readNumer}.");
                        return;
                    case "3":
                        stolik.OznaczJakoBrudny();
                        Console.WriteLine($"Pomyślnie oznaczono stolik nr {stolik.readNumer} jako brudny.");
                        return;
                    case "4":
                        stolik.Posprzataj();
                        Console.WriteLine($"Stolik nr {stolik.readNumer} został posprzątany.");
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
}