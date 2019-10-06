using MusicAlgebra;
using UnityEngine;

public class Composer : MonoBehaviour
{
    [SerializeField]
    private BeatManager _beatManager;

    [SerializeField]
    private PlayableSoundQueue _queue;
    
    private AcademicChord[] _academicChords;

    private void Awake()
    {
        AcademicScale scale = ScaleHelper.Create(Note.C, ScaleType.Major);
        _academicChords = ScaleHelper.GenerateAcademicChords(scale);
        
        _beatManager.onBeatEvent += OnBeatEvent;
    }

    private void OnBeatEvent(BeatEvent beatEvent)
    {
        while (_queue.count < 20)
        {
            AcademicChord academicChord = GetRandomChord();
            PlayableSound lastSound = _queue.GetLastSound();
            int quarterBeatNumber = beatEvent.quarterBeatNumber;
            if (lastSound != null)
            {
                quarterBeatNumber = lastSound.startQuarterBeatNumber + lastSound.durationQuarterBeats;
            }
            _queue.AddSound(new PlayableSound(new Pitch(academicChord.notes[0], 4), 1f, quarterBeatNumber, 4));
            _queue.AddSound(new PlayableSound(new Pitch(academicChord.notes[1], 4), 1f, quarterBeatNumber, 4));
            _queue.AddSound(new PlayableSound(new Pitch(academicChord.notes[2], 4), 1f, quarterBeatNumber, 4));
        }
    }
    
    private AcademicChord GetRandomChord()
    {
        int index = Random.Range(0, _academicChords.Length);
        return _academicChords[index];
    }
}