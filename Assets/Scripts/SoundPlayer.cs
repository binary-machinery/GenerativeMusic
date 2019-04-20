using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private BeatManager _beatManager;
    [SerializeField]
    private AbstractInstrument _instrument;

    private NoteType[] _key;

    private void Awake()
    {
        _key = new NoteType[] {
            NoteType.C,
            NoteType.D,
            NoteType.E,
            NoteType.F,
            NoteType.G,
            NoteType.A,
            NoteType.B,
        };
    }

    private void Start()
    {
        _beatManager.onBeatEvent += OnBeatEvent;
    }

    private void OnBeatEvent(BeatEvent beatEvent)
    {
        for (int i = 0; i < 1; ++i)
        {
            NoteType noteType = GetNextNote();
            _instrument.PlayNote(new NoteDescriptor(noteType, 4), beatEvent.isStrong ? 1f : 0.5f);
        }
    }

    private NoteType GetNextNote()
    {
        int index = Random.Range(0, _key.Length);
        return _key[index];
    }
}
