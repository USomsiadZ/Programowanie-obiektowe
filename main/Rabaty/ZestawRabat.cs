namespace ZamowieniaApp.Rabaty;

public class ZestawRabat : Rabat
{
    private int minPozycji;
    private decimal procentZnizki;

    public int readMinPozycji => minPozycji;
    public decimal readProcentZnizki => procentZnizki;

    public ZestawRabat(int minPozycji, decimal procentZnizki)
    {
        this.minPozycji = minPozycji;
        this.procentZnizki = procentZnizki;
    }

    public decimal Oblicz(decimal suma)
    {
        return suma * (1 - procentZnizki / 100);
    }
}
