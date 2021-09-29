using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControoler : MonoBehaviour
{
    private Vector3 _mousePos;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = _mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        _rb.rotation = angle;
    }


}
