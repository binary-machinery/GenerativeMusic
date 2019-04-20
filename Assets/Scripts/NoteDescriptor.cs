using System;

[Serializable]
public class NoteDescriptor
{
    public NoteType noteType { get; set; }
    public int octave { get; set; }
}
