using System;

namespace MusicAlgebra
{
    public class PhysicalChord
    {
        public Pitch root { get; }
        public Pitch[] pitches { get; }
        public AcademicChord academicChord { get; }

        public PhysicalChord(Pitch root, Pitch[] pitches, AcademicChord academicChord)
        {
            this.root = root;
            this.pitches = pitches;
            this.academicChord = academicChord;
        }

        public override string ToString()
        {
            return academicChord.ToString();
        }
    }
}