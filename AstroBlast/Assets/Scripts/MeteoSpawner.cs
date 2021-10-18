using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoSpawner : MonoBehaviour
{
    public GameObject[] meteors  = new GameObject[3];
    private int _countOfMeteorsOnLevel;
    private float _mapOffsetX = 70f;
    private float _mapOffsetY = 41f;

    private void Start()
    {
        _countOfMeteorsOnLevel = 0;
        _countOfMeteorsOnLevel += GameManager.Instance.GetCurrentLevel() * 3;
        SpawnOtherMeteor();
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

    public void SpawnOtherMeteor() 
    {
        if (!GameManager.isGameWin && !GameManager.isGameOver) 
        {
            if (_countOfMeteorsOnLevel >= 0) 
            {
                _countOfMeteorsOnLevel--;
                SpawnTargets();
            }
        }
    }

    public void RestartSpawn() 
    {
        _countOfMeteorsOnLevel = 0;
        _countOfMeteorsOnLevel += GameManager.Instance.GetCurrentLevel() * 3;
        SpawnTargets();
    }

   







}
