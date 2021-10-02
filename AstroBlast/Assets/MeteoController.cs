using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoController : MonoBehaviour, IPoolerdObject
{
    private Rigidbody2D _rb;
    private GameObject _player;
   

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb.AddForce((_player.transform.position - transform.position).normalized * 2f);
    }

    public void OnObjectSpawn()
    {
        this.gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
    }
}
