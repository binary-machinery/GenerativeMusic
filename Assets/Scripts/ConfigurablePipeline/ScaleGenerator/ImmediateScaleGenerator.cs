﻿namespace ConfigurablePipeline
{
    public class ImmediateScaleGenerator : AbstractScaleGenerator
    {
        private void Start()
        {
            UpdateScale(rootNote, scaleType);
        }

        private void Update()
        {
            if (context.rootNote != rootNote || context.scaleType != scaleType)
            {
                UpdateScale(rootNote, scaleType);
            }
        }
    }
}