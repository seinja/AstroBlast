using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _meteor;
    private float _mapOffsetX = 70f;
    private float _mapOffsetY = 41f;
    private int _level;

    private void Start()
    {
        _level = GameManager.Instance.GetCurrentLevel() * 6;
        StartCoroutine(SpawnMeteorits()); 
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

    IEnumerator SpawnMeteorits() 
    {
        if (!GameManager.isGameWin && !GameManager.isGameOver)
        {
            for (int i = 0; i < _level; i++)
            {
                SpawnTargets();
                yield return new WaitForSeconds(1f);
            }
        }
    }

    public void StartSpawn() 
    {
        _level = GameManager.Instance.GetCurrentLevel() * 6;
        StartCoroutine(SpawnMeteorits());
    }







}
