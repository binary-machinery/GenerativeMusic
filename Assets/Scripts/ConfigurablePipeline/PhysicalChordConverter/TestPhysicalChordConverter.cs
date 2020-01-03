using System.Collections.Generic;
using System.Linq;
using MusicAlgebra;
using UnityEngine;

namespace ConfigurablePipeline
{
    public class TestPhysicalChordConverter : AbstractPhysicalChordConverter
    {
        [SerializeField]
        private bool _useCounterMelody = true;

        [SerializeField]
        private bool _useMelody = true;

        [SerializeField]
        private bool _useBass = true;

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
                int timeQuantumNumber = beatEvent.timeQuantumNumber;
                if (lastSound != null)
                {
                    timeQuantumNumber = lastSound.startTimeQuantumNumber + lastSound.durationTimeQuanta;
                }

                bool strong = timeQuantumNumber % context.beatManager.measure == 0;
                float volume = strong ? 1f : 0.5f;

                if (_useMelody)
                {
                    Pitch root = new Pitch(academicChord.notes[0], 4);
                    Pitch third = new Pitch(academicChord.notes[1], academicChord.notes[1] > academicChord.notes[0] ? 4 : 5);
                    Pitch fifth = new Pitch(academicChord.notes[2], academicChord.notes[2] > academicChord.notes[0] ? 4 : 5);
                    queue.AddSound(new PlayableSound(root, volume, timeQuantumNumber, 4));
                    queue.AddSound(new PlayableSound(third, volume, timeQuantumNumber, 4));
                    queue.AddSound(new PlayableSound(fifth, volume, timeQuantumNumber, 4));
                }

                if (_useBass && strong)
                {
                    Pitch bass = new Pitch(academicChord.notes[0], 2);
                    queue.AddSound(new PlayableSound(bass, volume, timeQuantumNumber, 4));
                }

                if (_useCounterMelody)
                {
                    List<Pitch> arpeggioPitches = new List<Pitch>
                    {
                        new Pitch(academicChord.notes[0], 6),
                        new Pitch(academicChord.notes[1], academicChord.notes[1] > academicChord.notes[0] ? 6 : 7),
                        new Pitch(academicChord.notes[2], academicChord.notes[2] > academicChord.notes[0] ? 6 : 7),
                    };
                    List<int> indices = GetIndices(3);
                    int arpeggioTimeQuantumNumber = timeQuantumNumber;
                    foreach (int index in indices)
                    {
                        queue.AddSound(new PlayableSound(arpeggioPitches[index], volume, arpeggioTimeQuantumNumber, 1));
                        arpeggioTimeQuantumNumber += 1;
                    }
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

            indices.Shuffle();

            int repeatCount = Mathf.CeilToInt(context.beatManager.measure / (float) pitchesCount);
            return Enumerable.Repeat(indices, repeatCount)
                .SelectMany(x => x)
                .Take(context.beatManager.measure)
                .ToList();
        }
    }
}