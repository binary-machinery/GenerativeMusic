using UnityEngine;
using MusicAlgebra;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private BeatManager _beatManager;
    [SerializeField]
    private AbstractInstrument _instrument;

    private Note[] _key;

    private void Awake()
    {
        _key = new Note[] {
            Note.C,
            Note.D,
            Note.E,
            Note.F,
            Note.G,
            Note.A,
            Note.B,
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
            Note note = GetNextNote();
            _instrument.PlayNote(new Pitch(note, 4), beatEvent.isStrong ? 1f : 0.5f);
        }
    }

    private Note GetNextNote()
    {
        int index = Random.Range(0, _key.Length);
        return _key[index];
    }
}
