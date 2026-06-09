using ZamowieniaApp.Produkty;

namespace ZamowieniaApp.Menu;

public partial class Menu
{
    private void ZarzadzajRestauracja()
    {
        bool dziala = true;
        while (dziala)
        {
            Console.WriteLine("\n=== Zarządzanie restauracją ===\n1. Otwórz restaurację\n2. Zamknij restaurację\n3. Wyświetl aktualne menu\n4. Dodaj nową pozycję do menu\n5. Usuń pozycję z menu\n0. Powrót\nWybierz opcję: ");
            string wybor = Console.ReadLine() ?? "";
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
                    DodajDoMenu();
                    break;
                case "5":
                    UsunZMenu();
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

    private void PokazOferte()
    {
        Console.WriteLine("Menu:");
        if (oferta.Count == 0)
        {
            Console.WriteLine("Menu jest puste");
            return;
        }

        for (int i = 0; i < oferta.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {oferta[i]} | Cena: {oferta[i].Cena()} zł");
        }
    }

    private void DodajDoMenu()
    {
        Console.WriteLine("Jaką pozycję chcesz dodać?");
        Console.WriteLine("1. Danie");
        Console.WriteLine("2. Napój");
        Console.Write("Wybierz opcję: ");

        string typ = Console.ReadLine() ?? "";
        if (typ != "1" && typ != "2")
        {
            Console.WriteLine("Nieznana pozycja, anulowano");
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
                Console.Write("Podaj pojemność (w litrach): ");
                decimal litraz = decimal.Parse(Console.ReadLine()!);
                oferta.Add(new Napoj(nazwa, cena, litraz));
            }

            Console.WriteLine($"Pomyślnie dodano '{nazwa}' do menu");
        }
        catch
        {
            Console.WriteLine("Błędne dane, spróbuj ponownie");
        }
    }

    private void UsunZMenu()
    {
        if (oferta.Count == 0)
        {
            Console.WriteLine("Menu jest puste");
            return;
        }

        PokazOferte();
        Console.Write("Podaj numer pozycji do usunięcia: ");

        if (int.TryParse(Console.ReadLine(), out int numer) && numer > 0 && numer <= oferta.Count)
        {
            var produkt = oferta[numer - 1];
            oferta.RemoveAt(numer - 1);
            Console.WriteLine($"Pomyślnie usunięto: {produkt}");
        }
        else
        {
            Console.WriteLine("Niepoprawny wybór, spróbuj ponownie");
        }
    }
}