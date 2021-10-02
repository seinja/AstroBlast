using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 45f;

    private void Start()
    {
        InvokeRepeating("Shoot", 0.2f, 0.5f);
    }


    void Shoot() 
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity );
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
