using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UFOController : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject _UFOBullets;
    private GameObject _player;

    private Rigidbody2D _rb;

    private int _hp;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _hp = GameManager.Instance.GetCurrentLevel() * 20;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _hpSlider.maxValue = _hp;
        _hpSlider.value = _hp;
        StartCoroutine(UFOShooting());
    }

    private void Update()
    {
        _rb.AddForce((_player.gameObject.transform.position - transform.position).normalized * 20f);
    }



    void UpdateHp()
    {
        _hpSlider.value = _hp;
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {

            _hp -= bullet.GetDamage;
            UpdateHp();
            if (_hp <= 0)
            {
                GameManager.Instance.UpProgression();
                Instantiate(coin, transform.position, Quaternion.identity);

                StartCoroutine(Explosion());
            }

        }
    }

    IEnumerator UFOShooting()
    {
        Instantiate(_UFOBullets, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        StartCoroutine(UFOShooting());
    }


    IEnumerator Explosion()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<CircleCollider2D>().enabled = false;
        _explosion.SetActive(true);

        yield return new WaitForSeconds(3f);
        _explosion.SetActive(false);
        Destroy(this.gameObject);
    }




}
