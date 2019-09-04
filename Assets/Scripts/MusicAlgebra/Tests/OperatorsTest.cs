using MusicAlgebra;
using NUnit.Framework;

namespace Tests
{
    public class OperatorsTest
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
        public void OperatorsAddSemitoneForNotes()
        {
            Note newNote = Operators.AddSemitones(Note.D, 1);
            Assert.AreEqual(Note.Dsharp, newNote);
        }
        
        [Test]
        public void OperatorsAddSemitoneForNotesMultiple()
        {
            Note newNote = Operators.AddSemitones(Note.D, 4);
            Assert.AreEqual(Note.Fsharp, newNote);
        }
        
        [Test]
        public void OperatorsAddSemitoneForNotesWithOverflow()
        {
            Note newNote = Operators.AddSemitones(Note.Fsharp, 10);
            Assert.AreEqual(Note.E, newNote);
        }
        
        [Test]
        public void OperatorsSubtractSemitoneForNotes()
        {
            Note newNote = Operators.AddSemitones(Note.D, -1);
            Assert.AreEqual(Note.Csharp, newNote);
        }
        
        [Test]
        public void OperatorsSubtractSemitoneForNotesMultiple()
        {
            Note newNote = Operators.AddSemitones(Note.F, -3);
            Assert.AreEqual(Note.D, newNote);
        }
        
        [Test]
        public void OperatorsSubtractSemitoneForNotesWithOverflow()
        {
            Note newNote = Operators.AddSemitones(Note.F, -10);
            Assert.AreEqual(Note.G, newNote);
        }

