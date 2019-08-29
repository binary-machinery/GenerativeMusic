using MusicAlgebra;
using UnityEngine;

public class OscillatorInstrument : AbstractInstrument
{
    [SerializeField]
    private Oscillator _oscillatorPrefab;
    
    public override void PlayNote(Pitch pitch, float volume)
    {
        Oscillator oscillator = Instantiate(_oscillatorPrefab, gameObject.transform);
        oscillator.frequency = PitchFrequencyCalculator.GetFrequency(pitch);
        oscillator.gain = volume;
        Destroy(oscillator.gameObject, 1f);
    }
}
