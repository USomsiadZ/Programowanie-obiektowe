# Plan projektu — System obsługi zamówień

## Wymagania z treści zadania

1. Przeglądanie oferty (dania i napoje).
2. Składanie zamówień złożonych z wielu pozycji.
3. Śledzenie stanu zamówienia.
4. Obliczanie należności z różnymi zasadami ceny (promocje, zestawy).

## Rdzeń (klasy wymagane przez treść i UML)

1. `Produkt` (abstract) + `Danie` + `Napoj` — oferta, polimorfizm `Cena()`.
2. `Zamowienie` + `Pozycja` — składanie zamówień z wielu pozycji.
3. `Status` (enum) — śledzenie stanu zamówienia.
4. `Rabat` (interface) + `ProcentowyRabat` + `ZestawRabat` — polimorficzne zasady ceny.

## Klasy dodatkowe (zwiększają złożoność)

1. `Pracownik` (abstract) + `Kelner` + `Kucharz` — drugi przykład dziedziczenia, polimorfizm `Pracuj()`.
2. `Stolik` + `StatusStolika` (enum) — obsługa sali.
3. `Restauracja` — kontener (pracownicy, stoliki) i punkt wejścia `Main`.

## Scenariusz w `Main`

1. Utworzenie restauracji i jej otwarcie.
2. Zatrudnienie kelnera i dodanie stolika.
3. Wypisanie oferty (danie + napój).
4. Znalezienie wolnego stolika.
5. Utworzenie zamówienia i dodanie pozycji.
6. Zatwierdzenie zamówienia (zmiana stanu).
7. Opłacenie zamówienia z rabatem (polimorfizm).
8. Zamknięcie restauracji.

## Mechanizmy OOP (punktowane)

1. Klasy abstrakcyjne — `Produkt`, `Pracownik`.
2. Dziedziczenie — `Danie`/`Napoj` z `Produkt`, `Kelner`/`Kucharz` z `Pracownik`.
3. Interfejs — `Rabat`.
4. Polimorfizm — `Cena()`, `Pracuj()`, `Oblicz()`.
5. Hermetyzacja — pola prywatne/chronione + właściwości `readXxx`.
6. Obsługa błędów — walidacja i `ArgumentNullException` w `Restauracja`.

## Uruchomienie

1. Przejść do katalogu `main`.
2. Wykonać `dotnet run`.
