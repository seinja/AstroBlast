using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private GameObject _player;
    private int _amount;



    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _amount = Random.Range(1, GameManager.Instance.GetCurrentLevel()*6);
    }

    private void Update()
    {

        transform.Translate((_player.transform.position - transform.position).normalized * 25f * Time.deltaTime);
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
