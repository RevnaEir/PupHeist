using System.Collections.Generic;
using UnityEngine;

namespace Systems.GameEvents
{
    [System.Serializable, CreateAssetMenu(fileName = "New Game Event", menuName = "Lumios/Game Events/New Game Event")]
    public class GameEvent : ScriptableObject
    {
        protected readonly HashSet<EventListener> _eventListeners = new ();

        // TODO: Add debug global flag to set this to false
        [SerializeField] protected bool _dispatchMessage;

        public void Raise()
        {
            foreach (var listener in _eventListeners)
            {
                listener.OnEventRaised();
                if (_dispatchMessage) Debug.Log($"Event named : {name} was raised");
            }
        }
        public void RegisterListener(EventListener listener) => _eventListeners.Add(listener);
        public void UnregisterListener(EventListener listener) => _eventListeners.Remove(listener);
    }
}