using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Systems.GameEvents
{
    [System.Serializable]
    public class ImageEventListener
    {
        [Tooltip("Event to register with.")] public ImageGameEvent GameEvent = null;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<Sprite> Response = null;

        public void OnEventRaised(Sprite item) => Response.Invoke(item);
    }
}