using System.Collections.Generic;
using MusicAlgebra;
using UnityEngine;

namespace ConfigurablePipeline
{
    public class RandomChordsGenerator : AbstractChordsGenerator
    {
        private const int MAX_QUEUE_SIZE = 20;

        private void Start()
        {
            context.beatManager.onBeatEvent += OnBeatEvent;
        }

        private void OnBeatEvent(BeatEvent beatEvent)
        {
            Queue<AcademicChord> queue = context.academicChordsQueue;
            while (queue.Count < MAX_QUEUE_SIZE)
            {
                int index = Random.Range(0, context.academicChords.Length);
                queue.Enqueue(context.academicChords[index]);
            }
        }
    }
}