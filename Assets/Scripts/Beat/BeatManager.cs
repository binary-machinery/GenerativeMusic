using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public delegate void OnBeatEvent(BeatEvent beatEvent);

    public event OnBeatEvent onBeatEvent;

    [SerializeField]
    [Range(1, 300)]
    private int bpm = 60;

    [SerializeField]
    private int measure = 4;

    private float startTime;
    private float nextBeatTime;
    private int beatCounter;

    private void Start()
    {
        startTime = Time.time;
        nextBeatTime = startTime + GetBeatLength();
    }

    private void OnEnable()
    {
        float beatLength = GetBeatLength();
        int beatsPassed = Mathf.FloorToInt((Time.time - startTime) / beatLength);
        nextBeatTime = (beatsPassed + 1) * beatLength;
    }

    private void Update()
    {
        if (Time.time >= nextBeatTime)
        {
            FireBeatEvent(nextBeatTime);
            nextBeatTime += GetBeatLength();
            beatCounter = (beatCounter + 1) % measure;
        }
    }

    private void FireBeatEvent(float time)
    {
        onBeatEvent?.Invoke(
            new BeatEvent
            {
                time = time,
                countInBar = beatCounter,
                isStrong = beatCounter == 0,
            }
        );
    }

    private float GetBeatLength()
    {
        return 60f / bpm;
    }
}
