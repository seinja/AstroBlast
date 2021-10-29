using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private GameObject _explosion;


    private int _damage;
    private Rigidbody2D _rb;
    private float offsetX = 70f;
    private float offsetY = 41f;
    private ShopController _shopController;

    private void Awake()
    {
        _damage = PlayerPrefs.GetInt("DamageLevel", 1);
        _rb = GetComponent<Rigidbody2D>();
        _shopController = FindObjectOfType<ShopController>();

        _shopController.OnDamageChagedEvent += OnDamageUpdate;

    }

    private void OnDamageUpdate(int newValue, int damageUpdatePrice)
    {
        _damage = newValue;
    }

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

    public void BulletMove(Transform firepoint, float force) 
    {
        _rb.AddForce(firepoint.up * force, ForceMode2D.Impulse);
    }

    public int GetDamage => _damage;
}
