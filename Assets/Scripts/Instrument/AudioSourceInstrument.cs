using System.Collections.Generic;
using UnityEngine;

public class AudioSourceInstrument : AbstractInstrument
{
    private Dictionary<NoteType, Dictionary<int, AudioSource>> _notes;

    private void Awake()
    {
        _notes = new Dictionary<NoteType, Dictionary<int, AudioSource>>();
        NoteDescriptorComp[] noteDescriptorComps = transform.GetComponentsInChildren<NoteDescriptorComp>();
        foreach (NoteDescriptorComp noteDescriptorComp in noteDescriptorComps)
        {
            NoteDescriptor desc = noteDescriptorComp.noteDescriptor;
            Dictionary<int, AudioSource> notesByOctaves = _notes.GetOrCreateDefault(desc.noteType);
            notesByOctaves[desc.octave] = noteDescriptorComp.GetComponent<AudioSource>();
        }
    }

    public override void PlayNote(NoteDescriptor noteDescriptor, float volume)
    {
        AudioSource source = GetAudioSourceForNote(noteDescriptor);
        if (source != null)
        {
            source.volume = volume;
            source.Play();
        }
    }

    private AudioSource GetAudioSourceForNote(NoteDescriptor noteDescriptor)
    {
        Dictionary<int, AudioSource> notesByOctaves = _notes.GetOrDefault(noteDescriptor.noteType);
        if (notesByOctaves == null)
            return null;

        AudioSource note = notesByOctaves.GetOrDefault(noteDescriptor.octave);
        if (note != null)
            return note;

        if (notesByOctaves.Count == 0)
            return null;

        int nearestOctave = int.MaxValue;
        int minDelta = int.MaxValue;
        foreach (KeyValuePair<int, AudioSource> kv in notesByOctaves)
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
