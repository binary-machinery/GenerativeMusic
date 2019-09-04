using UnityEngine;
using System.Collections.Generic;
using MusicAlgebra;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private BeatManager _beatManager;
    [SerializeField]
    private AbstractInstrument _instrument;

    private AcademicChord[] _academicChords;
    private Queue<Pitch> _queue;

    private void Awake()
    {
        AcademicScale scale = ScaleHelper.Create(Note.C, ScaleType.Major);
        _academicChords = ScaleHelper.GenerateAcademicChords(scale);
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
            AcademicChord academicChord = GetNextChord();
            _queue.Enqueue(new Pitch(academicChord.notes[0], 4));
            _queue.Enqueue(new Pitch(academicChord.notes[1], 4));
            _queue.Enqueue(new Pitch(academicChord.notes[2], 4));
        }
        float volume = beatEvent.isStrong ? 1f : 0.75f;
        Pitch pitch = _queue.Dequeue();
        _instrument.PlayNote(pitch, volume);
    }

    private AcademicChord GetNextChord()
    {
        int index = Random.Range(0, _academicChords.Length);
        return _academicChords[index];
    }
}
