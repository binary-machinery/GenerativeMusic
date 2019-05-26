using System;
using UnityEngine;

namespace MusicAlgebra
{
    [Serializable]
    public struct Pitch
    {
        public Note note {
            get { return _note; }
            set { _note = value; }
        }
        public sbyte octave {
            get { return _octave; }
            set { _octave = value; }
        }

        [SerializeField]
        private Note _note;
        [SerializeField]
        private sbyte _octave;

        public Pitch(Note note, sbyte octave)
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
    }
}