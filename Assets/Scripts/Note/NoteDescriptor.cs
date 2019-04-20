using System;
using UnityEngine;

[Serializable]
public struct NoteDescriptor
{
    public NoteType noteType {
        get { return _noteType; }
        set { _noteType = value; }
    }

    public int octave {
        get { return _octave; }
        set { _octave = value; }
    }

    [SerializeField]
    private NoteType _noteType;
    [SerializeField]
    private int _octave;

    public NoteDescriptor(NoteType noteType, int octave)
    {
        _noteType = noteType;
        _octave = octave;
    }
}
