using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Meteor))]
public class MeteoController : MonoBehaviour
{
    private Meteor _meteor;


    private void Start()
    {
        _meteor = GetComponent<Meteor>();
    }

    private void FixedUpdate()
    {
        _meteor.MoveToPlayer();
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Earth"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            _meteor.TakeDamage(collision.gameObject.GetComponent<Bullet>().GetDamage);
        }
    }



}
