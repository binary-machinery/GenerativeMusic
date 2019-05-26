namespace MusicAlgebra
{
    public static class Operators
    {
        public static Pitch addSemitones(Pitch pitch, sbyte semitones)
        {
            sbyte tone = (sbyte)(pitch.note + semitones);
            sbyte octave = pitch.octave;

            if (tone > 0)
            {
                octave += (sbyte)(tone / Defines.SEMITONES_COUNT);
            }
            else if (tone < 0)
            {
                octave += (sbyte)((tone - Defines.SEMITONES_COUNT) / Defines.SEMITONES_COUNT);
            }

            tone %= Defines.SEMITONES_COUNT;
            if (tone < 0)
            {
                tone += Defines.SEMITONES_COUNT;
            }

            return new Pitch
            {
                note = (Note)tone,
                octave = octave,
            };
        }

        public static Pitch addOctaves(Pitch note, sbyte octaves)
        {
            return new Pitch
            {
                note = note.note,
                octave = (sbyte)(note.octave + octaves),
            };
        }
    }
}