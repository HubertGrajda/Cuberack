using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPooler : MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    [SerializeField] private List<Pool> pools;
    [SerializeField] private Dictionary<string, List<GameObject>> poolDictionary;

    public static ObjectPooler Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        poolDictionary = new Dictionary<string, List<GameObject>>();

        foreach (Pool pool in pools)
        {
            List<GameObject> objectPool = new List<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject tmp = Instantiate(pool.prefab);
                tmp.SetActive(false);
                objectPool.Add(tmp);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (poolDictionary.ContainsKey(tag))
        {
            foreach (GameObject objectToPool in poolDictionary[tag])
            {
                if (!objectToPool.activeInHierarchy)
                {
                    GameObject spawnedObject = objectToPool;
                    if (spawnedObject != null)
                    {
                        spawnedObject.SetActive(true);
                        spawnedObject.transform.position = position;
                        spawnedObject.transform.rotation = rotation;
                    }
                    return spawnedObject;
                }
            }
            
        }
        return null;
    }

}
