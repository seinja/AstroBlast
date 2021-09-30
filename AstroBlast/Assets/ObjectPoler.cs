using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoler : MonoBehaviour
{
    [System.Serializable]
    public class Pool 
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPoler Instance;

    #region Singleton 
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDicrionary;
    
    void Start()
    {
        poolDicrionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) 
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = (GameObject)Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDicrionary.Add(pool.tag, objectPool);
        }
    }



    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) 
    {
        if (!poolDicrionary.ContainsKey(tag)) 
        {
            Debug.Log("Warning, tag " + tag + "dosn't exist");
            return null;
        }

        GameObject objectToSpawn = (GameObject) poolDicrionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDicrionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    
}
