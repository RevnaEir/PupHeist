using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAction : GameAction
{
    [SerializeField]private string sceneName;

    public override void Raise()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
