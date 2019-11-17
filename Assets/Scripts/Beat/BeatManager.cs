using System;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public event Action<QuarterBeatEvent> onQuarterBeatEvent;
    public event Action<BeatEvent> onBeatEvent;

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

    private void Start()
    {
        _startTime = Time.time;
        _nextQuarterBeatTime = _startTime + GetQuarterBeatLength();
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

    private void FireQuarterBeatEvent()
    {
        onQuarterBeatEvent?.Invoke(new QuarterBeatEvent(_quarterBeatCounter));
    }

    private void FireBeatEvent(float time)
    {
        onBeatEvent?.Invoke(new BeatEvent(time, _quarterBeatCounter, _beatCounter % _measure == 0));
    }

    private float GetQuarterBeatLength()
    {
        return 60f / 4f / _bpm;
    }
}