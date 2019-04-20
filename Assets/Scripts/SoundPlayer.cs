using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private BeatManager _beatManager;
    [SerializeField]
    private AudioSource[] _audioSources;

    private Sound[] _sounds;

    private void Start()
    {
        _sounds = new Sound[_audioSources.Length + 1];
        for (int i = 0; i < _audioSources.Length; ++i)
            _sounds[i] = new Note(_audioSources[i]);
        _sounds[_sounds.Length - 1] = new Pause();

        _beatManager.onBeatEvent += OnBeatEvent;
    }

    private void OnBeatEvent(BeatEvent beatEvent)
    {
        for (int i = 0; i < 1; ++i)
        {
            Sound sound = GetNextSound();
            sound.SetVolume(beatEvent.isStrong ? 1f : 0.5f);
            sound.Play();
        }
    }

    private Sound GetNextSound()
    {
        int index = Random.Range(0, _sounds.Length);
        return _sounds[index];
    }
}
