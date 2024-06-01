using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    private bool playerInRange = false;
    private bool isHiding = false;
    private GameObject player;
    private SpriteRenderer playerRenderer;
    private Collider2D playerCollider;
    private Walk playerMovement; // Reference to the player's movement script
    private Rigidbody2D playerRigidbody; // Reference to the player's Rigidbody2D

    void Start()
    {
        // Find the player in the scene
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerRenderer = player.GetComponent<SpriteRenderer>();
            playerCollider = player.GetComponent<Collider2D>();
            playerMovement = player.GetComponent<Walk>(); // Get the player's movement script
            playerRigidbody = player.GetComponent<Rigidbody2D>(); // Get the player's Rigidbody2D
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ToggleHide();
        }
    }

    private void ToggleHide()
    {
        isHiding = !isHiding;
        Debug.Log("ToggleHide called. isHiding: " + isHiding);

        if (isHiding)
        {
            Debug.Log("Hiding player.");
            // Hide the player and disable movement
            playerRenderer.enabled = false; // Hide the player's sprite
            playerCollider.enabled = false; // Disable player's collider
            playerMovement.enabled = false; // Disable player's movement script
            playerRigidbody.isKinematic = true; // Disable physics on the player
            playerRigidbody.velocity = Vector2.zero; // Stop any existing movement
        }
        else 
        {
            Debug.Log("Unhiding player.");
            // Show the player and enable movement
            playerRenderer.enabled = true; // Show the player's sprite
            playerCollider.enabled = true; // Enable player's collider
            playerMovement.enabled = true; // Enable player's movement script
            playerRigidbody.isKinematic = false; // Enable physics on the player
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered hiding spot.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isHiding) // Ensure exiting only when not hiding
        {
            playerInRange = false;
            Debug.Log("Player exited hiding spot.");
        }
    }
}