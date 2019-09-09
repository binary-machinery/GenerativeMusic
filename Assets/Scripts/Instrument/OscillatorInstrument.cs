using MusicAlgebra;
using UnityEngine;

public class OscillatorInstrument : AbstractInstrument
{
    [SerializeField]
    private Oscillator _oscillatorPrefab;
    
    public override AbstractSoundController PlayNote(Pitch pitch, float volume, int durationQuarterBeats)
    {
        Oscillator oscillator = Instantiate(_oscillatorPrefab, gameObject.transform);
        oscillator.frequency = PitchFrequencyCalculator.GetFrequency(pitch);
        oscillator.gain = volume;
        return new OscillatorSoundController(oscillator, durationQuarterBeats);
    }
}
