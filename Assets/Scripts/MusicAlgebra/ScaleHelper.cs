using System.Collections.Generic;

namespace MusicAlgebra
{
    public static class ScaleHelper
    {
        public enum ScaleType
        {
            Major, // Ionian
            Dorian,
            Phrygian,
            Lydian,
            Mixolydian,
            Minor, // Aeolian
            Locrian
        }

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

        public static Pitch[] Create(Pitch rootPitch, ScaleType scaleType)
        {
            int[] pattern = PATTERNS[scaleType];
            Pitch[] scale = new Pitch[pattern.Length + 1];
            scale[0] = rootPitch;
            for (int i = 0; i < pattern.Length; ++i)
            {
                scale[i + 1] = Operators.AddSemitones(scale[i], pattern[i]);
            }
            return scale;
        }
    }
}