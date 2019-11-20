using System.Collections.Generic;
using MusicAlgebra;
using UnityEngine;

namespace ConfigurablePipeline
{
    public class RandomPhraseChordsGenerator : AbstractChordsGenerator
    {
        private const int MAX_QUEUE_SIZE = 20;

        private static readonly int[][] PHRASES =
        {
            new[] { 1, 3, 6, 5 },
            new[] { 1, 3, 7, 6 },
            new[] { 1, 4, 2, 5 },
            new[] { 1, 4, 5, 1 },
            new[] { 1, 6, 2, 3 },
            new[] { 1, 6, 2, 5 }
        };

        private void Start()
        {
            context.beatManager.AddBeatEventListener(OnBeatEvent, transform.GetSiblingIndex());
        }

        private void OnBeatEvent(BeatEvent beatEvent)
        {
            Queue<AcademicChord> queue = context.academicChordsQueue;
            while (queue.Count < MAX_QUEUE_SIZE)
            {
                int index = Random.Range(0, PHRASES.Length);
                foreach (int chordNumber in PHRASES[index])
                {
                    queue.Enqueue(context.academicChords[chordNumber - 1]);
                }
            }
        }
    }
}