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
    private Queue<PlayableSound> _queue;
    private Dictionary<int, AbstractSoundController> _soundControllers;
    private HashSet<int> _soundsToStop;
    private int _soundCounter;

    private void Awake()
    {
        AcademicScale scale = ScaleHelper.Create(Note.C, ScaleType.Major);
        _academicChords = ScaleHelper.GenerateAcademicChords(scale);
        _queue = new Queue<PlayableSound>();
        _soundControllers = new Dictionary<int, AbstractSoundController>();
        _soundsToStop = new HashSet<int>();
    }

    private void Start()
    {
        _beatManager.onQuarterBeatEvent += OnQuarterBeatEvent;
        _beatManager.onBeatEvent += OnBeatEvent;
    }

    private void OnQuarterBeatEvent(QuarterBeatEvent quarterBeatEvent)
    {
        _soundsToStop.Clear();
        foreach (var kvPair in _soundControllers)
        {
            kvPair.Value.IncrementQuarterBeatCounter();
            if (kvPair.Value.IsTimeToStop())
            {
                _soundsToStop.Add(kvPair.Key);
            }
        }

        foreach (int soundId in _soundsToStop)
        {
            AbstractSoundController soundController = _soundControllers[soundId];
            _soundControllers.Remove(soundId);
            soundController.Stop();
        }
    }

    private void OnBeatEvent(BeatEvent beatEvent)
    {
        if (_queue.Count == 0)
        {
            AcademicChord academicChord = GetNextChord();
            _queue.Enqueue(new PlayableSound(new Pitch(academicChord.notes[0], 4), 1f, 4));
            _queue.Enqueue(new PlayableSound(new Pitch(academicChord.notes[1], 4), 1f, 4));
            _queue.Enqueue(new PlayableSound(new Pitch(academicChord.notes[2], 4), 1f, 4));
        }
        float volume = beatEvent.isStrong ? 1f : 0.75f;
        PlayableSound playableSound = _queue.Dequeue();
        AbstractSoundController soundController = _instrument.PlayNote(
            playableSound.pitch, volume, playableSound.durationQuarterBeats);
        _soundControllers[_soundCounter++] = soundController;
    }

    private AcademicChord GetNextChord()
    {
        int index = Random.Range(0, _academicChords.Length);
        return _academicChords[index];
    }
}