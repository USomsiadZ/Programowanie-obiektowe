public class Produkt
{
    protected string nazwa;
}

public class Danie : Produkt
{
    public string readNazwa => nazwa;

}

Danie = new();
Danie.nazwa = "Dziecko";
