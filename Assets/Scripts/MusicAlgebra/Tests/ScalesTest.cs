using NUnit.Framework;
using MusicAlgebra;

namespace Tests
{
    public class ScalesTest
    {
        private static readonly Note[] C_MAJOR =
        {
            Note.C,
            Note.D,
            Note.E,
            Note.F,
            Note.G,
            Note.A,
            Note.B,
        };
        
        private static readonly Note[] F_SHARP_MINOR =
        {
            Note.Fsharp,
            Note.Gsharp,
            Note.A,
            Note.B,
            Note.Csharp,
            Note.D,
            Note.E,
        };

        private static readonly AcademicChord[] C_MAJOR_CHORDS =
        {
            new AcademicChord(Note.C, new[] { Note.C, Note.E, Note.G }),
            new AcademicChord(Note.D, new[] { Note.D, Note.F, Note.A }),
            new AcademicChord(Note.E, new[] { Note.E, Note.G, Note.B }),
            new AcademicChord(Note.F, new[] { Note.F, Note.A, Note.C }),
            new AcademicChord(Note.G, new[] { Note.G, Note.B, Note.D }),
            new AcademicChord(Note.A, new[] { Note.A, Note.C, Note.E }),
            new AcademicChord(Note.B, new[] { Note.B, Note.D, Note.F }),
        };

        [Test]
        public void CreateCMajor()
        {
            AcademicScale actual = ScaleHelper.Create(Note.C, ScaleType.Major);
            Assert.AreEqual(C_MAJOR, actual.notes);
        }
        
        [Test]
        public void CreateFSharpMinor()
        {
            AcademicScale actual = ScaleHelper.Create(Note.Fsharp, ScaleType.Minor);
            Assert.AreEqual(F_SHARP_MINOR, actual.notes);
        }

        [Test]
        public void GenerateAcademicChordsCMajor()
        {
            AcademicScale academicScale = ScaleHelper.Create(Note.C, ScaleType.Major);
            AcademicChord[] academicChords = ScaleHelper.GenerateAcademicChords(academicScale);
            for (int i = 0; i < academicChords.Length; ++i)
            {
                Assert.AreEqual(C_MAJOR_CHORDS[i].notes, academicChords[i].notes);
            }
        }
    }
}