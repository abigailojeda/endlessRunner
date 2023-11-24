using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed, jumpForce;
    private Rigidbody rig;
    private EnemyGenerator enemyGenerator;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        enemyGenerator = GameObject.FindObjectOfType<EnemyGenerator>();
    }

    void Update()
    {
        if (transform.position.y < 0.1)
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            if (horizontalInput > 0) 
            {
                Vector3 currentPosition = transform.position;
                float newXPosition = currentPosition.x - (speed * Mathf.Abs(horizontalInput) * Time.deltaTime);
                transform.position = new Vector3(newXPosition, currentPosition.y, currentPosition.z);
            }
        }
    }
    //public void OnBecameInvisible()
    //{
    //    Destroy(this.gameObject);
    //}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            if (enemyGenerator != null)
            {
                enemyGenerator.RemoveEnemy(this.gameObject); 
            }
           
        }
    }


}
