using MusicAlgebra;
using NUnit.Framework;

namespace Tests
{
    public class NoteNamesTest
    {
        [Test]
        public void testNameForA()
        {
            Assert.AreEqual("A", NoteNames.Get(Note.A));
        }

        [Test]
        public void testNameForAsharp()
        {
            Assert.AreEqual("A#", NoteNames.Get(Note.Asharp));
        }

        [Test]
        public void testNameForB()
        {
            Assert.AreEqual("B", NoteNames.Get(Note.B));
        }

        [Test]
        public void testNameForC()
        {
            Assert.AreEqual("C", NoteNames.Get(Note.C));
        }

        [Test]
        public void testNameForCsharp()
        {
            Assert.AreEqual("C#", NoteNames.Get(Note.Csharp));
        }

        [Test]
        public void testNameForD()
        {
            Assert.AreEqual("D", NoteNames.Get(Note.D));
        }

        [Test]
        public void testNameForDsharp()
        {
            Assert.AreEqual("D#", NoteNames.Get(Note.Dsharp));
        }

        [Test]
        public void testNameForE()
        {
            Assert.AreEqual("E", NoteNames.Get(Note.E));
        }

        [Test]
        public void testNameForF()
        {
            Assert.AreEqual("F", NoteNames.Get(Note.F));
        }

        [Test]
        public void testNameForFsharp()
        {
            Assert.AreEqual("F#", NoteNames.Get(Note.Fsharp));
        }

        [Test]
        public void testNameForG()
        {
            Assert.AreEqual("G", NoteNames.Get(Note.G));
        }

        [Test]
        public void testNameForGsharp()
        {
            Assert.AreEqual("G#", NoteNames.Get(Note.Gsharp));
        }
    }
}