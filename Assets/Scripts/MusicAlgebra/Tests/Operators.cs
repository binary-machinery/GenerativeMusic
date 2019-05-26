using NUnit.Framework;

namespace Tests
{
    public class Operators
    {
        private MusicAlgebra.Note note;

        [SetUp]
        public void SetUp()
        {
            note = new MusicAlgebra.Note
            {
                tone = MusicAlgebra.Tone.F,
                octave = 4,
            };
        }

        [Test]
        public void OperatorsAddSemitone()
        {
            MusicAlgebra.Note newNote = MusicAlgebra.Operators.addSemitones(note, 1);
            Assert.AreEqual(MusicAlgebra.Tone.Fsharp, newNote.tone);
            Assert.AreEqual(4, newNote.octave);
        }

        [Test]
        public void OperatorsAddWholeTone()
        {
            MusicAlgebra.Note newNote = MusicAlgebra.Operators.addSemitones(note, 2);
            Assert.AreEqual(MusicAlgebra.Tone.G, newNote.tone);
            Assert.AreEqual(4, newNote.octave);
        }

        [Test]
        public void OperatorsAddSemitonesWithOverflow()
        {
            MusicAlgebra.Note newNote = MusicAlgebra.Operators.addSemitones(note, 8);
            Assert.AreEqual(MusicAlgebra.Tone.Csharp, newNote.tone);
            Assert.AreEqual(5, newNote.octave);
        }

        [Test]
        public void OperatorsAddSemitonesWithDoubleOverflow()
        {
            MusicAlgebra.Note newNote = MusicAlgebra.Operators.addSemitones(note, 20);
            Assert.AreEqual(MusicAlgebra.Tone.Csharp, newNote.tone);
            Assert.AreEqual(6, newNote.octave);
        }

        [Test]
        public void OperatorsAddSemitonesForOctave()
        {
            MusicAlgebra.Note newNote = MusicAlgebra.Operators.addSemitones(note, 12);
            Assert.AreEqual(MusicAlgebra.Tone.F, newNote.tone);
            Assert.AreEqual(5, newNote.octave);
        }

        [Test]
        public void OperatorsSubtractSemitone()
        {
            MusicAlgebra.Note newNote = MusicAlgebra.Operators.addSemitones(note, -1);
            Assert.AreEqual(MusicAlgebra.Tone.E, newNote.tone);
            Assert.AreEqual(4, newNote.octave);
        }

        [Test]
        public void OperatorsSubtractWholeTone()
        {
            MusicAlgebra.Note newNote = MusicAlgebra.Operators.addSemitones(note, -2);
            Assert.AreEqual(MusicAlgebra.Tone.Dsharp, newNote.tone);
            Assert.AreEqual(4, newNote.octave);
        }

        [Test]
        public void OperatorsSubtractWholeToneWithOverflow()
        {
            MusicAlgebra.Note newNote = MusicAlgebra.Operators.addSemitones(note, -8);
            Assert.AreEqual(MusicAlgebra.Tone.A, newNote.tone);
            Assert.AreEqual(3, newNote.octave);
        }

        [Test]
        public void OperatorsSubtractWholeToneWithDoubleOverflow()
        {
            MusicAlgebra.Note newNote = MusicAlgebra.Operators.addSemitones(note, -20);
            Assert.AreEqual(MusicAlgebra.Tone.A, newNote.tone);
            Assert.AreEqual(2, newNote.octave);
        }

        [Test]
        public void OperatorsSubtractSemitonesForOctave()
        {
            MusicAlgebra.Note newNote = MusicAlgebra.Operators.addSemitones(note, -12);
            Assert.AreEqual(MusicAlgebra.Tone.F, newNote.tone);
            Assert.AreEqual(3, newNote.octave);
        }

        [Test]
        public void OperatorsAddOctave()
        {
            MusicAlgebra.Note newNote = MusicAlgebra.Operators.addOctaves(note, 1);
            Assert.AreEqual(MusicAlgebra.Tone.F, newNote.tone);
            Assert.AreEqual(5, newNote.octave);
        }

        [Test]
        public void OperatorsAddMultipleOctaves()
        {
            MusicAlgebra.Note newNote = MusicAlgebra.Operators.addOctaves(note, 3);
            Assert.AreEqual(MusicAlgebra.Tone.F, newNote.tone);
            Assert.AreEqual(7, newNote.octave);
        }

        [Test]
        public void OperatorsSubtractOctave()
        {
            MusicAlgebra.Note newNote = MusicAlgebra.Operators.addOctaves(note, -1);
            Assert.AreEqual(MusicAlgebra.Tone.F, newNote.tone);
            Assert.AreEqual(3, newNote.octave);
        }

        [Test]
        public void OperatorsSubtractMultipleOctaves()
        {
            MusicAlgebra.Note newNote = MusicAlgebra.Operators.addOctaves(note, -3);
            Assert.AreEqual(MusicAlgebra.Tone.F, newNote.tone);
            Assert.AreEqual(1, newNote.octave);
        }

        [Test]
        public void OperatorsSubtractMultipleOctavesWithOverflow()
        {
            MusicAlgebra.Note newNote = MusicAlgebra.Operators.addOctaves(note, -5);
            Assert.AreEqual(MusicAlgebra.Tone.F, newNote.tone);
            Assert.AreEqual(-1, newNote.octave);
        }
    }
}
