using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class DoorTransition : MonoBehaviour
{
    public Transform spawnPoint; // The spawn point where the player should appear
    public float transitionDuration = 0.01f; // Duration for smooth camera transition (shorter duration for faster transition)
    private Transform player;
    //private Camera mainCamera;
    private bool playerInRange = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        //mainCamera = Camera.main;
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(SmoothTransition());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player in range, press E to enter.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player out of range.");
        }
    }

    IEnumerator SmoothTransition()
    {
        Vector3 startPosition = player.position;
        Vector3 endPosition = spawnPoint.position;
        //Vector3 cameraStartPosition = mainCamera.transform.position;
        //Vector3 cameraEndPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y, mainCamera.transform.position.z);

        float elapsedTime = 0;

        while (elapsedTime < transitionDuration)
        {
            player.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / transitionDuration);
            //mainCamera.transform.position = Vector3.Lerp(cameraStartPosition, cameraEndPosition, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        player.position = endPosition;
       // mainCamera.transform.position = cameraEndPosition;
    }
}
