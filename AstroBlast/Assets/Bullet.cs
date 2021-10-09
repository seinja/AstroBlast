using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _sparks;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 225f;
    public float _shootigSpeed;

    private void Start()
    {
        Debug.Log("_shootingSpeed " + _shootigSpeed);
        StartCoroutine(Shooting());
    }



    void Shoot() 
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation );
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        _sparks.SetActive(true);
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        
    }

    IEnumerator Shooting() 
    {
        if (!GameManager.isGameWin && !GameManager.isGameOver)
        {
            Shoot();
            yield return new WaitForSeconds(0.09f);
            _sparks.SetActive(false);
            yield return new WaitForSeconds(_shootigSpeed);
            
            StartCoroutine(Shooting());
        }

    }
}
