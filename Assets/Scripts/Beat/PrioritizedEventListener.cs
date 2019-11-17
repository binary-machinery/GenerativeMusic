using System;

namespace Beat
{
    public class PrioritizedEventListener<T>
    {
        public int priority { get; set; }
        public Action<T> action { get; set; }
    }
}