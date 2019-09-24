using UnityEngine;

public class VisualizationManager : MonoBehaviour
{
    [SerializeField]
    private BeatManager _beatManager;

    [SerializeField]
    private GameObject _note;

    [SerializeField]
    private float _quarterBeatStep;

    [SerializeField]
    private float _noteStep;

    [SerializeField]
    private int _quarterBeatNumberForNote;

    private void Awake()
    {
        _beatManager.onQuarterBeatEvent += OnQuarterBeatEvent;
    }

    private void OnQuarterBeatEvent(QuarterBeatEvent quarterBeatEvent)
    {
        int beatGridIndex = _quarterBeatNumberForNote - quarterBeatEvent.quarterBeatNumber;
        float x = beatGridIndex + _noteStep;
        float y = 0;
        _note.transform.localPosition = new Vector3(x, y, 5);
    }
}