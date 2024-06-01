using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecurityCamera : MonoBehaviour
{
    public Transform visionCone; // Reference to the VisionCone GameObject
    public float detectionTime = 1.0f;
    private float detectionCounter = 0f;
    private bool playerDetected = false;
    private Transform player;
    private CheckpointManager checkpointManager;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        checkpointManager = GameObject.FindObjectOfType<CheckpointManager>();
    }

    void Update()
    {
        if (playerDetected)
        {
            detectionCounter += Time.deltaTime;
            if (detectionCounter >= detectionTime)
            {
                Debug.Log("Player detected for too long. Restarting from checkpoint...");
                checkpointManager.RestartFromCheckpoint();
                detectionCounter = 0f;
                playerDetected = false;
            }
        }
        else
        {
            detectionCounter = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered vision cone.");
            playerDetected = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited vision cone.");
            playerDetected = false;
        }
    }
}