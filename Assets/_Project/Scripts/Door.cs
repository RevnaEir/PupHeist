using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]private Animator _animator;


    [ContextMenu("Open")]
    public void Open()
    {
        _animator.SetTrigger("open");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollectedKeys collectedKeys = other.gameObject.GetComponent<CollectedKeys>();

            foreach (var key in collectedKeys.keyList2)
            {
                if (key.id == 3)
                {
                    Open();
                }
            }
                
        }
    }
}
