namespace ConfigurablePipeline
{
    public class BeatSyncedScaleGenerator : AbstractScaleGenerator
    {
        private void Start()
        {
            context.beatManager.onBeatEvent += OnBeatEvent;
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