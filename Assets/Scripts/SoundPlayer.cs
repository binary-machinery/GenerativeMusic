using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private BeatManager beatManager;
    [SerializeField]
    private AudioSource[] audioSources;

    private Sound[] sounds;

    private void Start()
    {
        sounds = new Sound[audioSources.Length + 1];
        for (int i = 0; i < audioSources.Length; ++i)
            sounds[i] = new Note(audioSources[i]);
        sounds[sounds.Length - 1] = new Pause();

        beatManager.onBeatEvent += OnBeatEvent;
    }

    private void OnBeatEvent(BeatEvent beatEvent)
    {
        for (int i = 0; i < 1; ++i)
        {
            Sound sound = getNextSound();
            sound.SetVolume(beatEvent.isStrong ? 1f : 0.5f);
            sound.Play();
        }
    }

    private Sound getNextSound()
    {
        int index = Random.Range(0, sounds.Length);
        return sounds[index];
    }
}
