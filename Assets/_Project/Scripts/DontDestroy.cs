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
        }

        DontDestroyOnLoad(gameObject);
    }
}
