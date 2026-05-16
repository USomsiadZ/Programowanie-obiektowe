namespace ZamowieniaApp.Sala;

public class Stolik
{
    private int numer;
    private int miejsca;
    private StatusStolika status;

    public int readNumer => numer;
    public int readMiejsca => miejsca;
    public StatusStolika readStatus => status;

    public Stolik(int numer, int miejsca)
    {
        this.numer = numer;
        this.miejsca = miejsca;
        this.status = StatusStolika.Wolny;
    }

    public void Rezerwuj()
    {
    }

    public void Zwolnij()
    {
    }

    public void OznaczJakoBrudny()
    {
    }

    public void Posprzataj()
    {
    }

    public bool CzyWolny()
    {
        return status == StatusStolika.Wolny;
    }
}
