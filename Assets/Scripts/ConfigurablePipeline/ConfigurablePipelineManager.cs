using UnityEngine;

namespace ConfigurablePipeline
{
    public class ConfigurablePipelineManager : MonoBehaviour
    {
        public Context context => _context;

        [SerializeField]
        private BeatManager _beatManager;

        [SerializeField]
        private PlayableSoundQueue _playableSoundQueue;

        private Context _context;

        private void Awake()
        {
            _context = new Context
            {
                beatManager = _beatManager,
                playableSoundQueue = _playableSoundQueue,
            };
        }
    }
}