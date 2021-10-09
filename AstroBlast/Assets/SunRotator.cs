using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotator : MonoBehaviour
{
    private Vector3 _earthPoint = new Vector3(0, 0, 0);
    private float _rotateSpeed = 2f;

    void Update()
    {
        transform.RotateAround(_earthPoint, -Vector3.forward, _rotateSpeed * Time.deltaTime);
    }
}
