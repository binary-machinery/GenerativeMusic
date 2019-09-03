using UnityEngine;
using System.Collections.Generic;
using MusicAlgebra;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private BeatManager _beatManager;
    [SerializeField]
    private AbstractInstrument _instrument;

    private Scale _scale;
    private Queue<Pitch> _queue;

    private void Awake()
    {
        _scale = ScaleHelper.Create(new Pitch(Note.C, 4), ScaleType.Major);
        _queue = new Queue<Pitch>();
    }

    private void Start()
    {
        _beatManager.onBeatEvent += OnBeatEvent;
    }

    private void OnBeatEvent(BeatEvent beatEvent)
    {
        if (_queue.Count == 0)
        {
            Pitch nextPitch = GetNextPitch();
            _queue.Enqueue(nextPitch);
            _queue.Enqueue(Operators.AddSemitones(nextPitch, 3));
            _queue.Enqueue(Operators.AddSemitones(nextPitch, 7));
        }
        float volume = beatEvent.isStrong ? 1f : 0.75f;
        Pitch pitch = _queue.Dequeue();
        _instrument.PlayNote(pitch, volume);
    }

    private Pitch GetNextPitch()
    {
        int index = Random.Range(0, _scale.pitches.Length);
        return _scale.pitches[index];
    }
}
