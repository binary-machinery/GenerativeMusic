using UnityEngine;

namespace MusicAlgebra
{
    public class PitchFrequencyCalculator
    {
        private static readonly Pitch REF_PITCH = new Pitch(Note.A, 4);
        private static readonly float REF_FREQUENCY = 440f;
        private static readonly float FREQ_COEF = Mathf.Pow(2f, 1f / 12f);

        public static float GetFrequency(Pitch pitch)
        {
            return REF_FREQUENCY * Mathf.Pow(FREQ_COEF, Operators.GetSemitonesDifference(pitch, REF_PITCH));
        }
    }
}