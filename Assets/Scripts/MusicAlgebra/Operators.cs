namespace MusicAlgebra
{
    public static class Operators
    {
        public static Note addSemitones(Note note, int semitones)
        {
            int tone = (int)note.tone + semitones;
            int octave = note.octave;

            if (tone > 0)
            {
                octave += tone / Defines.SEMITONES_COUNT;
            }
            else if (tone < 0)
            {
                octave += (tone - Defines.SEMITONES_COUNT) / Defines.SEMITONES_COUNT;
            }

            tone %= Defines.SEMITONES_COUNT;
            if (tone < 0)
            {
                tone += Defines.SEMITONES_COUNT;
            }

            return new Note
            {
                tone = (Tone)tone,
                octave = octave,
            };
        }

        public static Note addOctaves(Note note, int octaves)
        {
            return new Note
            {
                tone = note.tone,
                octave = note.octave += octaves,
            };
        }
    }
}