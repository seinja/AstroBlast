using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoSpawner : MonoBehaviour
{
    ObjectPoler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPoler.Instance; 
    }


    private void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Moon", new Vector3(3, 4, 0), Quaternion.identity);
    }
}
