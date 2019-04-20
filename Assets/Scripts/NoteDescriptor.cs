using System;
using UnityEngine;

[Serializable]
public class NoteDescriptor
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
    private NoteType _noteType = NoteType.C;
    [SerializeField]
    private int _octave = 4;
}
