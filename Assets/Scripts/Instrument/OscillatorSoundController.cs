using UnityEngine;

public class OscillatorSoundController : AbstractSoundController
{
    private readonly Oscillator _oscillator;

    public OscillatorSoundController(Oscillator oscillator, int durationQuarterBeats) : base(durationQuarterBeats)
    {
        _oscillator = oscillator;
    }

    public override void Stop()
    {
        _oscillator.gain = 0f;
        Object.Destroy(_oscillator.gameObject);
    }
}
