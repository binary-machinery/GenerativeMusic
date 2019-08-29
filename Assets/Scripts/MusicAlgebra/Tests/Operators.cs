using MusicAlgebra;
using NUnit.Framework;

namespace Tests
{
    public class Operators
    {
        private Pitch _pitch;

        [SetUp]
        public void SetUp()
        {
            _pitch = new Pitch(Note.F, 4);
        }

        [TearDown]
        public void VerifyOriginalPitchHasNotChanged()
        {
            Assert.AreEqual(Note.F, _pitch.note);
            Assert.AreEqual(4, _pitch.octave);
        }

        [Test]
        public void OperatorsAddSemitone()
        {
            Pitch newPitch = MusicAlgebra.Operators.AddSemitones(_pitch, 1);
            Assert.AreEqual(Note.Fsharp, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void OperatorsAddWholeTone()
        {
            Pitch newPitch = MusicAlgebra.Operators.AddSemitones(_pitch, 2);
            Assert.AreEqual(Note.G, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void OperatorsAddSemitonesWithOverflow()
        {
            Pitch newPitch = MusicAlgebra.Operators.AddSemitones(_pitch, 8);
            Assert.AreEqual(Note.Csharp, newPitch.note);
            Assert.AreEqual(5, newPitch.octave);
        }

        [Test]
        public void OperatorsAddSemitonesWithDoubleOverflow()
        {
            Pitch newPitch = MusicAlgebra.Operators.AddSemitones(_pitch, 20);
            Assert.AreEqual(Note.Csharp, newPitch.note);
            Assert.AreEqual(6, newPitch.octave);
        }

        [Test]
        public void OperatorsAddSemitonesForOctave()
        {
            Pitch newPitch = MusicAlgebra.Operators.AddSemitones(_pitch, 12);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(5, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractSemitone()
        {
            Pitch newPitch = MusicAlgebra.Operators.AddSemitones(_pitch, -1);
            Assert.AreEqual(Note.E, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractWholeTone()
        {
            Pitch newPitch = MusicAlgebra.Operators.AddSemitones(_pitch, -2);
            Assert.AreEqual(Note.Dsharp, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractWholeToneWithOverflow()
        {
            Pitch newPitch = MusicAlgebra.Operators.AddSemitones(_pitch, -8);
            Assert.AreEqual(Note.A, newPitch.note);
            Assert.AreEqual(3, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractWholeToneWithDoubleOverflow()
        {
            Pitch newPitch = MusicAlgebra.Operators.AddSemitones(_pitch, -20);
            Assert.AreEqual(Note.A, newPitch.note);
            Assert.AreEqual(2, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractSemitonesForOctave()
        {
            Pitch newPitch = MusicAlgebra.Operators.AddSemitones(_pitch, -12);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(3, newPitch.octave);
        }

        [Test]
        public void OperatorsAddOctave()
        {
            Pitch newPitch = MusicAlgebra.Operators.AddOctaves(_pitch, 1);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(5, newPitch.octave);
        }

        [Test]
        public void OperatorsAddMultipleOctaves()
        {
            Pitch newPitch = MusicAlgebra.Operators.AddOctaves(_pitch, 3);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(7, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractOctave()
        {
            Pitch newPitch = MusicAlgebra.Operators.AddOctaves(_pitch, -1);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(3, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractMultipleOctaves()
        {
            Pitch newPitch = MusicAlgebra.Operators.AddOctaves(_pitch, -3);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(1, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractMultipleOctavesWithOverflow()
        {
            Pitch newPitch = MusicAlgebra.Operators.AddOctaves(_pitch, -5);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(-1, newPitch.octave);
        }

        [Test]
        public void OperatorsGetSemitonesDifferenceOneSemitone()
        {
            Pitch pitch1 = new Pitch(Note.Asharp, 4);
            Pitch pitch2 = new Pitch(Note.A, 4);
            int diff = MusicAlgebra.Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(1, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceNegativeOneSemitone()
        {
            Pitch pitch1 = new Pitch(Note.A, 4);
            Pitch pitch2 = new Pitch(Note.Asharp, 4);
            int diff = MusicAlgebra.Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(-1, diff);
        }

        [Test]
        public void OperatorsGetSemitonesDifferenceMultipleSemitones()
        {
            Pitch pitch1 = new Pitch(Note.Gsharp, 4);
            Pitch pitch2 = new Pitch(Note.Dsharp, 4);
            int diff = MusicAlgebra.Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(5, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceNegativeMultipleSemitones()
        {
            Pitch pitch1 = new Pitch(Note.Dsharp, 4);
            Pitch pitch2 = new Pitch(Note.Gsharp, 4);
            int diff = MusicAlgebra.Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(-5, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceOneOctave()
        {
            Pitch pitch1 = new Pitch(Note.C, 4);
            Pitch pitch2 = new Pitch(Note.C, 3);
            int diff = MusicAlgebra.Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(Defines.SEMITONES_COUNT, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceNegativeOneOctave()
        {
            Pitch pitch1 = new Pitch(Note.C, 3);
            Pitch pitch2 = new Pitch(Note.C, 4);
            int diff = MusicAlgebra.Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(-Defines.SEMITONES_COUNT, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceMultipleOctaves()
        {
            Pitch pitch1 = new Pitch(Note.C, 7);
            Pitch pitch2 = new Pitch(Note.C, 3);
            int diff = MusicAlgebra.Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(4 * Defines.SEMITONES_COUNT, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceNegativeMultipleOctaves()
        {
            Pitch pitch1 = new Pitch(Note.C, 3);
            Pitch pitch2 = new Pitch(Note.C, 7);
            int diff = MusicAlgebra.Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(-4 * Defines.SEMITONES_COUNT, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifference()
        {
            Pitch pitch1 = new Pitch(Note.Fsharp, 5);
            Pitch pitch2 = new Pitch(Note.B, 3);
            int diff = MusicAlgebra.Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(19, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceNegative()
        {
            Pitch pitch1 = new Pitch(Note.E, 4);
            Pitch pitch2 = new Pitch(Note.Gsharp, 7);
            int diff = MusicAlgebra.Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(-40, diff);
        }
    }
}
