using System.Collections.Generic;
using UnityEngine;
using Visualization;

public class SoundLabelsManager : MonoBehaviour
{
    [SerializeField]
    private VisualizationManager _visualizationManager;

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private SoundLabel _labelPrefab;

    private Dictionary<int, SoundLabel> _labels;

    private void Awake()
    {
        _labels = new Dictionary<int, SoundLabel>();

        _visualizationManager.onSoundCreated += OnSoundCreated;
        _visualizationManager.onSoundUpdated += OnSoundUpdated;
        _visualizationManager.onSoundRemoved += OnSoundRemoved;
    }

    private void OnSoundCreated(Sound sound)
    {
        SoundLabel soundLabel = Instantiate(_labelPrefab, transform);
        soundLabel.SetText(sound.playableSound.pitch.ToString());
        _labels[sound.playableSound.id] = soundLabel;
        soundLabel.gameObject.SetActive(false);
    }

    private void OnSoundUpdated(Sound sound)
    {
        Vector3 screenPoint = _camera.WorldToScreenPoint(sound.transform.position);
        SoundLabel soundLabel = _labels[sound.playableSound.id];
        soundLabel.transform.position = screenPoint;
        if (!soundLabel.gameObject.activeSelf)
        {
            soundLabel.gameObject.SetActive(true);
        }
    }

    private void OnSoundRemoved(int playableSoundId)
    {
        Destroy(_labels[playableSoundId].gameObject);
        _labels.Remove(playableSoundId);
    }
}