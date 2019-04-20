using System.Collections.Generic;
using UnityEngine;

public class AudioSourceSoundProvider : MonoBehaviour, SoundProvider
{
    private Dictionary<NoteType, Dictionary<int, Note>> _notes;

    private void Start()
    {
        _notes = new Dictionary<NoteType, Dictionary<int, Note>>();
        NoteDescriptorComp[] noteDescriptorComps = transform.GetComponentsInChildren<NoteDescriptorComp>();
        foreach (NoteDescriptorComp noteDescriptorComp in noteDescriptorComps)
        {
            NoteDescriptor desc = noteDescriptorComp.noteDescriptor;
            Dictionary<int, Note> notesByOctaves = _notes.GetOrCreateDefault(desc.noteType);
            notesByOctaves[desc.octave] = noteDescriptorComp.transform.GetComponent<Note>();
        }
    }

    public Sound GetSound(NoteDescriptor noteDescriptor)
    {
        Dictionary<int, Note> notesByOctaves = _notes.GetOrDefault(noteDescriptor.noteType);
        if (notesByOctaves == null)
            return null;

        Note note = notesByOctaves.GetOrDefault(noteDescriptor.octave);
        if (note != null)
            return note;

        if (notesByOctaves.Count == 0)
            return null;

        int nearestOctave = int.MaxValue;
        int minDelta = int.MaxValue;
        foreach (KeyValuePair<int, Note> kv in notesByOctaves)
        {
            int delta = Mathf.Abs(kv.Key - noteDescriptor.octave);
            if (delta < minDelta)
            {
                minDelta = delta;
                nearestOctave = kv.Key;
            }
        }
        return notesByOctaves[nearestOctave];
    }
}
