using UnityEngine;

namespace ConfigurablePipeline
{
    public class ConfigurablePipelineManager : MonoBehaviour
    {
        public Context context => _context;

        [SerializeField]
        private BeatManager _beatManager;

        private Context _context;

        private void Awake()
        {
            _context = new Context
            {
                beatManager = _beatManager
            };
        }
    }
}