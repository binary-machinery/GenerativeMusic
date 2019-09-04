using MusicAlgebra;
using NUnit.Framework;

namespace Tests
{
    public class OperatorsAddOctavesTest
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
        public void AddOctave()
        {
            Pitch newPitch = Operators.AddOctaves(_pitch, 1);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(5, newPitch.octave);
        }

        [Test]
        public void AddOctavesMultiple()
        {
            Pitch newPitch = Operators.AddOctaves(_pitch, 3);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(7, newPitch.octave);
        }

        [Test]
        public void AddOctaveNegative()
        {
            Pitch newPitch = Operators.AddOctaves(_pitch, -1);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(3, newPitch.octave);
        }

        [Test]
        public void AddOctavesMultipleNegative()
        {
            Pitch newPitch = Operators.AddOctaves(_pitch, -3);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(1, newPitch.octave);
        }

        [Test]
        public void AddOctavesMultipleNegativeWithOverflow()
        {
            Pitch newPitch = Operators.AddOctaves(_pitch, -5);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(-1, newPitch.octave);
        }
    }
}