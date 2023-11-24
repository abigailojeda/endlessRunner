using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("CAMERA")]
    [SerializeField]
    GameObject player;

    [Header("Rotation Settings")]
    [SerializeField]
    float cameraTilt = 25.0f;

    void Update()
    {
        if (player != null) 
        {
            Vector3 playerPosition = player.transform.position;

            Vector3 newPosition = new Vector3(playerPosition.x, transform.position.y, transform.position.z);
            transform.position = newPosition;

            transform.rotation = Quaternion.Euler(cameraTilt, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
        else
        {
            Debug.LogWarning("No player found");
        }
    }
}
