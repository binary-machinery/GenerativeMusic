using MusicAlgebra;

public class PlayableSound
{
    private static int _idGenerator = 0;

    public int id { get; }
    public Pitch pitch { get; }
    public float volume { get; }
    public int startTimeQuantumNumber { get; }
    public int durationTimeQuanta { get; }

    public PlayableSound(Pitch pitch, float volume, int startTimeQuantumNumber, int durationTimeQuanta)
    {
        this.id = _idGenerator++;
        this.pitch = pitch;
        this.volume = volume;
        this.startTimeQuantumNumber = startTimeQuantumNumber;
        this.durationTimeQuanta = durationTimeQuanta;
    }
}