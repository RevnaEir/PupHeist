using UnityEngine;
using UnityEngine.SceneManagement;
using Systems.GameEvents;

public class BigDoor : MonoBehaviour
{
    
    [SerializeField] private GameEvent showInteractionText;
    [SerializeField] private GameEvent hideInteractionText;
    public string nextSceneName; // Name of the next scene to load
    public Vector3 spawnPosition; // Position where the player should spawn in the next scene
    public float interactDistance = 2f; // Distance at which the player can interact with the door
    public KeyCode interactKey = KeyCode.E; // Key to interact with the door

    private bool canInteract;

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(interactKey))
        {
            LoadNextScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            showInteractionText.Raise();
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hideInteractionText.Raise();
            canInteract = false;
        }
    }

    private void LoadNextScene()
    {
        // Load the next scene asynchronously
        SceneManager.LoadSceneAsync(nextSceneName).completed += OnSceneLoaded;
    }

    private void OnSceneLoaded(AsyncOperation operation)
    {
        // Find the player object in the newly loaded scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // If player is found, set its position to the spawnPosition
        if (player != null)
        {
            player.transform.position = spawnPosition;
        }
        else
        {
            Debug.LogWarning("Player not found in the next scene. Make sure the player object is tagged as 'Player'.");
        }
    }
}