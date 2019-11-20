using System;
using System.Collections.Generic;
using Beat;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public int bpm => _bpm;
    public int measure => _measure;
    
    [SerializeField]
    [Range(1, 300)]
    private int _bpm = 60;

    [SerializeField]
    [Range(1, 10)]
    private int _measure = 4;

    private float _startTime;
    private float _nextQuarterBeatTime;
    private int _beatCounter;
    private int _quarterBeatCounter;
    private List<PrioritizedEventListener<BeatEvent>> _beatEventListeners;
    private List<PrioritizedEventListener<QuarterBeatEvent>> _quarterBeatEventListeners;

    private void Awake()
    {
        _startTime = Time.time;
        _nextQuarterBeatTime = _startTime + GetQuarterBeatLength();
        _beatEventListeners = new List<PrioritizedEventListener<BeatEvent>>();
        _quarterBeatEventListeners = new List<PrioritizedEventListener<QuarterBeatEvent>>();
    }

    private void OnEnable()
    {
        float quarterBeatLength = GetQuarterBeatLength();
        int quarterBeatsPassed = Mathf.FloorToInt((Time.time - _startTime) / quarterBeatLength);
        _nextQuarterBeatTime = (quarterBeatsPassed + 1) * quarterBeatLength;
    }

    private void Update()
    {
        if (Time.time >= _nextQuarterBeatTime)
        {
            FireQuarterBeatEvent();
            _nextQuarterBeatTime += GetQuarterBeatLength();
            ++_quarterBeatCounter;
            if (_quarterBeatCounter % _measure == 0)
            {
                FireBeatEvent(_nextQuarterBeatTime);
                ++_beatCounter;
            }
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

    public void AddQuarterBeatEventListener(Action<QuarterBeatEvent> action, int priority = -1)
    {
        _quarterBeatEventListeners.Add(new PrioritizedEventListener<QuarterBeatEvent>
        {
            priority = priority,
            action = action,
        });
        _quarterBeatEventListeners.Sort((a, b) => a.priority - b.priority);
    }

    private void FireQuarterBeatEvent()
    {
        QuarterBeatEvent quarterBeatEvent = new QuarterBeatEvent(_quarterBeatCounter);
        _quarterBeatEventListeners.ForEach(listener => listener.action.Invoke(quarterBeatEvent));
    }

    private void FireBeatEvent(float time)
    {
        BeatEvent beatEvent = new BeatEvent(time, _quarterBeatCounter, _beatCounter % _measure == 0);
        _beatEventListeners.ForEach(listener => listener.action.Invoke(beatEvent));
    }

    private float GetQuarterBeatLength()
    {
        return 60f / 4f / _bpm;
    }
}