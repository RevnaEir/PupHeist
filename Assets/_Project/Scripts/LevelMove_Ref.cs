using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class LevelMove_Ref : MonoBehaviour
{
    public int sceneBuildIndex;
    public Vector3 playerNewPoisition;

    private string exitPositionKey = "ExitPosition";


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            other.transform.position = playerNewPoisition;

            SceneManager.LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Single); 
            

        }
    }

}