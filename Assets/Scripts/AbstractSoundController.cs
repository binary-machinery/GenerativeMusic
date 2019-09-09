public abstract class AbstractSoundController
{
    private readonly int _durationQuarterBeats;
    private int _quarterBeatsCounter;

    protected AbstractSoundController(int durationQuarterBeats)
    {
        _durationQuarterBeats = durationQuarterBeats;
    }

    public abstract void Stop();

    public void IncrementQuarterBeatCounter()
    {
        ++_quarterBeatsCounter;
    }

    public bool IsTimeToStop()
    {
        return _quarterBeatsCounter >= _durationQuarterBeats;
    }
}