using MusicAlgebra;

public class PlayableSound
{
    public Pitch pitch { get; }
    public float volume { get; }
    public int durationQuarterBeats { get; }

    public PlayableSound(Pitch pitch, float volume, int durationQuarterBeats)
    {
        this.pitch = pitch;
        this.volume = volume;
        this.durationQuarterBeats = durationQuarterBeats;
    }
}