using UnityEngine;

namespace Systems.GameEvents
{
    public class ImageGameEventListener : MonoBehaviour
    {
        [SerializeField] private ImageEventListener[] listeners = new ImageEventListener[1];
        
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