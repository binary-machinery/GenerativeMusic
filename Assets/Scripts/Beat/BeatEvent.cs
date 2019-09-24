public class BeatEvent
{
    public float time { get; }
    public int quarterBeatNumber { get; }
    public bool isStrong { get; }

    public BeatEvent(float time, int quarterBeatNumber, bool isStrong)
    {
        this.time = time;
        this.quarterBeatNumber = quarterBeatNumber;
        this.isStrong = isStrong;
    }
}
