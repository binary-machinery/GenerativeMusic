public class BeatEvent
{
    public float time { get; }
    public int timeQuantumNumber { get; }
    public bool isStrong { get; }

    public BeatEvent(float time, int timeQuantumNumber, bool isStrong)
    {
        this.time = time;
        this.timeQuantumNumber = timeQuantumNumber;
        this.isStrong = isStrong;
    }
}
