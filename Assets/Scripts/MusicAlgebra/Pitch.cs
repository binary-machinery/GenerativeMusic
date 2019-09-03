using System;
using UnityEngine;

namespace MusicAlgebra
{
    [Serializable]
    public struct Pitch : IComparable
    {
        public Note note => _note;
        public int octave => _octave;

        [SerializeField]
        private Note _note;

        [SerializeField]
        private int _octave;

        public Pitch(Note note, int octave)
        {
            _note = note;
            _octave = octave;
        }

        public override bool Equals(object obj)
        {
            return obj is Pitch pitch &&
                   _note == pitch._note &&
                   _octave == pitch._octave;
        }

        public override int GetHashCode()
        {
            var hashCode = -959723620;
            hashCode = hashCode * -1521134295 + _note.GetHashCode();
            hashCode = hashCode * -1521134295 + _octave.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return NoteNames.Get(_note) + octave;
        }

        public int CompareTo(object obj)
        {
            return Operators.GetSemitonesDifference(this, (Pitch)obj);
        }
    }
}