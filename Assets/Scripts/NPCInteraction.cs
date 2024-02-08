using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    public string[] dialogueLines = { "You are such a good boy" };
    private bool inConversation = false;
    private int currentLine = 0;

    public TMP_Text dialogueText; // Reference to the TextMeshPro component to display dialogue

    void Start()
    {
        // Set the dialogueText to inactive initially
        dialogueText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Check if in conversation and 'E' key is pressed to progress dialogue
        if (inConversation && Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextLine();
        }
    }

    public void StartConversation()
    {
        // Start the conversation
        inConversation = true;
        currentLine = 0;
        DisplayNextLine();
    }

    void DisplayNextLine()
    {

        // Set the dialogueText to active before displaying lines
        dialogueText.gameObject.SetActive(true);

        // Check if there are more lines in the dialogue
        if (currentLine < dialogueLines.Length)
        {
            // Display the next line
            dialogueText.text = dialogueLines[currentLine];
            currentLine++;
        }
        else
        {
            // End the conversation
            EndConversation();
        }
    }

    void EndConversation()
    {
        // Reset variables and end the conversation
        inConversation = false;
        currentLine = 0;

        // Set the dialogueText to inactive after the conversation ends
        dialogueText.gameObject.SetActive(false);
    }
}
