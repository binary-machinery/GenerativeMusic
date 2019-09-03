using System;
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
            Array.Sort(this.notes);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(NoteNames.Get(root));
            if (notes.Length >= 2)
            {
                int difference = Operators.GetSemitonesDifference(notes[1], notes[0]);
                switch (difference)
                {
                    case 4:
                        builder.Append("Maj");
                        break;
                    case 3:
                        builder.Append("Min");
                        break;
                }
            }
            return builder.ToString();
        }
    }
}