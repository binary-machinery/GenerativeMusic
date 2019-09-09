using MusicAlgebra;
using NUnit.Framework;

namespace Tests
{
    public class NoteNamesTest
    {
        [Test]
        public void TestNameForA()
        {
            Assert.AreEqual("A", NoteNames.Get(Note.A));
        }

        [Test]
        public void TestNameForAsharp()
        {
            Assert.AreEqual("A#", NoteNames.Get(Note.Asharp));
        }

        [Test]
        public void TestNameForB()
        {
            Assert.AreEqual("B", NoteNames.Get(Note.B));
        }

        [Test]
        public void TestNameForC()
        {
            Assert.AreEqual("C", NoteNames.Get(Note.C));
        }

        [Test]
        public void TestNameForCsharp()
        {
            Assert.AreEqual("C#", NoteNames.Get(Note.Csharp));
        }

        [Test]
        public void TestNameForD()
        {
            Assert.AreEqual("D", NoteNames.Get(Note.D));
        }

        [Test]
        public void TestNameForDsharp()
        {
            Assert.AreEqual("D#", NoteNames.Get(Note.Dsharp));
        }

        [Test]
        public void TestNameForE()
        {
            Assert.AreEqual("E", NoteNames.Get(Note.E));
        }

        [Test]
        public void TestNameForF()
        {
            Assert.AreEqual("F", NoteNames.Get(Note.F));
        }

        [Test]
        public void TestNameForFsharp()
        {
            Assert.AreEqual("F#", NoteNames.Get(Note.Fsharp));
        }

        [Test]
        public void TestNameForG()
        {
            Assert.AreEqual("G", NoteNames.Get(Note.G));
        }

        [Test]
        public void TestNameForGsharp()
        {
            Assert.AreEqual("G#", NoteNames.Get(Note.Gsharp));
        }
    }
}