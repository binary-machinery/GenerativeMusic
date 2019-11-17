using MusicAlgebra;
using UnityEngine;

namespace ConfigurablePipeline
{
    public class AbstractScaleGenerator : AbstractComponent
    {
        public Note rootNote => _rootNote;
        public ScaleType scaleType => _scaleType;

        [SerializeField]
        private Note _rootNote;

        [SerializeField]
        private ScaleType _scaleType;
    }
}