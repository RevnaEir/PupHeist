using UnityEngine;
using UnityEngine.Events;

namespace Systems.GameEvents
{
    [System.Serializable]
    public class StringEventListener
    {
        [Tooltip("Event to register with.")] public StringGameEvent GameEvent = null;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<string> Response = null;

        public void OnEventRaised(string item) => Response.Invoke(item);
    }
}