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
        _beatManager.AddTimeQuantumEventListener(OnTimeQuantumEvent, int.MaxValue);
    }

    private void OnTimeQuantumEvent(TimeQuantumEvent timeQuantumEvent)
    {
        _soundsToStop.Clear();
        foreach (var kvPair in _soundControllers)
        {
            kvPair.Value.IncrementTimeQuantumCounter();
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

        PlayableSound playableSound;
        while ((playableSound = _queue.GetNextForTimeQuantum(timeQuantumEvent.timeQuantumNumber)) != null)
        {
            AbstractSoundController soundController = _instrument.PlayNote(
                playableSound.pitch, playableSound.volume, playableSound.durationTimeQuanta);
            if (soundController != null)
            {
                _soundControllers[_soundCounter++] = soundController;
            }
        }
    }
}