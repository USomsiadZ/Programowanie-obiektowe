namespace ZamowieniaApp.Rabaty;

public class ProcentowyRabat : Rabat
{
    private decimal procent;

    public decimal readProcent => procent;

    public ProcentowyRabat(decimal procent)
    {
        this.procent = procent;
    }

    public decimal Oblicz(decimal suma)
    {
        return suma * (1 - procent / 100);
    }
}
