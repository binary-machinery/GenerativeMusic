using UnityEngine;

public class Note : Sound
{
    private AudioSource source;

    public Note(AudioSource source)
    {
        this.source = source;
    }

    public override void Play()
    {
        if (source != null)
            source.Play();
    }

    public override void SetVolume(float volume)
    {
        if (source != null)
            source.volume = volume;
    }
}
