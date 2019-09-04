using MusicAlgebra;
using NUnit.Framework;

namespace Tests
{
    public class OperatorsGetSemitonesDifferenceForNotesTest
    {
        [Test]
        public void GetSemitonesDifferenceNotesZero()
        {
            int diff = Operators.GetSemitonesDifference(Note.A, Note.A);
            Assert.AreEqual(0, diff);
        }

        [Test]
        public void GetSemitonesDifferenceNotesOneSemitone()
        {
            int diff = Operators.GetSemitonesDifference(Note.Asharp, Note.A);
            Assert.AreEqual(1, diff);
        }

        [Test]
        public void GetSemitonesDifferenceNotesNegativeOneSemitone()
        {
            int diff = Operators.GetSemitonesDifference(Note.A, Note.Asharp);
            Assert.AreEqual(-1, diff);
        }

        [Test]
        public void GetSemitonesDifferenceNotesMultipleSemitones()
        {
            int diff = Operators.GetSemitonesDifference(Note.G, Note.E);
            Assert.AreEqual(3, diff);
        }

        [Test]
        public void GetSemitonesDifferenceNotesNegativeMultipleSemitones()
        {
            int diff = Operators.GetSemitonesDifference(Note.E, Note.A);
            Assert.AreEqual(-5, diff);
        }
    }
}