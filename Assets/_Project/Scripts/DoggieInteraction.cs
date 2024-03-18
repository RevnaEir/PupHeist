using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoggieInteraction : MonoBehaviour
{
    private bool isInRange;
    private NPCInteraction currentNPC;
    [SerializeField] private TMP_Text inputText; 

    void Update()
    {
        // Check if Doggie is in range of an NPC and 'E' key is pressed
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (currentNPC != null)
            {
                // Trigger the conversation with the current NPC
                currentNPC.StartConversation();
            }
        }
    }

    // Called when another Collider enters Doggie's trigger zone
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            inputText.gameObject.SetActive(true);
            // Set the current NPC Doggie is in range of
            currentNPC = other.GetComponent<NPCInteraction>();
            isInRange = true;
        }
    }

    // Called when another Collider exits Doggie's trigger zone
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            inputText.gameObject.SetActive(false);
            // Reset the current NPC when Doggie is out of range
            currentNPC = null;
            isInRange = false;
        }
    }
}