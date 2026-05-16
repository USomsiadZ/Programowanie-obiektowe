namespace ZamowieniaApp.Rabaty;

public class ZestawRabat : Rabat
{
    private int MinPozycji { get; }
    private decimal ProcentZnizki { get; }

    public ZestawRabat(int minPozycji, decimal procentZnizki)
    {
    }

    public decimal Oblicz(decimal suma)
    {
        return 0;
    }
}
