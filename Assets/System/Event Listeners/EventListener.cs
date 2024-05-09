using UnityEngine;
using UnityEngine.Events;

namespace Systems.GameEvents
{
    [System.Serializable]
    public class EventListener
    {
        [Tooltip("Event to register with.")] public GameEvent GameEvent = null;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response = null;

        public void OnEventRaised() => Response.Invoke();
    }
}