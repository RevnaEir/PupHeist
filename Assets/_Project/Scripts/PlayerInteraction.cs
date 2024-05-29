using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject computerUI; // Reference to the computer UI
    private bool isNearComputer = false;

    void Update()
    {
        if (isNearComputer && Input.GetKeyDown(KeyCode.E))
        {
            computerUI.SetActive(true);
            Time.timeScale = 0; // Pause the game
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Computer"))
        {
            isNearComputer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Computer"))
        {
            isNearComputer = false;
        }
    }
}