using System.Collections.Generic;
using UnityEngine;
using MusicAlgebra;

public class AudioSourceInstrument : AbstractInstrument
{
    private Dictionary<Note, Dictionary<int, AudioSource>> _sources;

    private void Awake()
    {
        _sources = new Dictionary<Note, Dictionary<int, AudioSource>>();
        PitchComp[] pitchComps = transform.GetComponentsInChildren<PitchComp>();
        foreach (PitchComp pitchComp in pitchComps)
        {
            Pitch pitch = pitchComp.pitch;
            Dictionary<int, AudioSource> notesByOctaves = _sources.GetOrCreateDefault(pitch.note);
            notesByOctaves[pitch.octave] = pitchComp.GetComponent<AudioSource>();
        }
    }

    public override AbstractSoundController PlayNote(Pitch pitch, float volume, int durationTimeQuanta)
    {
        AudioSource source = GetAudioSourceForNote(pitch);
        if (source != null)
        {
            source.volume = volume;
            source.Play();
        }
        return null; // TODO: return something
    }

    private AudioSource GetAudioSourceForNote(Pitch pitch)
    {
        Dictionary<int, AudioSource> notesByOctaves = _sources.GetOrDefault(pitch.note);
        if (notesByOctaves == null)
            return null;

        AudioSource note = notesByOctaves.GetOrDefault(pitch.octave);
        if (note != null)
            return note;

        if (notesByOctaves.Count == 0)
            return null;

        int nearestOctave = int.MaxValue;
        int minDelta = int.MaxValue;
        foreach (KeyValuePair<int, AudioSource> kv in notesByOctaves)
        {
            int delta = Mathf.Abs(kv.Key - pitch.octave);
            if (delta < minDelta)
            {
                minDelta = delta;
                nearestOctave = kv.Key;
            }
        }
        return notesByOctaves[nearestOctave];
    }
}
