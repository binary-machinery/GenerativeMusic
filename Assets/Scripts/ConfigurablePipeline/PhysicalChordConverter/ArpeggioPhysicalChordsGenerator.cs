using System.Collections.Generic;
using System.Linq;
using MusicAlgebra;
using UnityEngine;

namespace ConfigurablePipeline
{
    public class ArpeggioPhysicalChordsGenerator : AbstractPhysicalChordConverter
    {
        private enum Mode
        {
            Forward,
            Backward,
            Random,
        }
        
        private const int SOUND_DURATION_QUARTER_BEATS = 4;

        [SerializeField]
        private Mode _mode;

        private void Start()
        {
            context.beatManager.AddBeatEventListener(OnBeatEvent, transform.GetSiblingIndex());
        }

        private void OnBeatEvent(BeatEvent beatEvent)
        {
            Queue<AcademicChord> academicChordsQueue = context.academicChordsQueue;
            PlayableSoundQueue queue = context.playableSoundQueue;
            while (queue.count < MAX_QUEUE_SIZE && academicChordsQueue.Count > 0)
            {
                AcademicChord academicChord = academicChordsQueue.Dequeue();
                PlayableSound lastSound = queue.GetLastSound();
                int quarterBeatNumber = beatEvent.quarterBeatNumber;
                if (lastSound != null)
                {
                    quarterBeatNumber = lastSound.startQuarterBeatNumber + lastSound.durationQuarterBeats;
                }

                List<Pitch> pitches = new List<Pitch>
                {
                    new Pitch(academicChord.notes[0], 4),
                    new Pitch(academicChord.notes[1], academicChord.notes[1] > academicChord.notes[0] ? 4 : 5),
                    new Pitch(academicChord.notes[2], academicChord.notes[2] > academicChord.notes[0] ? 4 : 5),
                };

                List<int> indices = GetIndices(pitches.Count);
                bool strong = true;
                foreach (int index in indices)
                {
                    float volume = strong ? 1f : 0.5f;
                    strong = false;
                    queue.AddSound(new PlayableSound(pitches[index], volume, quarterBeatNumber, SOUND_DURATION_QUARTER_BEATS));
                    quarterBeatNumber += SOUND_DURATION_QUARTER_BEATS;
                }
            }

            if (queue.count < MAX_QUEUE_SIZE && academicChordsQueue.Count == 0)
            {
                Debug.LogWarning("Playable sounds queue is not full, but academic chords queue is empty");
            }
        }

        private List<int> GetIndices(int pitchesCount)
        {
            List<int> indices = Enumerable.Range(1, pitchesCount)
                .Select(x => x - 1)
                .ToList();
            switch (_mode)
            {
                case Mode.Forward:
                    break;

                case Mode.Backward:
                    indices.Reverse();
                    break;

                case Mode.Random:
                    indices.Shuffle();
                    break;
            }

            int repeatCount = Mathf.CeilToInt(context.beatManager.measure / (float)pitchesCount);
            return Enumerable.Repeat(indices, repeatCount)
                .SelectMany(x => x)
                .Take(context.beatManager.measure)
                .ToList();
        }
    }
}