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
                int timeQuantumNumber = beatEvent.timeQuantumNumber;
                if (lastSound != null)
                {
                    timeQuantumNumber = lastSound.startTimeQuantumNumber + lastSound.durationTimeQuanta;
                }

                float volume = beatEvent.isStrong ? 1f : 0.75f;
                for (int i = 0; i < academicChord.notes.Length; ++i)
                {
                    Note chordNote = academicChord.notes[i];
                    Pitch pitch = new Pitch(chordNote, (i == 0 || chordNote > academicChord.notes[0]) ? 4 : 5);
                    queue.AddSound(new PlayableSound(pitch, volume, timeQuantumNumber, context.beatManager.timeQuantaPerBeat));
                }
            }

            if (queue.count < MAX_QUEUE_SIZE && academicChordsQueue.Count == 0)
            {
                Debug.LogWarning("Playable sounds queue is not full, but academic chords queue is empty");
            }
        }
    }
}