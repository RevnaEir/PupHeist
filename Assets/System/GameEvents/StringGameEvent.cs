using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Systems.GameEvents
{
    [System.Serializable, CreateAssetMenu(fileName = "New String Game Event", menuName = "Lumios/Game Events/New String Game Event")]
    public class StringGameEvent : ScriptableObject
    {
        private readonly HashSet<StringEventListener> _eventListeners = new HashSet<StringEventListener>();
        public int passableInteger = 0;

        // TODO: Add debug global flag to set this to false
        [SerializeField] private bool _dispatchMessage = false;

        public void Raise(string item)
        {
            Debug.Log(item);
            foreach (var listener in _eventListeners)
            {
                listener.OnEventRaised(item);
                if (_dispatchMessage) Debug.LogFormat("Event named : {0} was raised", this.name);
            }
        }
        public void RegisterListener(StringEventListener listener) => _eventListeners.Add(listener);
        public void UnregisterListener(StringEventListener listener) => _eventListeners.Remove(listener);
    }
}