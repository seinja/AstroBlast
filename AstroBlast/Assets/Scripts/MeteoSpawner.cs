using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoSpawner : MonoBehaviour
{
    public GameObject[] meteors  = new GameObject[3];
    private float _mapOffsetX = 70f;
    private float _mapOffsetY = 41f;
    private int _level;

    private void Start()
    {
        _level = GameManager.Instance.GetCurrentLevel() * 6 + 2;
        StartSpawn();
    }

    private void SpawnTargets() 
    {
        float randomX = Random.Range(_mapOffsetX, _mapOffsetX + 5);
        float randomY = Random.Range(_mapOffsetY, _mapOffsetY);
        int randMeteor = Random.Range(0, 3);

        float randPos = Random.Range(0, 10);
        if (randPos < 2.5)
        {
            
            Vector3 posiotionToSpawn = new Vector3(randomX, randomY, 0);
            Instantiate(meteors[randMeteor], posiotionToSpawn, Quaternion.identity);
        }
        else if (randPos > 2.5 && randPos < 5)
        {
            Vector3 posiotionToSpawn = new Vector3(-randomX, -randomY, 0);
            Instantiate(meteors[randMeteor], posiotionToSpawn, Quaternion.identity);
        }
        else if (randPos > 5 && randPos < 7.5)
        {
            Vector3 posiotionToSpawn = new Vector3(randomX, -randomY, 0);
            Instantiate(meteors[randMeteor], posiotionToSpawn, Quaternion.identity);
        }
        else if (randPos > 7.5 && randPos < 10) 
        {
            Vector3 posiotionToSpawn = new Vector3(-randomX, randomY, 0);
            Instantiate(meteors[randMeteor], posiotionToSpawn, Quaternion.identity);
        }
        
    }

    IEnumerator SpawnMeteorits() 
    {
        if (!GameManager.isGameWin && !GameManager.isGameOver)
        {
            for (int i = 0; i <= _level; i++)
            {
                SpawnTargets();
                yield return new WaitForSeconds(1f);
            }
        }
    }

    public void StartSpawn() 
    {
        StartCoroutine(SpawnMeteorits());
    }







}
