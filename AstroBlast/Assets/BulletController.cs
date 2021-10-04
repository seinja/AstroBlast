using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float offsetX = 70f;
    private float offsetY = 41f;


    void Start()
    {
        
    }


    void Update()
    {
        if (transform.position.x > offsetX || transform.position.y > offsetY || transform.position.x < -offsetX || transform.position.y < -offsetY) { Destroy(this.gameObject); }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor")) 
        {
            Destroy(this.gameObject);
        }
    }
}
