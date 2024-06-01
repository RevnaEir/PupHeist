using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public ComputerUI computerUIPrefab; // Reference to the computer UI prefab
    private GameObject computerUIScreen;
    private bool isNearComputer = false;

    void Update()
    {
        if (isNearComputer && Input.GetKeyDown(KeyCode.E))
        {
            OpenComputerScreen();
        }
    }

    private void OpenComputerScreen()
    {
        if (computerUIPrefab != null)
        {
            computerUIPrefab.computerCanvas.SetActive(true);
            Time.timeScale = 0; // Pause the game
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Computer"))
        {
            computerUIPrefab = other.gameObject.GetComponent<ComputerUI>();
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