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
            float volume = beatEvent.isStrong ? 1f : 0.5f;
            Note note = GetNextNote();
            Pitch root = new Pitch(note, 4);
            _instrument.PlayNote(root, volume);
            _instrument.PlayNote(Operators.addSemitones(root, 3), volume);
            _instrument.PlayNote(Operators.addSemitones(root, 7), volume);
        }
    }

    private Note GetNextNote()
    {
        int index = Random.Range(0, _key.Length);
        return _key[index];
    }
}
