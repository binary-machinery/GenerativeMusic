using NUnit.Framework;
using MusicAlgebra;

namespace Tests
{
    public class ScalesTest
    {
        private static readonly Pitch[] C_MAJOR =
        {
            new Pitch(Note.C, 4),
            new Pitch(Note.D, 4),
            new Pitch(Note.E, 4),
            new Pitch(Note.F, 4),
            new Pitch(Note.G, 4),
            new Pitch(Note.A, 4),
            new Pitch(Note.B, 4),
        };
        
        private static readonly Pitch[] F_SHARP_MINOR =
        {
            new Pitch(Note.Fsharp, 4),
            new Pitch(Note.Gsharp, 4),
            new Pitch(Note.A, 4),
            new Pitch(Note.B, 4),
            new Pitch(Note.Csharp, 5),
            new Pitch(Note.D, 5),
            new Pitch(Note.E, 5),
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
            Scale actual = ScaleHelper.Create(new Pitch(Note.C, 4), ScaleType.Major);
            Assert.AreEqual(C_MAJOR, actual.pitches);
        }
        
        [Test]
        public void CreateFSharpMinor()
        {
            Scale actual = ScaleHelper.Create(new Pitch(Note.Fsharp, 4), ScaleType.Minor);
            Assert.AreEqual(F_SHARP_MINOR, actual.pitches);
        }

        [Test]
        public void GenerateAcademicChordsCMajor()
        {
            Scale scale = ScaleHelper.Create(new Pitch(Note.C, 4), ScaleType.Major);
            AcademicChord[] academicChords = ScaleHelper.GenerateAcademicChords(scale);
            for (int i = 0; i < academicChords.Length; ++i)
            {
                Assert.AreEqual(C_MAJOR_CHORDS[i].notes, academicChords[i].notes);
            }
        }
    }
}