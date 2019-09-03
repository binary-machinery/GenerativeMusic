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
            new Pitch(Note.C, 5),
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
            new Pitch(Note.Fsharp, 5),
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
    }
}