using System.Text;

namespace MusicAlgebra
{
    public class AcademicChord
    {
        public Note root { get; }
        public Note[] notes { get; }
        public ChordType chordType { get; }

        private string _name;

        public AcademicChord(Note root, Note[] notes)
        {
            this.root = root;
            this.notes = notes;

            StringBuilder builder = new StringBuilder();
            builder.Append(NoteNames.Get(root));
            if (notes.Length >= 3)
            {
                int diff1 = Operators.GetAbsSemitonesDifference(notes[1], notes[0]);
                int diff2 = Operators.GetAbsSemitonesDifference(notes[2], notes[0]);
                switch (diff1)
                {
                    case 4 when diff2 == 7:
                        chordType = ChordType.Major;
                        builder.Append(ChordNames.Get(ChordType.Major));
                        break;

                    case 3 when diff2 == 7:
                        chordType = ChordType.Minor;
                        builder.Append(ChordNames.Get(ChordType.Minor));
                        break;

                    case 3 when diff2 == 6:
                        chordType = ChordType.Diminished;
                        builder.Append(ChordNames.Get(ChordType.Diminished));
                        break;

                    default:
                        chordType = ChordType.Undefined;
                        break;
                }
            }
            _name = builder.ToString();
        }

        public override string ToString()
        {
            return _name;
        }
    }
}