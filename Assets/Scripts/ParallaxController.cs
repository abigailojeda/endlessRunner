using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{

    [Header("PARALLAX")]
    [SerializeField]
    float parallaxVelocity = 0f; 

    [SerializeField]
    GameObject player;

    void Update()
    {
        //Vector2 playerSpeed = player.GetComponent<Rigidbody>().velocity;
        //gameObject.GetComponent<SpriteRenderer>().material.mainTextureOffset += playerSpeed * parallaxVelocity * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<SpriteRenderer>().material.mainTextureOffset += Vector2.right * parallaxVelocity * Time.deltaTime;
        }
    }
}
