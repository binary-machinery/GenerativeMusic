using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public delegate void OnBeatEvent(BeatEvent beatEvent);

    public event OnBeatEvent onBeatEvent;

    [SerializeField]
    [Range(1, 300)]
    private int _bpm = 60;

    [SerializeField]
    private int _measure = 4;

    private float _startTime;
    private float _nextBeatTime;
    private int _beatCounter;

    private void Start()
    {
        _startTime = Time.time;
        _nextBeatTime = _startTime + GetBeatLength();
    }

    private void OnEnable()
    {
        float beatLength = GetBeatLength();
        int beatsPassed = Mathf.FloorToInt((Time.time - _startTime) / beatLength);
        _nextBeatTime = (beatsPassed + 1) * beatLength;
    }

    private void Update()
    {
        if (Time.time >= _nextBeatTime)
        {
            FireBeatEvent(_nextBeatTime);
            _nextBeatTime += GetBeatLength();
            _beatCounter = (_beatCounter + 1) % _measure;
        }
    }

    private void FireBeatEvent(float time)
    {
        onBeatEvent?.Invoke(
            new BeatEvent
            {
                time = time,
                countInBar = _beatCounter,
                isStrong = _beatCounter == 0,
            }
        );
    }

    private float GetBeatLength()
    {
        return 60f / _bpm;
    }
}
