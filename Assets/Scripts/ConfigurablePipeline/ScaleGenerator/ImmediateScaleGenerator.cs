using MusicAlgebra;

namespace ConfigurablePipeline
{
    public class ImmediateScaleGenerator : AbstractScaleGenerator
    {
        private void Start()
        {
            UpdateScale();
        }

        private void Update()
        {
            if (context.rootNote != rootNote || context.scaleType != scaleType)
            {
                UpdateScale();
            }
        }

        private void UpdateScale()
        {
            context.academicScale = ScaleHelper.Create(rootNote, scaleType);
            context.academicChords = ScaleHelper.GenerateAcademicChords(context.academicScale);
            context.rootNote = rootNote;
            context.scaleType = scaleType;
        }
    }
}