namespace MusicAlgebra
{
    public static class Operators
    {
        public static Pitch AddSemitones(Pitch pitch, int semitones)
        {
            int note = (int)pitch.note + semitones;
            int octave = pitch.octave;

            if (note > 0)
            {
                octave += note / Defines.SEMITONES_COUNT;
            }
            else if (note < 0)
            {
                octave += (note - Defines.SEMITONES_COUNT) / Defines.SEMITONES_COUNT;
            }

            note %= Defines.SEMITONES_COUNT;
            if (note < 0)
            {
                note += Defines.SEMITONES_COUNT;
            }

            return new Pitch((Note)note, octave);
        }

        public static Pitch AddOctaves(Pitch note, int octaves)
        {
            return new Pitch(note.note, note.octave + octaves);
        }
        
        public static int GetSemitonesDifference(Note note1, Note note2)
        {
            return note1 - note2;
        }
        
        public static int GetAbsSemitonesDifference(Note note1, Note note2)
        {
            int diff = note1 - note2;
            if (diff < 0)
            {
                diff += Defines.SEMITONES_COUNT;
            }
            return diff;
        }

        public static int GetSemitonesDifference(Pitch pitch1, Pitch pitch2)
        {
            return pitch1.note - pitch2.note + (pitch1.octave - pitch2.octave) * Defines.SEMITONES_COUNT;
        }
    }
}