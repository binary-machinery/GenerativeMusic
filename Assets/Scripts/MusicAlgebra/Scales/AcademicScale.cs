namespace MusicAlgebra
{
    public class AcademicScale
    {
        public ScaleType scaleType { get; }
        public Note[] notes { get; }
        public Note rootNote => notes[0];

        public AcademicScale(ScaleType scaleType, Note[] notes)
        {
            this.scaleType = scaleType;
            this.notes = notes;
        }

        public override string ToString()
        {
            return NoteNames.Get(rootNote) + scaleType;
        }
    }
}