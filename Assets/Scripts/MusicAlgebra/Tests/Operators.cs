using NUnit.Framework;

namespace Tests
{
    public class Operators
    {
        private MusicAlgebra.Pitch _pitch;

        [SetUp]
        public void setUp()
        {
            _pitch = new MusicAlgebra.Pitch
            {
                note = MusicAlgebra.Note.F,
                octave = 4,
            };
        }

        [TearDown]
        public void verifyOriginalPitchHasNotChanged()
        {
            Assert.AreEqual(MusicAlgebra.Note.F, _pitch.note);
            Assert.AreEqual(4, _pitch.octave);
        }

        [Test]
        public void operatorsAddSemitone()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(_pitch, 1);
            Assert.AreEqual(MusicAlgebra.Note.Fsharp, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void operatorsAddWholeTone()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(_pitch, 2);
            Assert.AreEqual(MusicAlgebra.Note.G, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void operatorsAddSemitonesWithOverflow()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(_pitch, 8);
            Assert.AreEqual(MusicAlgebra.Note.Csharp, newPitch.note);
            Assert.AreEqual(5, newPitch.octave);
        }

        [Test]
        public void operatorsAddSemitonesWithDoubleOverflow()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(_pitch, 20);
            Assert.AreEqual(MusicAlgebra.Note.Csharp, newPitch.note);
            Assert.AreEqual(6, newPitch.octave);
        }

        [Test]
        public void operatorsAddSemitonesForOctave()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(_pitch, 12);
            Assert.AreEqual(MusicAlgebra.Note.F, newPitch.note);
            Assert.AreEqual(5, newPitch.octave);
        }

        [Test]
        public void operatorsSubtractSemitone()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(_pitch, -1);
            Assert.AreEqual(MusicAlgebra.Note.E, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void operatorsSubtractWholeTone()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(_pitch, -2);
            Assert.AreEqual(MusicAlgebra.Note.Dsharp, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void operatorsSubtractWholeToneWithOverflow()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(_pitch, -8);
            Assert.AreEqual(MusicAlgebra.Note.A, newPitch.note);
            Assert.AreEqual(3, newPitch.octave);
        }

        [Test]
        public void operatorsSubtractWholeToneWithDoubleOverflow()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(_pitch, -20);
            Assert.AreEqual(MusicAlgebra.Note.A, newPitch.note);
            Assert.AreEqual(2, newPitch.octave);
        }

        [Test]
        public void operatorsSubtractSemitonesForOctave()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(_pitch, -12);
            Assert.AreEqual(MusicAlgebra.Note.F, newPitch.note);
            Assert.AreEqual(3, newPitch.octave);
        }

        [Test]
        public void operatorsAddOctave()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addOctaves(_pitch, 1);
            Assert.AreEqual(MusicAlgebra.Note.F, newPitch.note);
            Assert.AreEqual(5, newPitch.octave);
        }

        [Test]
        public void operatorsAddMultipleOctaves()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addOctaves(_pitch, 3);
            Assert.AreEqual(MusicAlgebra.Note.F, newPitch.note);
            Assert.AreEqual(7, newPitch.octave);
        }

        [Test]
        public void operatorsSubtractOctave()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addOctaves(_pitch, -1);
            Assert.AreEqual(MusicAlgebra.Note.F, newPitch.note);
            Assert.AreEqual(3, newPitch.octave);
        }

        [Test]
        public void operatorsSubtractMultipleOctaves()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addOctaves(_pitch, -3);
            Assert.AreEqual(MusicAlgebra.Note.F, newPitch.note);
            Assert.AreEqual(1, newPitch.octave);
        }

        [Test]
        public void operatorsSubtractMultipleOctavesWithOverflow()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addOctaves(_pitch, -5);
            Assert.AreEqual(MusicAlgebra.Note.F, newPitch.note);
            Assert.AreEqual(-1, newPitch.octave);
        }
    }
}
