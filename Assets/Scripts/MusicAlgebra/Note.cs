using System;

namespace MusicAlgebra
{
    public enum Note
    {
        A,
        Asharp,
        B,
        C,
        Csharp,
        D,
        Dsharp,
        E,
        F,
        Fsharp,
        G,
        Gsharp,
    }

    public static class NoteNames
    {
        private static readonly string[] NAMES = new[] { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#" };

        public static string Get(Note note)
        {
            return NAMES[(int)note];
        }
    }
}