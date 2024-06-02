using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public int totalPieces;
    private int placedPieces;

    private void OnEnable()
    {
        MoveSystem.OnPiecePlaced += OnPiecePlaced;
    }

    private void OnDisable()
    {
        MoveSystem.OnPiecePlaced -= OnPiecePlaced;
    }

    private void Start()
    {
        placedPieces = 0;
    }

    private void OnPiecePlaced()
    {
        placedPieces++;
        if (placedPieces >= totalPieces)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("bankaoutside"); // Replace with your scene name
    }
}
