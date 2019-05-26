using NUnit.Framework;

namespace Tests
{
    public class Operators
    {
        private MusicAlgebra.Pitch pitch;

        [SetUp]
        public void SetUp()
        {
            pitch = new MusicAlgebra.Pitch
            {
                note = MusicAlgebra.Note.F,
                octave = 4,
            };
        }

        [Test]
        public void OperatorsAddSemitone()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(pitch, 1);
            Assert.AreEqual(MusicAlgebra.Note.Fsharp, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void OperatorsAddWholeTone()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(pitch, 2);
            Assert.AreEqual(MusicAlgebra.Note.G, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void OperatorsAddSemitonesWithOverflow()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(pitch, 8);
            Assert.AreEqual(MusicAlgebra.Note.Csharp, newPitch.note);
            Assert.AreEqual(5, newPitch.octave);
        }

        [Test]
        public void OperatorsAddSemitonesWithDoubleOverflow()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(pitch, 20);
            Assert.AreEqual(MusicAlgebra.Note.Csharp, newPitch.note);
            Assert.AreEqual(6, newPitch.octave);
        }

        [Test]
        public void OperatorsAddSemitonesForOctave()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(pitch, 12);
            Assert.AreEqual(MusicAlgebra.Note.F, newPitch.note);
            Assert.AreEqual(5, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractSemitone()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(pitch, -1);
            Assert.AreEqual(MusicAlgebra.Note.E, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractWholeTone()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(pitch, -2);
            Assert.AreEqual(MusicAlgebra.Note.Dsharp, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractWholeToneWithOverflow()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(pitch, -8);
            Assert.AreEqual(MusicAlgebra.Note.A, newPitch.note);
            Assert.AreEqual(3, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractWholeToneWithDoubleOverflow()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(pitch, -20);
            Assert.AreEqual(MusicAlgebra.Note.A, newPitch.note);
            Assert.AreEqual(2, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractSemitonesForOctave()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addSemitones(pitch, -12);
            Assert.AreEqual(MusicAlgebra.Note.F, newPitch.note);
            Assert.AreEqual(3, newPitch.octave);
        }

        [Test]
        public void OperatorsAddOctave()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addOctaves(pitch, 1);
            Assert.AreEqual(MusicAlgebra.Note.F, newPitch.note);
            Assert.AreEqual(5, newPitch.octave);
        }

        [Test]
        public void OperatorsAddMultipleOctaves()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addOctaves(pitch, 3);
            Assert.AreEqual(MusicAlgebra.Note.F, newPitch.note);
            Assert.AreEqual(7, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractOctave()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addOctaves(pitch, -1);
            Assert.AreEqual(MusicAlgebra.Note.F, newPitch.note);
            Assert.AreEqual(3, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractMultipleOctaves()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addOctaves(pitch, -3);
            Assert.AreEqual(MusicAlgebra.Note.F, newPitch.note);
            Assert.AreEqual(1, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractMultipleOctavesWithOverflow()
        {
            MusicAlgebra.Pitch newPitch = MusicAlgebra.Operators.addOctaves(pitch, -5);
            Assert.AreEqual(MusicAlgebra.Note.F, newPitch.note);
            Assert.AreEqual(-1, newPitch.octave);
        }
    }
}
