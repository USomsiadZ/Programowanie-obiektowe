namespace ZamowieniaApp.Rabaty;

public class ZestawRabat : Rabat
{
    private int minPozycji;
    private decimal procentZnizki;
    private int liczbaPozycji;

    public int readMinPozycji => minPozycji;
    public decimal readProcentZnizki => procentZnizki;

    public ZestawRabat(int minPozycji, decimal procentZnizki, int liczbaPozycji)
    {
        this.minPozycji = minPozycji;
        this.procentZnizki = procentZnizki;
        this.liczbaPozycji = liczbaPozycji;
    }

    public decimal Oblicz(decimal suma)
    {
        if (liczbaPozycji >= minPozycji)
        {
            return suma * (1 - procentZnizki / 100);
        }
        return suma;
    }
}
