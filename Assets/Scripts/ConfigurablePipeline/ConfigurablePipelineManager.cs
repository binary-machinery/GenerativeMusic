using UnityEngine;

namespace ConfigurablePipeline
{
    public class ConfigurablePipelineManager : MonoBehaviour
    {
        [SerializeField]
        private BeatManager _beatManager;
        
        [SerializeField]
        private IScaleGenerator _scaleGenerator;

        [SerializeField]
        private IChordsGenerator _chordsGenerator;

        [SerializeField]
        private IPhysicalChordConverter _physicalChordConverter;
    }
}