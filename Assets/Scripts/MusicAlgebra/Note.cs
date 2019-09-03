using System;

namespace MusicAlgebra
{
    public enum Note
    {
        C,
        Csharp,
        D,
        Dsharp,
        E,
        F,
        Fsharp,
        G,
        Gsharp,
        A,
        Asharp,
        B,
    }

    public static class NoteNames
    {
        private static readonly string[] NAMES = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };

        public static string Get(Note note)
        {
            return NAMES[(int)note];
        }
    }
}