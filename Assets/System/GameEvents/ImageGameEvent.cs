using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Systems.GameEvents
{
    [System.Serializable, CreateAssetMenu(fileName = "New Image Game Event", menuName = "Lumios/Game Events/New Image Game Event")]
    public class ImageGameEvent : ScriptableObject
    {
        private readonly HashSet<ImageEventListener> _eventListeners = new HashSet<ImageEventListener>();
        public int passableInteger = 0;

        // TODO: Add debug global flag to set this to false
        [SerializeField] private bool _dispatchMessage = false;

        public void Raise(Sprite item)
        {
            Debug.Log(item);
            foreach (var listener in _eventListeners)
            {
                listener.OnEventRaised(item);
                if (_dispatchMessage) Debug.LogFormat("Event named : {0} was raised", this.name);
            }
        }
        public void RegisterListener(ImageEventListener listener) => _eventListeners.Add(listener);
        public void UnregisterListener(ImageEventListener listener) => _eventListeners.Remove(listener);
    }
}