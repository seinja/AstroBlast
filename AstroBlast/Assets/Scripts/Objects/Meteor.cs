using System.Collections;
using UnityEngine;
using TMPro;

public class Meteor : MonoBehaviour
{

    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private TextMeshProUGUI _hpText;

    private int _hp;
    private float _speed;
    private Rigidbody2D _rb;
    private GameObject _player;

    private void Awake()
    {

        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _hp = _hp = Random.Range(GameManager.Instance.GetCurrentLevel() + 1, GameManager.Instance.GetCurrentLevel() + 5);

        _speed = 2 + 5 / _hp;
    }

    private void Start()
    {
        UpdateMeteorUI();
    }

    public void MoveToPlayer()
    {
        _rb.AddForce((_player.transform.position - transform.position).normalized * _speed);

        if (GameManager.isGameWin || GameManager.isGameOver)
        {
            Destroy(this.gameObject);
        }
    }

    public void UpdateMeteorUI()
    {
        _hpText.text = _hp.ToString();
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

    public int GetHp() { return _hp; }

    public void TakeDamage(int amount) { 

        _hp -= amount;
        UpdateMeteorUI();
        if(_hp <= 0) 
        {
            GameManager.Instance.UpProgression();

            Instantiate(coin, transform.position, Quaternion.identity);

            StartCoroutine(Explosion());

        }
    } 
}
