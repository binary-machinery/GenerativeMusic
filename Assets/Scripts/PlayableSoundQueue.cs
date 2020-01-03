using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayableSoundQueue : MonoBehaviour
{
    private Queue<PlayableSound> _queue = new Queue<PlayableSound>();

    public Action<PlayableSound> onSoundAdded;
    public Action<PlayableSound> onSoundRemoved;

    public int count => _queue.Count;

    private PlayableSound _lastSound;

    public void AddSound(PlayableSound sound)
    {
        _queue.Enqueue(sound);
        _lastSound = sound;
        onSoundAdded?.Invoke(sound);
    }

    public PlayableSound GetNextForTimeQuantum(int timeQuantumNumber)
    {
        if (_queue.Count == 0 || _queue.Peek().startTimeQuantumNumber > timeQuantumNumber)
        {
            return null;
        }

        PlayableSound sound = _queue.Dequeue();
        onSoundRemoved?.Invoke(sound);
        return sound;
    }

    public PlayableSound GetLastSound()
    {
        return _queue.Count > 0 ? _lastSound : null;
    }
}