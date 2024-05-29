
using UnityEngine;

public class SetPlayerPosition : MonoBehaviour
{
    private void Awake()
    {
        DontDestroy doggie = FindObjectOfType<DontDestroy>();
        Debug.Log(doggie.transform.position);
        doggie.gameObject.transform.position = transform.position;
    }
}
