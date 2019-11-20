using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private BeatManager _beatManager;

    [SerializeField]
    private AbstractInstrument _instrument;

    [SerializeField]
    private PlayableSoundQueue _queue;

    private Dictionary<int, AbstractSoundController> _soundControllers;
    private HashSet<int> _soundsToStop;
    private int _soundCounter;

    private void Awake()
    {
        _soundControllers = new Dictionary<int, AbstractSoundController>();
        _soundsToStop = new HashSet<int>();
    }

    private void Start()
    {
        _beatManager.AddQuarterBeatEventListener(OnQuarterBeatEvent);
        _beatManager.AddBeatEventListener(OnBeatEvent, int.MaxValue);
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
        PlayableSound playableSound;
        while ((playableSound = _queue.GetNextForQuarterBeat(beatEvent.quarterBeatNumber)) != null)
        {
            AbstractSoundController soundController = _instrument.PlayNote(
                playableSound.pitch, playableSound.volume, playableSound.durationQuarterBeats);
            if (soundController != null)
            {
                _soundControllers[_soundCounter++] = soundController;
            }
        }
    }
}