        [Test]
        public void OperatorsAddSemitone()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, 1);
            Assert.AreEqual(Note.Fsharp, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void OperatorsAddWholeTone()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, 2);
            Assert.AreEqual(Note.G, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void OperatorsAddSemitonesWithOverflow()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, 8);
            Assert.AreEqual(Note.Csharp, newPitch.note);
            Assert.AreEqual(5, newPitch.octave);
        }

        [Test]
        public void OperatorsAddSemitonesWithDoubleOverflow()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, 20);
            Assert.AreEqual(Note.Csharp, newPitch.note);
            Assert.AreEqual(6, newPitch.octave);
        }

        [Test]
        public void OperatorsAddSemitonesForOctave()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, 12);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(5, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractSemitone()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, -1);
            Assert.AreEqual(Note.E, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractWholeTone()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, -2);
            Assert.AreEqual(Note.Dsharp, newPitch.note);
            Assert.AreEqual(4, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractWholeToneWithOverflow()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, -8);
            Assert.AreEqual(Note.A, newPitch.note);
            Assert.AreEqual(3, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractWholeToneWithDoubleOverflow()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, -20);
            Assert.AreEqual(Note.A, newPitch.note);
            Assert.AreEqual(2, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractSemitonesForOctave()
        {
            Pitch newPitch = Operators.AddSemitones(_pitch, -12);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(3, newPitch.octave);
        }

        [Test]
        public void OperatorsAddOctave()
        {
            Pitch newPitch = Operators.AddOctaves(_pitch, 1);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(5, newPitch.octave);
        }

        [Test]
        public void OperatorsAddMultipleOctaves()
        {
            Pitch newPitch = Operators.AddOctaves(_pitch, 3);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(7, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractOctave()
        {
            Pitch newPitch = Operators.AddOctaves(_pitch, -1);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(3, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractMultipleOctaves()
        {
            Pitch newPitch = Operators.AddOctaves(_pitch, -3);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(1, newPitch.octave);
        }

        [Test]
        public void OperatorsSubtractMultipleOctavesWithOverflow()
        {
            Pitch newPitch = Operators.AddOctaves(_pitch, -5);
            Assert.AreEqual(Note.F, newPitch.note);
            Assert.AreEqual(-1, newPitch.octave);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceZero()
        {
            Pitch pitch1 = new Pitch(Note.Asharp, 4);
            Pitch pitch2 = new Pitch(Note.Asharp, 4);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(0, diff);
        }

        [Test]
        public void OperatorsGetSemitonesDifferenceOneSemitone()
        {
            Pitch pitch1 = new Pitch(Note.Asharp, 4);
            Pitch pitch2 = new Pitch(Note.A, 4);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(1, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceNegativeOneSemitone()
        {
            Pitch pitch1 = new Pitch(Note.A, 4);
            Pitch pitch2 = new Pitch(Note.Asharp, 4);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(-1, diff);
        }

        [Test]
        public void OperatorsGetSemitonesDifferenceMultipleSemitones()
        {
            Pitch pitch1 = new Pitch(Note.Gsharp, 4);
            Pitch pitch2 = new Pitch(Note.Dsharp, 4);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(5, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceNegativeMultipleSemitones()
        {
            Pitch pitch1 = new Pitch(Note.Dsharp, 4);
            Pitch pitch2 = new Pitch(Note.Gsharp, 4);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(-5, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceOneOctave()
        {
            Pitch pitch1 = new Pitch(Note.C, 4);
            Pitch pitch2 = new Pitch(Note.C, 3);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(Defines.SEMITONES_COUNT, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceNegativeOneOctave()
        {
            Pitch pitch1 = new Pitch(Note.C, 3);
            Pitch pitch2 = new Pitch(Note.C, 4);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(-Defines.SEMITONES_COUNT, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceMultipleOctaves()
        {
            Pitch pitch1 = new Pitch(Note.C, 7);
            Pitch pitch2 = new Pitch(Note.C, 3);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(4 * Defines.SEMITONES_COUNT, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceNegativeMultipleOctaves()
        {
            Pitch pitch1 = new Pitch(Note.C, 3);
            Pitch pitch2 = new Pitch(Note.C, 7);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(-4 * Defines.SEMITONES_COUNT, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifference()
        {
            Pitch pitch1 = new Pitch(Note.Fsharp, 5);
            Pitch pitch2 = new Pitch(Note.B, 3);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(19, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceNegative()
        {
            Pitch pitch1 = new Pitch(Note.E, 4);
            Pitch pitch2 = new Pitch(Note.Gsharp, 7);
            int diff = Operators.GetSemitonesDifference(pitch1, pitch2);
            Assert.AreEqual(-40, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceNotesZero()
        {
            int diff = Operators.GetSemitonesDifference(Note.A, Note.A);
            Assert.AreEqual(0, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceNotesOneSemitone()
        {
            int diff = Operators.GetSemitonesDifference(Note.Asharp, Note.A);
            Assert.AreEqual(1, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceNotesNegativeOneSemitone()
        {
            int diff = Operators.GetSemitonesDifference(Note.A, Note.Asharp);
            Assert.AreEqual(-1, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceNotesMultipleSemitones()
        {
            int diff = Operators.GetSemitonesDifference(Note.G, Note.E);
            Assert.AreEqual(3, diff);
        }
        
        [Test]
        public void OperatorsGetSemitonesDifferenceNotesNegativeMultipleSemitones()
        {
            int diff = Operators.GetSemitonesDifference(Note.E, Note.A);
            Assert.AreEqual(-5, diff);
        }
        
        [Test]
        public void OperatorsGetAbsSemitonesDifferenceNotesZero()
        {
            int diff = Operators.GetAbsSemitonesDifference(Note.A, Note.A);
            Assert.AreEqual(0, diff);
        }
        
        [Test]
        public void OperatorsGetAbsSemitonesDifferenceNotesOneSemitone()
        {
            int diff = Operators.GetAbsSemitonesDifference(Note.Asharp, Note.A);
            Assert.AreEqual(1, diff);
        }
        
        [Test]
        public void OperatorsGetAbsSemitonesDifferenceNotesNegativeOneSemitone()
        {
            int diff = Operators.GetAbsSemitonesDifference(Note.A, Note.Asharp);
            Assert.AreEqual(11, diff);
        }
        
        [Test]
        public void OperatorsGetAbsSemitonesDifferenceNotesMultipleSemitones()
        {
            int diff = Operators.GetAbsSemitonesDifference(Note.Fsharp, Note.Dsharp);
            Assert.AreEqual(3, diff);
        }
        
        [Test]
        public void OperatorsGetAbsSemitonesDifferenceNotesNegativeMultipleSemitones()
        {
            int diff = Operators.GetAbsSemitonesDifference(Note.G, Note.B);
            Assert.AreEqual(8, diff);
        }
    }
}
