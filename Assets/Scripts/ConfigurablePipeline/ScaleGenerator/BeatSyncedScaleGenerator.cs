namespace ConfigurablePipeline
{
    public class BeatSyncedScaleGenerator : AbstractScaleGenerator
    {
        private void Start()
        {
            context.beatManager.AddBeatEventListener(OnBeatEvent, transform.GetSiblingIndex());
            UpdateScale(rootNote, scaleType);
        }

        private void OnBeatEvent(BeatEvent beatEvent)
        {
            if (context.rootNote != rootNote || context.scaleType != scaleType)
            {
                UpdateScale(rootNote, scaleType);
            }
        }
    }
}