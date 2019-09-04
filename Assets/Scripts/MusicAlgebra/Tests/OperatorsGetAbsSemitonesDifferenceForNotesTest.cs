using MusicAlgebra;
using NUnit.Framework;

namespace Tests
{
    public class OperatorsGetAbsSemitonesDifferenceForNotesTest
    {
        [Test]
        public void GetAbsSemitonesDifferenceNotesZero()
        {
            int diff = Operators.GetAbsSemitonesDifference(Note.A, Note.A);
            Assert.AreEqual(0, diff);
        }

        [Test]
        public void GetAbsSemitonesDifferenceNotesOneSemitone()
        {
            int diff = Operators.GetAbsSemitonesDifference(Note.Asharp, Note.A);
            Assert.AreEqual(1, diff);
        }

        [Test]
        public void GetAbsSemitonesDifferenceNotesNegativeOneSemitone()
        {
            int diff = Operators.GetAbsSemitonesDifference(Note.A, Note.Asharp);
            Assert.AreEqual(11, diff);
        }

        [Test]
        public void GetAbsSemitonesDifferenceNotesMultipleSemitones()
        {
            int diff = Operators.GetAbsSemitonesDifference(Note.Fsharp, Note.Dsharp);
            Assert.AreEqual(3, diff);
        }

        [Test]
        public void GetAbsSemitonesDifferenceNotesNegativeMultipleSemitones()
        {
            int diff = Operators.GetAbsSemitonesDifference(Note.G, Note.B);
            Assert.AreEqual(8, diff);
        }
    }
}