using System.Collections.Generic;
using MusicAlgebra;
using UnityEngine;

namespace Visualization
{
    public class VisualizationManager : MonoBehaviour
    {
        private const float Z_DEPTH = 5;
        private const int PLAYED_SOUNDS_TIME_TO_LIVE = 24; // in quarter beats
        private const int NOTE_GRID_OFFSET = -4;
        private const int OCTAVE_GRID_OFFSET = -4;

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
        private HashSet<int> _soundsToRemove;
        private Transform _soundsParent;

        private void Awake()
        {
            _sounds = new Dictionary<int, Sound>();
            _soundsToRemove = new HashSet<int>();

            _beatManager.onQuarterBeatEvent += OnQuarterBeatEvent;
            _queue.onSoundAdded += OnSoundAdded;

            _soundsParent = new GameObject("Sounds").transform;
            _soundsParent.parent = this.transform;
        }

        private void OnQuarterBeatEvent(QuarterBeatEvent quarterBeatEvent)
        {
            foreach (var kv in _sounds)
            {
                Sound sound = kv.Value;
                if (!sound.gameObject.activeSelf)
                {
                    sound.gameObject.SetActive(true);
                }

                int beatGridIndex = sound.playableSound.startQuarterBeatNumber - quarterBeatEvent.quarterBeatNumber;
                float x = beatGridIndex * _quarterBeatStep;

                Pitch pitch = sound.playableSound.pitch;
                int noteGridIndex = (int)pitch.note + NOTE_GRID_OFFSET + (pitch.octave + OCTAVE_GRID_OFFSET) * Defines.SEMITONES_COUNT;
                float y = noteGridIndex * _pitchStep;

                sound.transform.localPosition = new Vector3(x, y, Z_DEPTH);

                if (beatGridIndex + sound.playableSound.durationQuarterBeats < -PLAYED_SOUNDS_TIME_TO_LIVE)
                {
                    _soundsToRemove.Add(sound.playableSound.id);
                }
            }

            foreach (int id in _soundsToRemove)
            {
                Destroy(_sounds[id].gameObject);
                _sounds.Remove(id);
            }
            _soundsToRemove.Clear();
        }

        private void OnSoundAdded(PlayableSound playableSound)
        {
            Sound sound = Instantiate(_soundPrefab, _soundsParent);
            sound.gameObject.SetActive(false);
            sound.playableSound = playableSound;
            _sounds[playableSound.id] = sound;
        }
    }
}