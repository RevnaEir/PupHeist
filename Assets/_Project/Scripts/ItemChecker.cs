
using UnityEngine;

public class ItemChecker : MonoBehaviour
{
    [SerializeField] private KeyPickup[] items;
    private CollectedKeys keys;


    private void OnEnable()
    {
        keys = GameObject.FindObjectOfType<CollectedKeys>();
        if (keys != null)
        {
            foreach (var item in items)
            {
                foreach (var key in keys.keyList2)
                {
                    if (key.id == item.keyId)
                    {
                        print("has keys");
                        item.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}