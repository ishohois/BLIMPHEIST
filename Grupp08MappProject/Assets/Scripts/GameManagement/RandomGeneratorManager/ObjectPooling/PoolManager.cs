using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    public Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    #region
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    public void SetUpPools(WaveConfig waveConfig)
    {
        foreach (var pool in waveConfig.ListOfPools)
        {
            if (!poolDictionary.ContainsKey(pool.tag))
            {
                poolDictionary.Add(pool.tag, new Queue<GameObject>());
            }
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                poolDictionary[pool.tag].Enqueue(obj);
            }

        }
    }

    public void ChangePools(WaveConfig waveConfig)
    {
        foreach (var pool in waveConfig.ListOfPools)
        {
            if (waveConfig.HasNewPools)
            {
                if (poolDictionary.ContainsKey(pool.tag) && poolDictionary[pool.tag].Count != pool.size)
                {
                    for (int i = 0; i < pool.size; i++)
                    {
                        GameObject obj = Instantiate(pool.prefab);
                        obj.SetActive(false);
                        poolDictionary[pool.tag].Enqueue(obj);
                    }
                }

                if (!poolDictionary.ContainsKey(pool.tag))
                {
                    poolDictionary.Add(pool.tag, new Queue<GameObject>());
                    for (int i = 0; i < pool.size; i++)
                    {
                        GameObject obj = Instantiate(pool.prefab);
                        obj.SetActive(false);
                        poolDictionary[pool.tag].Enqueue(obj);
                    }
                }
            }

            if (pool.hasParameterChanges)
            {
                Queue<GameObject> objs = poolDictionary[pool.tag];

                foreach (GameObject obj in objs)
                {
                    obj.GetComponent<ScrollingObjects>().scrollSpeed -= pool.scrollSpeedIncrement;
                }
            }
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

}

