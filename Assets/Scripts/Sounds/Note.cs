using UnityEngine;

public class Note : Sound
{
    private AudioSource _source;

    public Note(AudioSource source)
    {
        _source = source;
    }

    public override void Play()
    {
        if (_source != null)
            _source.Play();
    }

    public override void SetVolume(float volume)
    {
        if (_source != null)
            _source.volume = volume;
    }
}
