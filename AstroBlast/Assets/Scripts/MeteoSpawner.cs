using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoSpawner : MonoBehaviour
{
    ObjectPoler objectPooler;
    private float _mapOffsetX = 13.5f;
    private float _mapOffsetY = 7.85f;
    private void Start()
    {
        objectPooler = ObjectPoler.Instance;
        InvokeRepeating("SpawnTargets", 1f, 0.5f);
        
    }

    

    private void SpawnTargets() 
    {
        float randomX = Random.Range(_mapOffsetX, _mapOffsetX + 2);
        float randomY = Random.Range(_mapOffsetY, _mapOffsetY + 2);

        float randPos = Random.Range(1, 2);
        if (randPos == 1) { randomX = -randomX; randomY = -randomY; }
        Vector3 posiotionToSpawn = new Vector3(randomX, randomY, 0);
        objectPooler.SpawnFromPool("Moon", posiotionToSpawn, Quaternion.identity);
    }





}
