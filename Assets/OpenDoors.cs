using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    [SerializeField] private BoxCollider2D doorTrigger;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollectedKeys collectedKeys = other.gameObject.GetComponent<CollectedKeys>();

            if (collectedKeys.GetCount() == 4)
            {
                doorTrigger.enabled = true;
            }
                
        }
    }
}
