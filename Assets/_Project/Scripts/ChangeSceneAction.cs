
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAction : GameAction
{
    [SerializeField]private string sceneName;

    public override void Raise()
    {
        SceneManager.LoadScene(sceneName);
    }
}
