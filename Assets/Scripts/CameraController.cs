using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera[] cameras;
    [SerializeField] int activeCamera = 0;

    void Start()
    {
        ChangeCamera(activeCamera);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (activeCamera == cameras.Length - 1) activeCamera = 0;
            else activeCamera++;
            ChangeCamera(activeCamera);
        }
    }

    void ChangeCamera(int camera)
    {
        if (cameras.Length == 0) return;
        for (int i = 0; i < cameras.Length; i++)
            if (camera == i) cameras[i].enabled = true;
            else cameras[i].enabled = false;
    }
}
