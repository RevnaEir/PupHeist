using UnityEngine;

namespace Systems.GameEvents
{
    [System.Serializable]
    public class FloatGameEventListener : MonoBehaviour
    {
        [SerializeField] private FloatEventListener[] listeners = new FloatEventListener[1];
        
        private void OnEnable()
        {
            foreach (var eventListener in listeners)
            {
                eventListener.GameEvent.RegisterListener(eventListener);    
            }
        }

        private void OnDisable()
        {
            foreach (var eventListener in listeners)
            {
                eventListener.GameEvent.UnregisterListener(eventListener);
            }
        }
    }
}