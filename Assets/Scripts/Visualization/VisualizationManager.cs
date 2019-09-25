using System.Collections.Generic;
using UnityEngine;

namespace Visualization
{
    public class VisualizationManager : MonoBehaviour
    {
        private const float Z_DEPTH = 5; 
        
        [SerializeField]
        private BeatManager _beatManager;

        [SerializeField]
        private PlayableSoundQueue _queue;

        [SerializeField]
        private Sound _soundPrefab;

        [SerializeField]
        private float _quarterBeatStep;

        [SerializeField]
        private float _pitchStep;

        private Dictionary<int, Sound> _sounds;
        private Transform _soundsParent;

        private void Awake()
        {
            _sounds = new Dictionary<int, Sound>();
            _beatManager.onQuarterBeatEvent += OnQuarterBeatEvent;
            _queue.onSoundAdded += OnSoundAdded;
            _queue.onSoundRemoved += OnSoundRemoved;
            
            _soundsParent = new GameObject("Sounds").transform;
            _soundsParent.parent = this.transform;
        }

        private void OnQuarterBeatEvent(QuarterBeatEvent quarterBeatEvent)
        {
            foreach (var kv in _sounds)
            {
                Sound sound = kv.Value;
                int beatGridIndex = sound.playableSound.startQuarterBeatNumber - quarterBeatEvent.quarterBeatNumber;
                float x = beatGridIndex * _quarterBeatStep;
                int noteGridIndex = (int)sound.playableSound.pitch.note;
                float y = noteGridIndex * _pitchStep;
                sound.transform.localPosition = new Vector3(x, y, Z_DEPTH);
            }
        }

        private void OnSoundAdded(PlayableSound playableSound)
        {
            Sound sound = Instantiate(_soundPrefab, _soundsParent);
            sound.playableSound = playableSound;
            _sounds[playableSound.id] = sound;
        }

        private void OnSoundRemoved(PlayableSound playableSound)
        {
            Sound sound = _sounds[playableSound.id];
            _sounds.Remove(playableSound.id);
            Destroy(sound.gameObject);
        }
    }
}