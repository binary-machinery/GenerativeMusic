using MusicAlgebra;
using UnityEngine;

public class OscillatorInstrument : AbstractInstrument
{
    [SerializeField]
    private Oscillator _oscillatorPrefab;

    [SerializeField]
    [Range(0f, 1f)]
    private float _masterGain = 0.5f;
    
    public override AbstractSoundController PlayNote(Pitch pitch, float volume, int durationQuarterBeats)
    {
        Oscillator oscillator = Instantiate(_oscillatorPrefab, gameObject.transform);
        oscillator.frequency = PitchFrequencyCalculator.GetFrequency(pitch);
        oscillator.gain = volume * _masterGain;
        return new OscillatorSoundController(oscillator, durationQuarterBeats);
    }
}
