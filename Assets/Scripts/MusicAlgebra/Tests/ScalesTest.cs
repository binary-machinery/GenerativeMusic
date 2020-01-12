using MusicAlgebra;
using NUnit.Framework;

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

        private static readonly Note[] C_MINOR =
        {
            Note.C,
            Note.D,
            Note.Dsharp,
            Note.F,
            Note.G,
            Note.Gsharp,
            Note.Asharp,
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

        private static readonly Note[] C_MAJOR_PENTATONIC =
        {
            Note.C,
            Note.D,
            Note.E,
            Note.G,
            Note.A,
        };

        private static readonly Note[] C_MINOR_PENTATONIC =
        {
            Note.C,
            Note.Dsharp,
            Note.F,
            Note.G,
            Note.Asharp,
        };
        
        private static readonly Note[] G_MINOR_PENTATONIC =
        {
            Note.G,
            Note.Asharp,
            Note.C,
            Note.D,
            Note.F,
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
        public void CreateCMinor()
        {
            AcademicScale actual = ScaleHelper.Create(Note.C, ScaleType.Minor);
            Assert.AreEqual(C_MINOR, actual.notes);
        }

        [Test]
        public void CreateFSharpMinor()
        {
            AcademicScale actual = ScaleHelper.Create(Note.Fsharp, ScaleType.Minor);
            Assert.AreEqual(F_SHARP_MINOR, actual.notes);
        }

        [Test]
        public void CreateCMajorPentatonic()
        {
            AcademicScale actual = ScaleHelper.Create(Note.C, ScaleType.MajorPentatonic);
            Assert.AreEqual(C_MAJOR_PENTATONIC, actual.notes);
        }
        
        [Test]
        public void CreateCMinorPentatonic()
        {
            AcademicScale actual = ScaleHelper.Create(Note.C, ScaleType.MinorPentatonic);
            Assert.AreEqual(C_MINOR_PENTATONIC, actual.notes);
        }
        
        [Test]
        public void CreateGMinorPentatonic()
        {
            AcademicScale actual = ScaleHelper.Create(Note.G, ScaleType.MinorPentatonic);
            Assert.AreEqual(G_MINOR_PENTATONIC, actual.notes);
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