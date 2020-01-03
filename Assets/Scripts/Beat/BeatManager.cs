using System;
using System.Collections.Generic;
using Beat;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public int bpm => _bpm;

    public int timeQuantaPerBeat => _timeQuantaPerBeat;

    public int measure => _measure;
    
    [SerializeField]
    [Range(1, 300)]
    private int _bpm = 60;

    [SerializeField]
    [Range(2, 64)]
    private int _timeQuantaPerBeat = 4;

    [SerializeField]
    [Range(1, 10)]
    private int _measure = 4;

    private float _startTime;
    private float _nextTimeQuantumTime;
    private int _beatCounter;
    private int _timeQuantumCounter;
    private List<PrioritizedEventListener<BeatEvent>> _beatEventListeners;
    private List<PrioritizedEventListener<TimeQuantumEvent>> _timeQuantumEventListeners;

    private void Awake()
    {
        _startTime = Time.time;
        _nextTimeQuantumTime = _startTime + GetTimeQuantumLength();
        _beatEventListeners = new List<PrioritizedEventListener<BeatEvent>>();
        _timeQuantumEventListeners = new List<PrioritizedEventListener<TimeQuantumEvent>>();
    }

    private void OnEnable()
    {
        float timeQuantumLength = GetTimeQuantumLength();
        int timeQuantaPassed = Mathf.FloorToInt((Time.time - _startTime) / timeQuantumLength);
        _nextTimeQuantumTime = (timeQuantaPassed + 1) * timeQuantumLength;
    }

    private void Update()
    {
        if (Time.time >= _nextTimeQuantumTime)
        {
            FireTimeQuantumEvent();
            if (_timeQuantumCounter % _timeQuantaPerBeat == 0)
            {
                FireBeatEvent();
                ++_beatCounter;
            }
            _nextTimeQuantumTime += GetTimeQuantumLength();
            ++_timeQuantumCounter;
        }
    }
    
    public void AddBeatEventListener(Action<BeatEvent> action, int priority = -1)
    {
        _beatEventListeners.Add(new PrioritizedEventListener<BeatEvent>
        {
            priority = priority,
            action = action,
        });
        _beatEventListeners.Sort((a, b) => a.priority - b.priority);
    }

    public void AddTimeQuantumEventListener(Action<TimeQuantumEvent> action, int priority = -1)
    {
        _timeQuantumEventListeners.Add(new PrioritizedEventListener<TimeQuantumEvent>
        {
            priority = priority,
            action = action,
        });
        _timeQuantumEventListeners.Sort((a, b) => a.priority - b.priority);
    }

    private void FireTimeQuantumEvent()
    {
        TimeQuantumEvent timeQuantumEvent = new TimeQuantumEvent(_timeQuantumCounter);
        _timeQuantumEventListeners.ForEach(listener => listener.action.Invoke(timeQuantumEvent));
    }

    private void FireBeatEvent()
    {
        BeatEvent beatEvent = new BeatEvent(_nextTimeQuantumTime, _timeQuantumCounter, _beatCounter, _beatCounter % _measure == 0);
        _beatEventListeners.ForEach(listener => listener.action.Invoke(beatEvent));
    }

    private float GetTimeQuantumLength()
    {
        return 60f / _timeQuantaPerBeat / _bpm;
    }
}