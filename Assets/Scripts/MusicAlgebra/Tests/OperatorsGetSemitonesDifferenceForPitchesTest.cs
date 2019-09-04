using MusicAlgebra;
using NUnit.Framework;

namespace Tests
{
    public class OperatorsGetSemitonesDifferenceForPitchesTest
    {
                [Test]
        public void GetSemitonesDifferenceZero()
        {
            Pitch pitch1 = new Pitch(Note.Asharp, 4);
            Pitch pitch2 = new Pitch(Note.Asharp, 4);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(0, diff);
        }

        [Test]
        public void GetSemitonesDifferenceOneSemitone()
        {
            Pitch pitch1 = new Pitch(Note.Asharp, 4);
            Pitch pitch2 = new Pitch(Note.A, 4);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(1, diff);
        }

        [Test]
        public void GetSemitonesDifferenceNegativeOneSemitone()
        {
            Pitch pitch1 = new Pitch(Note.A, 4);
            Pitch pitch2 = new Pitch(Note.Asharp, 4);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(-1, diff);
        }

        [Test]
        public void GetSemitonesDifferenceMultipleSemitones()
        {
            Pitch pitch1 = new Pitch(Note.Gsharp, 4);
            Pitch pitch2 = new Pitch(Note.Dsharp, 4);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(5, diff);
        }

        [Test]
        public void GetSemitonesDifferenceNegativeMultipleSemitones()
        {
            Pitch pitch1 = new Pitch(Note.Dsharp, 4);
            Pitch pitch2 = new Pitch(Note.Gsharp, 4);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(-5, diff);
        }

        [Test]
        public void GetSemitonesDifferenceOneOctave()
        {
            Pitch pitch1 = new Pitch(Note.C, 4);
            Pitch pitch2 = new Pitch(Note.C, 3);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(Defines.SEMITONES_COUNT, diff);
        }

        [Test]
        public void GetSemitonesDifferenceNegativeOneOctave()
        {
            Pitch pitch1 = new Pitch(Note.C, 3);
            Pitch pitch2 = new Pitch(Note.C, 4);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(-Defines.SEMITONES_COUNT, diff);
        }

        [Test]
        public void GetSemitonesDifferenceMultipleOctaves()
        {
            Pitch pitch1 = new Pitch(Note.C, 7);
            Pitch pitch2 = new Pitch(Note.C, 3);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(4 * Defines.SEMITONES_COUNT, diff);
        }

        [Test]
        public void GetSemitonesDifferenceNegativeMultipleOctaves()
        {
            Pitch pitch1 = new Pitch(Note.C, 3);
            Pitch pitch2 = new Pitch(Note.C, 7);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(-4 * Defines.SEMITONES_COUNT, diff);
        }

        [Test]
        public void GetSemitonesDifference()
        {
            Pitch pitch1 = new Pitch(Note.Fsharp, 5);
            Pitch pitch2 = new Pitch(Note.B, 3);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(19, diff);
        }

        [Test]
        public void GetSemitonesDifferenceNegative()
        {
            Pitch pitch1 = new Pitch(Note.E, 4);
            Pitch pitch2 = new Pitch(Note.Gsharp, 7);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(-40, diff);
        }
    }
}