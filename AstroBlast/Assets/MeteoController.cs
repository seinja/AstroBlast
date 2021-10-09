using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeteoController : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private TextMeshProUGUI _hpText;
    private Rigidbody2D _rb;
    private int _hp;
    private GameObject _player;

   

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        _hp = Random.Range(GameManager.Instance.GetCurrentLevel(), GameManager.Instance.GetCurrentLevel() + 5);
        _hpText.text = _hp.ToString();
        
    }

    private void Update()
    {
        _rb.AddForce((_player.transform.position - transform.position).normalized * 1.5f);

        if (GameManager.isGameWin || GameManager.isGameOver)
        {
            Destroy(this.gameObject);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Earth"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.TryGetComponent<BulletController>(out BulletController bulletController))
        {

            _hp -= bulletController.GetDamage();
            Debug.Log("Damage : " + bulletController.GetDamage());
            if (_hp <= 0)
            {
                GameManager.Instance.UpProgression();
                Instantiate(coin, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            _hpText.text = _hp.ToString();

        }
    }


}
