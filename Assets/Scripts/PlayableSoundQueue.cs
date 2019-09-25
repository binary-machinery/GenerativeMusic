using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayableSoundQueue : MonoBehaviour
{
    private Queue<PlayableSound> _queue = new Queue<PlayableSound>();

    public Action<PlayableSound> onSoundAdded;
    public Action<PlayableSound> onSoundRemoved;

    public int count => _queue.Count;

    public void AddSound(PlayableSound sound)
    {
        _queue.Enqueue(sound);
        onSoundAdded?.Invoke(sound);
    }

    public PlayableSound GetNextForQuarterBeat(int quarterBeatNumber)
    {
        if (_queue.Count == 0 || _queue.Peek().startQuarterBeatNumber > quarterBeatNumber)
        {
            return null;
        }

        PlayableSound sound = _queue.Dequeue();
        onSoundRemoved?.Invoke(sound);
        return sound;
    }
}