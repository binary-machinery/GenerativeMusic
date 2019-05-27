using UnityEngine;
using System.Collections.Generic;
using MusicAlgebra;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private BeatManager _beatManager;
    [SerializeField]
    private AbstractInstrument _instrument;

    private Note[] _key;
    private Queue<Pitch> _queue;

    private void Awake()
    {
        _key = new Note[] {
            Note.C,
            Note.D,
            Note.E,
            Note.F,
            Note.G,
            Note.A,
            Note.B,
        };

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
            Note note = GetNextNote();
            Pitch root = new Pitch(note, 4);
            _queue.Enqueue(root);
            _queue.Enqueue(Operators.addSemitones(root, 3));
            _queue.Enqueue(Operators.addSemitones(root, 7));
        }
        float volume = beatEvent.isStrong ? 1f : 0.75f;
        Pitch pitch = _queue.Dequeue();
        _instrument.PlayNote(pitch, volume);
    }

    private Note GetNextNote()
    {
        int index = Random.Range(0, _key.Length);
        return _key[index];
    }
}
