using System.Collections.Generic;
using MusicAlgebra;
using UnityEngine;

namespace ConfigurablePipeline
{
    public class DirectPhysicalChordConverter : AbstractPhysicalChordConverter
    {
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

                Pitch root = new Pitch(academicChord.notes[0], 4);
                Pitch third = new Pitch(academicChord.notes[1], academicChord.notes[1] > academicChord.notes[0] ? 4 : 5);
                Pitch fifth = new Pitch(academicChord.notes[2], academicChord.notes[2] > academicChord.notes[0] ? 4 : 5);

                bool strong = quarterBeatNumber % context.beatManager.measure == 0;
                float volume = strong ? 1f : 0.5f;
                queue.AddSound(new PlayableSound(root, volume, quarterBeatNumber, 4));
                queue.AddSound(new PlayableSound(third, volume, quarterBeatNumber, 4));
                queue.AddSound(new PlayableSound(fifth, volume, quarterBeatNumber, 4));
            }

            if (queue.count < MAX_QUEUE_SIZE && academicChordsQueue.Count == 0)
            {
                Debug.LogWarning("Playable sounds queue is not full, but academic chords queue is empty");
            }
        }
    }
}