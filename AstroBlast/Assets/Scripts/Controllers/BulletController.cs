using System;
using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private GameObject _sparks;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _firePointTransform;
    private AudioSource _shootAudio;

    public float bulletForce = 225f;
    public float _shootigSpeed;

    private ShopController _shopController;

    private void Awake()
    {
        _shopController = FindObjectOfType<ShopController>();
        _shopController.OnSpeedChagedEvent += OnSpeedUpdate;

        _shootigSpeed = (float) 1f / PlayerPrefs.GetInt("SpeedLevel", 4);

        Debug.Log("Shooting countdown " + _shootigSpeed);
    }

    private void OnSpeedUpdate(int newValue, int speedUpdatePrice)
    {
        _shootigSpeed = 1f / newValue;
    }

    private void Start()
    {
        _shootAudio = GetComponent<AudioSource>();

        StartCoroutine(Shooting());
    }


    void Shoot()
    {
        _shootAudio.Play();

        GameObject bullet = Instantiate(_bulletPrefab, _firePointTransform.transform.position, _firePointTransform.transform.rotation);
        bullet.GetComponent<Bullet>().BulletMove(_firePointTransform.transform, bulletForce);

        _sparks.SetActive(true);
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

    public void ContinueShoot() { StartCoroutine(Shooting()); }
}
