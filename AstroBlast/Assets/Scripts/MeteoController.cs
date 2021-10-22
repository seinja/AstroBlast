using System.Collections;
using TMPro;
using UnityEngine;

public class MeteoController : MonoBehaviour
{
    private static int _countOFDeath = 0;
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
        _hp = Random.Range(GameManager.Instance.GetCurrentLevel() + 1, GameManager.Instance.GetCurrentLevel() + 5);
        _hpText.text = _hp.ToString();

        _speed = 2 + 5 / _hp;

    }

    private void Update()
    {
        _rb.AddForce((_player.transform.position - transform.position).normalized * _speed);

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
                GameManager.Instance.UpProgression();
                Instantiate(coin, transform.position, Quaternion.identity);

                StartCoroutine(Explosion());
            }
            _hpText.text = _hp.ToString();

        }
    }


    IEnumerator Explosion()
    {
        _countOFDeath++;
        Debug.Log(_countOFDeath);
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
