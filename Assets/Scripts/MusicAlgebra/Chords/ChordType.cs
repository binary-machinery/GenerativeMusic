namespace MusicAlgebra
{
    public enum ChordType
    {
        Undefined,
        Major,
        Minor,
        Diminished,
    }

    public static class ChordNames
    {
        private static readonly string[] NAMES = { "", "maj", "min", "dim" };

        public static string Get(ChordType chordType)
        {
            return NAMES[(int)chordType];
        }
    }
}