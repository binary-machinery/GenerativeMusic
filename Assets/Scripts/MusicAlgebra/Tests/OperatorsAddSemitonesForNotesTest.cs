using MusicAlgebra;
using NUnit.Framework;

namespace Tests
{
    public class OperatorsAddSemitonesForNotesTest
    {
        [Test]
        public void AddSemitoneForNotes()
        {
            Note newNote = Operators.AddSemitones(Note.D, 1);
            Assert.AreEqual(Note.Dsharp, newNote);
        }
        
        [Test]
        public void AddSemitoneForNotesMultiple()
        {
            Note newNote = Operators.AddSemitones(Note.D, 4);
            Assert.AreEqual(Note.Fsharp, newNote);
        }
        
        [Test]
        public void AddSemitoneForNotesWithOverflow()
        {
            Note newNote = Operators.AddSemitones(Note.Fsharp, 10);
            Assert.AreEqual(Note.E, newNote);
        }
        
        [Test]
        public void AddSemitoneForNotesNegativeOne()
        {
            Note newNote = Operators.AddSemitones(Note.D, -1);
            Assert.AreEqual(Note.Csharp, newNote);
        }
        
        [Test]
        public void AddSemitoneForNotesMultipleNegative()
        {
            Note newNote = Operators.AddSemitones(Note.F, -3);
            Assert.AreEqual(Note.D, newNote);
        }
        
        [Test]
        public void AddSemitoneForNotesNegativeWithOverflow()
        {
            Note newNote = Operators.AddSemitones(Note.F, -10);
            Assert.AreEqual(Note.G, newNote);
        }
    }
}