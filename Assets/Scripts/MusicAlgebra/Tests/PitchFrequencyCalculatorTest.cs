using MusicAlgebra;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class PitchFrequencyCalculatorTest
    {
        [Test]
        public void RefPitchA4()
        {
            float frequency = PitchFrequencyCalculator.GetFrequency(new Pitch(Note.A, 4));
            Assert.AreEqual(true, compareFrequencies(frequency, 440f));
        }

        [Test]
        public void PitchA3()
        {
            float frequency = PitchFrequencyCalculator.GetFrequency(new Pitch(Note.A, 3));
            Assert.AreEqual(true, compareFrequencies(frequency, 220f));
        }

        [Test]
        public void PitchA5()
        {
            float frequency = PitchFrequencyCalculator.GetFrequency(new Pitch(Note.A, 5));
            Assert.AreEqual(true, compareFrequencies(frequency, 880f));
        }

        [Test]
        public void PitchCsharp2()
        {
            float frequency = PitchFrequencyCalculator.GetFrequency(new Pitch(Note.Csharp, 2));
            Assert.AreEqual(true, compareFrequencies(frequency, 69.30f));
        }

        [Test]
        public void PitchD1()
        {
            float frequency = PitchFrequencyCalculator.GetFrequency(new Pitch(Note.D, 1));
            Assert.AreEqual(true, compareFrequencies(frequency, 36.71f));
        }

        [Test]
        public void PitchFsharp7()
        {
            float frequency = PitchFrequencyCalculator.GetFrequency(new Pitch(Note.Fsharp, 7));
            Assert.AreEqual(true, compareFrequencies(frequency, 2959.96f));
        }

        [Test]
        public void PitchG8()
        {
            float frequency = PitchFrequencyCalculator.GetFrequency(new Pitch(Note.G, 8));
            Assert.AreEqual(true, compareFrequencies(frequency, 6271.93f));
        }

        private bool compareFrequencies(float frequency1, float frequency2)
        {
            return Mathf.Abs(frequency1 - frequency2) < 0.05f;
        }
    }
}