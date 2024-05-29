using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SetCameraTarget : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    private void Awake()
    {
        DontDestroy doggie = FindObjectOfType<DontDestroy>();

        cam.Follow = doggie.transform;
        // cam.LookAt = doggie.transform;

    }
}
