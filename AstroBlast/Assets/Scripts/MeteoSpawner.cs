using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _meteor;
    private float _mapOffsetX = 70f;
    private float _mapOffsetY = 41f;
    private void Start()
    {
        InvokeRepeating("SpawnTargets", 1f, 1f);
        
    }

    

    private void SpawnTargets() 
    {
        float randomX = Random.Range(_mapOffsetX, _mapOffsetX + 5);
        float randomY = Random.Range(_mapOffsetY, _mapOffsetY);

        float randPos = Random.Range(0, 10);
        if (randPos > 5) { randomX = -randomX; randomY = -randomY; }
        Vector3 posiotionToSpawn = new Vector3(randomX, randomY, 0);
        Instantiate(_meteor, posiotionToSpawn, Quaternion.identity);
    }





}
