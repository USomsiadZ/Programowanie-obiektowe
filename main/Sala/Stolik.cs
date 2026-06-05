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
        status = StatusStolika.Rezerwacja;
    }

    public void Zwolnij()
    {
        status = StatusStolika.Wolny;
    }

    public void OznaczJakoBrudny()
    {
        status = StatusStolika.Brudny;
    }

    public void Posprzataj()
    {
        status = StatusStolika.Wolny;
    }

    public bool CzyWolny()
    {
        return status == StatusStolika.Wolny;
    }
}
