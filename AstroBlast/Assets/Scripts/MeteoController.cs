using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeteoController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private GameObject _childMeteor;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject coin;

    private MeteoSpawner _meteorSpawner;
    private Rigidbody2D _rb;
    private int _hp;
    private GameObject _player;

   

    private void Start()
    {
        _meteorSpawner = GameObject.FindObjectOfType<MeteoSpawner>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        _hp = Random.Range(GameManager.Instance.GetCurrentLevel(), GameManager.Instance.GetCurrentLevel() + 5);
        _hpText.text = _hp.ToString();
        
    }

    private void Update()
    {
        _rb.AddForce((_player.transform.position - transform.position).normalized * 1.9f);

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
                _meteorSpawner.SpawnOtherMeteor();
                _meteorSpawner.SpawnOtherMeteor();
                GameManager.Instance.UpProgression();
                Instantiate(coin, transform.position, Quaternion.identity);
                //Instantiate(_childMeteor, transform.position, Quaternion.identity);
                //Instantiate(_childMeteor, transform.position, Quaternion.identity);

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
