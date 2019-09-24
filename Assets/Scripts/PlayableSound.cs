using MusicAlgebra;

public class PlayableSound
{
    public Pitch pitch { get; }
    public float volume { get; }
    public int startQuarterBeatNumber { get; }
    public int durationQuarterBeats { get; }

    public PlayableSound(Pitch pitch, float volume, int startQuarterBeatNumber, int durationQuarterBeats)
    {
        this.pitch = pitch;
        this.volume = volume;
        this.startQuarterBeatNumber = startQuarterBeatNumber;
        this.durationQuarterBeats = durationQuarterBeats;
    }
}