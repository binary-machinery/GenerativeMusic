using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private float period;
    [SerializeField]
    private AudioSource[] audioSources;

    private Sound[] sounds;
    private float nextPlayTime;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        sounds = new Sound[audioSources.Length + 1];
        for (int i = 0; i < audioSources.Length; ++i)
            sounds[i] = new Note(audioSources[i]);
        sounds[sounds.Length - 1] = new Pause();

        nextPlayTime = Time.time + period;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextPlayTime)
        {
            nextPlayTime = Time.time + period;
            for (int i = 0; i < 2; ++i)
            {
                Sound sound = getNextSound();
                sound.SetVolume(counter % 4 == 0 ? 1f : 0.5f);
                sound.Play();
            }
            ++counter;
        }
    }

    Sound getNextSound()
    {
        int index = Random.Range(0, sounds.Length);
        return sounds[index];
    }
}
