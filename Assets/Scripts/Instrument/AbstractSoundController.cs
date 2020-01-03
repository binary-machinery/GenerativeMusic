public abstract class AbstractSoundController
{
    private readonly int _durationTimeQuanta;
    private int _timeQuantumCounter;

    protected AbstractSoundController(int durationTimeQuanta)
    {
        _durationTimeQuanta = durationTimeQuanta;
    }

    public abstract void Stop();

    public void IncrementTimeQuantumCounter()
    {
        ++_timeQuantumCounter;
    }

    public bool IsTimeToStop()
    {
        return _timeQuantumCounter >= _durationTimeQuanta;
    }
}