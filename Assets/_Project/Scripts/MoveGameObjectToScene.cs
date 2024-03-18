using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts
{
    public class MoveGameObjectToScene : MonoBehaviour
    {
        public GameObject UIRootObject;
        private AsyncOperation sceneAsync;
        

        public IEnumerator LoadScene(int index)
        {
            // Set the current Scene to be able to unload it later
            Scene currentScene = SceneManager.GetActiveScene();
            
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);

            //Wait until we are done loading the scene
            while (!asyncLoad.isDone)
            {
                print("Loading scene " + " [][] Progress: " + asyncLoad.progress);
                yield return null;
            }
            EnableScene(currentScene, 2);

        }

        private void EnableScene(Scene currentScene, int index)
        {
            Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(index);

            print("Scene is Valid");
            SceneManager.MoveGameObjectToScene(UIRootObject, sceneToLoad);
                
            SceneManager.UnloadSceneAsync(currentScene);
        }
    }
}