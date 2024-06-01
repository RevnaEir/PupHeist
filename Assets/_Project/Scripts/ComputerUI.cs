using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerUI : MonoBehaviour
{
    public GameObject computerCanvas;
    public TMP_InputField[] codeInputFields; // Array of input fields
    public string correctCode = "1234"; // Predefined correct code
    public List<GameObject> visionCones; // List of VisionCone GameObjects

    public void CheckCode()
    {
        print("checking");
        string enteredCode = "";
        foreach (TMP_InputField inputField in codeInputFields)
        {
            enteredCode += inputField.text;
            print(enteredCode);
        }

        if (enteredCode == correctCode)
        {
            DisableSecurityCameras();
            computerCanvas.SetActive(false); // Close the computer UI
            Time.timeScale = 1; // Resume the game
        }
        else
        {
            print("wrong code");
        }
    }

    private void DisableSecurityCameras()
    {
        // Disable all vision cones
        foreach (GameObject visionCone in visionCones)
        {
            visionCone.SetActive(false);
        }
    }
}