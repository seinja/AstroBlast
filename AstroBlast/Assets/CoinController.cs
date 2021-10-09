using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private GameObject _player;
    private int _amount;



    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        _amount = Random.Range(1, GameManager.Instance.GetCurrentLevel()*6);
    }

    private void Update()
    {
        _rb.AddForce((_player.transform.position - transform.position).normalized * 2f);

        if (GameManager.isGameWin || GameManager.isGameOver)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            GameManager.Instance.PickUpCoin(_amount);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PickUpCoin(_amount);
            Destroy(this.gameObject);
        }
    }

}
