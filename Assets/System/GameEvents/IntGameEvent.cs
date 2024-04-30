using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Systems.GameEvents
{
    [System.Serializable, CreateAssetMenu(fileName = "New Int Game Event", menuName = "Lumios/Game Events/New Int Game Event")]
    public class IntGameEvent : ScriptableObject
    {
        protected readonly HashSet<IntEventListener> _eventListeners = new ();

        // TODO: Add debug global flag to set this to false
        [SerializeField] private bool _dispatchMessage = false;

        public void Raise(int item)
        {
            foreach (var listener in _eventListeners)
            {
                listener.OnEventRaised(item);
                if (_dispatchMessage) Debug.LogFormat("Event named : {0} was raised", this.name);
            }
        }
        public void RegisterListener(IntEventListener listener) => _eventListeners.Add(listener);
        public void UnregisterListener(IntEventListener listener) => _eventListeners.Remove(listener);
    }
}
