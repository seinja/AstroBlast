using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private AudioSource _shootAudio;
    [SerializeField] private GameObject _sparks;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 225f;
    public float _shootigSpeed;

    public int _damageShop;


    private void Start()
    {
        _shootAudio = GetComponent<AudioSource>();
        StartCoroutine(Shooting());
    }


    void Shoot()
    {
        _shootAudio.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<BulletController>()._damage = _damageShop;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        _sparks.SetActive(true);
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }

    IEnumerator Shooting()
    {
        if (!GameManager.isGameWin && !GameManager.isGameOver)
        {

            Shoot();
            yield return new WaitForFixedUpdate();
            _sparks.SetActive(false);
            yield return new WaitForSeconds(_shootigSpeed);
            StartCoroutine(Shooting());
        }

    }

    public void SetDamage(int _shopDamage)
    {
        _damageShop = _shopDamage;
    }

    public int GetDamage() { return _damageShop; }

    public void ContinueShoot() { StartCoroutine(Shooting()); }
}
