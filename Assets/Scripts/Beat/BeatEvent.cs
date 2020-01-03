public class BeatEvent
{
    public float time { get; }
    public int timeQuantumNumber { get; }
    public int beatNumber { get; }
    public bool isStrong { get; }

    public BeatEvent(float time, int timeQuantumNumber, int beatNumber, bool isStrong)
    {
        this.time = time;
        this.timeQuantumNumber = timeQuantumNumber;
        this.beatNumber = beatNumber;
        this.isStrong = isStrong;
    }
}