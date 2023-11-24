using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, jumpForce;
    private Rigidbody rig;
    public GameObject gameOverPanel;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //if (transform.position.y<0.1)
        //{
        //    rig.velocity = (transform.right * Mathf.Max(0, speed * Input.GetAxis("Horizontal")));
           
        //}
     
        if (Input.GetButtonDown("Jump"))
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag != null)
        {

            if (collision.gameObject.tag == "Enemy")
            {
                GameOver();
            }
        }

    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }


}
