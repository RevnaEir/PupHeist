using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] private int keyId = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollectedKeys collectedKeys = other.GetComponent<CollectedKeys>();
            if (collectedKeys != null)
            {
                collectedKeys.AddKey(keyId);
                Destroy(gameObject);
            }
        }
    }
}
