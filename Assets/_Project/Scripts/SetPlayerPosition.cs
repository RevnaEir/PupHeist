using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPosition : MonoBehaviour
{
    private void OnEnable()
    {
        DontDestroy doggie = FindObjectOfType<DontDestroy>();

        doggie.transform.position = transform.position;
    }
}
