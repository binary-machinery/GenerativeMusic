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

        [SerializeField]
        private bool _useSingleNoteChords;

        protected void UpdateScale(Note rootNote, ScaleType scaleType)
        {
            context.academicScale = ScaleHelper.Create(rootNote, scaleType);
            context.academicChords = _useSingleNoteChords
                ? ScaleHelper.GenerateSingleNoteAcademicChords(context.academicScale)
                : ScaleHelper.GenerateAcademicChords(context.academicScale);
            context.rootNote = rootNote;
            context.scaleType = scaleType;
        }
    }
}