using MusicAlgebra;
using NUnit.Framework;

namespace Tests
{
    public class OperatorsAddSemitonesForPitchesTest
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
        public void AddSemitoneForPitches()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, 1);
            Assert.AreEqual(Note.Fsharp, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void AddSemitonesForPitchesMultiple()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, 2);
            Assert.AreEqual(Note.G, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void AddSemitonesForPitchesWithOverflow()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, 8);
            Assert.AreEqual(Note.Csharp, newPitch.note);
            Assert.AreEqual(5, newPitch.octave);
        }

        [Test]
        public void AddSemitonesForPitchesWithDoubleOverflow()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, 20);
            Assert.AreEqual(Note.Csharp, newPitch.note);
            Assert.AreEqual(6, newPitch.octave);
        }

        [Test]
        public void AddSemitonesForPitchesOctave()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, 12);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(5, newPitch.octave);
        }

        [Test]
        public void AddSemitoneForPitchesNegative()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, -1);
            Assert.AreEqual(Note.E, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void AddSemitonesForPitchesMultipleNegative()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, -2);
            Assert.AreEqual(Note.Dsharp, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void AddSemitoneForPitchesNegativeWithOverflow()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, -8);
            Assert.AreEqual(Note.A, newPitch.note);
            Assert.AreEqual(3, newPitch.octave);
        }

        [Test]
        public void AddSemitonesForPitchesNegativeWithDoubleOverflow()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, -20);
            Assert.AreEqual(Note.A, newPitch.note);
            Assert.AreEqual(2, newPitch.octave);
        }

        [Test]
        public void AddSemitonesForPitchesNegativeOctave()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, -12);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(3, newPitch.octave);
        }
    }
}