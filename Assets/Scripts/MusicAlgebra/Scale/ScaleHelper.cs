using System.Collections.Generic;

namespace MusicAlgebra
{
    public static class ScaleHelper
    {
        private static readonly Dictionary<ScaleType, int[]> PATTERNS = new Dictionary<ScaleType, int[]>()
        {
            { ScaleType.Major, new[] { 2, 2, 1, 2, 2, 2, 1 } },
            { ScaleType.Dorian, new[] { 2, 1, 2, 2, 2, 1, 2 } },
            { ScaleType.Phrygian, new[] { 1, 2, 2, 2, 1, 2, 2 } },
            { ScaleType.Lydian, new[] { 2, 2, 2, 1, 2, 2, 1 } },
            { ScaleType.Mixolydian, new[] { 2, 2, 1, 2, 2, 1, 2 } },
            { ScaleType.Minor, new[] { 2, 1, 2, 2, 1, 2, 2 } },
            { ScaleType.Locrian, new[] { 1, 2, 2, 1, 2, 2, 1 } },
        };

        public static Scale Create(Pitch rootPitch, ScaleType scaleType)
        {
            int[] pattern = PATTERNS[scaleType];
            Pitch[] pitches = new Pitch[pattern.Length + 1];
            pitches[0] = rootPitch;
            for (int i = 0; i < pattern.Length; ++i)
            {
                pitches[i + 1] = Operators.AddSemitones(pitches[i], pattern[i]);
            }
            return new Scale(scaleType, pitches);
        }
    }
}