using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    private float offsetX = 70f;
    private float offsetY = 41f;
    public int _damage;


    void Update()
    {
        if (transform.position.x > offsetX || transform.position.y > offsetY || transform.position.x < -offsetX || transform.position.y < -offsetY) { Destroy(this.gameObject); }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor")) 
        {
            StartCoroutine(Explsion());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            StartCoroutine(Explsion());
        }
    }


    IEnumerator Explsion() 
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<SpriteRenderer>().enabled = false;
        _explosion.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

  

    public int GetDamage() { return _damage; }
}
