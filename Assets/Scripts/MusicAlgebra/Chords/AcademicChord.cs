using System.Text;

namespace MusicAlgebra
{
    public class AcademicChord
    {
        public Note root { get; }
        public Note[] notes { get; }

        public AcademicChord(Note root, Note[] notes)
        {
            this.root = root;
            this.notes = notes;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(NoteNames.Get(root));
            if (notes.Length >= 3)
            {
                int diff1 = Operators.GetAbsSemitonesDifference(notes[1], notes[0]);
                int diff2 = Operators.GetAbsSemitonesDifference(notes[2], notes[0]);
                switch (diff1)
                {
                    case 4 when diff2 == 7:
                        builder.Append("maj");
                        break;
                    case 3 when diff2 == 7:
                        builder.Append("min");
                        break;
                    case 3 when diff2 == 6:
                        builder.Append("dim");
                        break;
                }
            }
            return builder.ToString();
        }
    }
}