using System.Collections;
using TMPro;
using UnityEngine;

public class UFOBullet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject coin;

    private Rigidbody2D _rb;
    private int _hp;
    private float _speed;
    private GameObject _player;



    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        _hp = Random.Range(GameManager.Instance.GetCurrentLevel(), GameManager.Instance.GetCurrentLevel() + 5);
        _hpText.text = _hp.ToString();

        _speed = 2 + 5 / _hp;

        _rb.AddForce((_player.transform.position - transform.position).normalized * _speed * 10, ForceMode2D.Impulse);

    }

    private void Update()
    {


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
            if (_hp <= 0)
            {
                Instantiate(coin, transform.position, Quaternion.identity);

                StartCoroutine(Explosion());
            }
            _hpText.text = _hp.ToString();

        }
    }


    IEnumerator Explosion()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<CircleCollider2D>().enabled = false;
        _hpText.enabled = false;
        _explosion.SetActive(true);

        yield return new WaitForSeconds(1f);
        _explosion.SetActive(false);
        Destroy(this.gameObject);
    }


}
