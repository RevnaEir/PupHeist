using Cinemachine;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy instance;

    public Vector2 lastPos;
    public int previousSceneIndex;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            var vrcam = GameObject.Find("CM vcam1");
            if (vrcam != null)
            {
                vrcam.GetComponent<CinemachineVirtualCamera>().Follow = instance.gameObject.transform;
            }
        }

        DontDestroyOnLoad(gameObject);
    }
}
