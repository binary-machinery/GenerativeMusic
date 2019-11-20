using System.Collections.Generic;
using MusicAlgebra;
using UnityEngine;

namespace ConfigurablePipeline
{
    public class ArpeggioPhysicalChordsGenerator : AbstractPhysicalChordConverter
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

                queue.AddSound(new PlayableSound(root, 1f, quarterBeatNumber, 4));
                queue.AddSound(new PlayableSound(third, 1f, quarterBeatNumber + 4, 4));
                queue.AddSound(new PlayableSound(fifth, 1f, quarterBeatNumber + 8, 4));
            }

            if (queue.count < MAX_QUEUE_SIZE && academicChordsQueue.Count == 0)
            {
                Debug.LogWarning("Playable sounds queue is not full, but academic chords queue is empty");
            }
        }
    }
}