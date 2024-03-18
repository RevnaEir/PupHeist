using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenButton : MonoBehaviour
{
    

    // This method is called when the button is clicked
    public void ChangeScene()
    {
        // Load the HomeIdle scene
        SceneManager.LoadSceneAsync("HomeIdle");
    }
}
