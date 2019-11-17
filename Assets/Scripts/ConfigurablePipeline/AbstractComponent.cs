using System;
using UnityEngine;

namespace ConfigurablePipeline
{
    public class AbstractComponent : MonoBehaviour
    {
        protected Context context => _manager.context;

        private ConfigurablePipelineManager _manager;

        protected virtual void Awake()
        {
            _manager = GetComponentInParent<ConfigurablePipelineManager>();
            if (_manager == null)
            {
                throw new Exception("ConfigurablePipelineManager not found");
            }
        }
    }
}