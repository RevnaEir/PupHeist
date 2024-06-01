using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector3 checkpointPosition;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        // Set the initial checkpoint position to the player's start position
        checkpointPosition = player.transform.position;
    }

    public void SetCheckpoint(Vector3 newPosition)
    {
        checkpointPosition = newPosition;
    }

    public void RestartFromCheckpoint()
    {
        player.transform.position = checkpointPosition;
    }
}