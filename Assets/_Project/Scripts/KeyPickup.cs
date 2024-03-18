using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] public int keyId = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollectedKeys collectedKeys = other.GetComponent<CollectedKeys>();
            if (collectedKeys != null)
            {
                Item key = new Item(keyId);
                // collectedKeys.AddKey(keyId);
                collectedKeys.AddKey(key);
                gameObject.SetActive(false);
            }
        }
    }
}
