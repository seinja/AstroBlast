using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoController : MonoBehaviour, IPoolerdObject
{
    private Vector3 _eartPoint = new Vector3(0, 0, 0);
    private float _speed = 0.5f;
    private Vector3 _targetPos;

    public void OnObjectSpawn()
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        _targetPos = _eartPoint - transform.position;
    }

    void Update()
    {
        transform.Translate(_targetPos * _speed * Time.deltaTime);
    }
}
