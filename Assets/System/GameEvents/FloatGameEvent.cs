using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Systems.GameEvents
{
    [System.Serializable, CreateAssetMenu(fileName = "New Float Game Event", menuName = "Lumios/Game Events/New Float Game Event")]
    public class FloatGameEvent : ScriptableObject
    {
        protected readonly HashSet<FloatEventListener> _eventListeners = new ();

        // TODO: Add debug global flag to set this to false
        [SerializeField] private bool _dispatchMessage = false;

        public void Raise(float item)
        {
            foreach (var listener in _eventListeners)
            {
                listener.OnEventRaised(item);
                if (_dispatchMessage) Debug.LogFormat("Event named : {0} was raised", this.name);
            }
        }
        public void RegisterListener(FloatEventListener listener) => _eventListeners.Add(listener);
        public void UnregisterListener(FloatEventListener listener) => _eventListeners.Remove(listener);
    }
}
