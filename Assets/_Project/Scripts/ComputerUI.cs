using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerUI : MonoBehaviour
{
    public InputField[] codeInputFields; // Array of input fields
    public string correctCode = "1234"; // Predefined correct code
    public GameObject securitySystem; // Reference to the security system to disable

    public void CheckCode()
    {
        string enteredCode = "";
        foreach (InputField inputField in codeInputFields)
        {
            enteredCode += inputField.text;
        }

        if (enteredCode == correctCode)
        {
            DisableSecurity();
            gameObject.SetActive(false); // Close the computer UI
            Time.timeScale = 1; // Resume the game
        }
    }

    private void DisableSecurity()
    {
        // Code to disable security, e.g., deactivate cameras
        securitySystem.SetActive(false);
    }
}