using UnityEngine;
using UnityEngine.Events;

namespace Systems.GameEvents
{
    [System.Serializable]
    public class FloatEventListener
    {
        [Tooltip("Event to register with.")] public FloatGameEvent GameEvent;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<float> Response = null;

        public void OnEventRaised(float item) => Response.Invoke(item);
    }
}