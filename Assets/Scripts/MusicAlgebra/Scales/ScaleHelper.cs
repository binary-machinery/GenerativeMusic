using System.Collections.Generic;

namespace MusicAlgebra
{
    public static class ScaleHelper
    {
        private static readonly Dictionary<ScaleType, int[]> PATTERNS = new Dictionary<ScaleType, int[]>()
        {
            { ScaleType.Major, new[] { 2, 2, 1, 2, 2, 2 } },
            { ScaleType.Dorian, new[] { 2, 1, 2, 2, 2, 1 } },
            { ScaleType.Phrygian, new[] { 1, 2, 2, 2, 1, 2 } },
            { ScaleType.Lydian, new[] { 2, 2, 2, 1, 2, 2 } },
            { ScaleType.Mixolydian, new[] { 2, 2, 1, 2, 2, 1 } },
            { ScaleType.Minor, new[] { 2, 1, 2, 2, 1, 2 } },
            { ScaleType.Locrian, new[] { 1, 2, 2, 1, 2, 2 } },
        };

        public static AcademicScale Create(Note rootNote, ScaleType scaleType)
        {
            int[] pattern = PATTERNS[scaleType];
            Note[] notes = new Note[pattern.Length + 1];
            notes[0] = rootNote;
            for (int i = 0; i < pattern.Length; ++i)
            {
                notes[i + 1] = Operators.AddSemitones(notes[i], pattern[i]);
            }
            return new AcademicScale(scaleType, notes);
        }

        public static AcademicChord[] GenerateAcademicChords(AcademicScale academicScale)
        {
            AcademicChord[] chords = new AcademicChord[academicScale.notes.Length];
            for (int i = 0; i < academicScale.notes.Length; ++i)
            {
                Note[] notes = new Note[3];
                notes[0] = academicScale.notes[i];
                notes[1] = academicScale.notes[(i + 2) % academicScale.notes.Length];
                notes[2] = academicScale.notes[(i + 4) % academicScale.notes.Length];
                chords[i] = new AcademicChord(notes[0], notes);
            }
            return chords;
        }
    }
}