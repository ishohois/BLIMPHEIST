using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneratorManager : MonoBehaviour
{
    [SerializeField] private float[] timeStamps;
    private float timeCounter;
    private int index;
    private bool run = true;

    public WaveConfig[] configs;
    public ObjectSpawner spawner;

    void Start()
    {
        if (configs != null)
        {
            PoolManager.Instance.SetUpPools(configs[0]);
            timeCounter = timeStamps[0];
            spawner.SetUpWaves(configs[0]);
        }
    }

    void Update()
    {
        if (run)
        {
            RunTime();

            if (timeCounter <= 0)
            {
                Debug.Log("Wave " + index + 1);
                if (index <= timeStamps.Length - 1)
                {
                    timeCounter = timeStamps[index++];
                    Debug.Log("index is : " + index);
                }
                else { run = false; }

                if (index != 0)
                {
                    PoolManager.Instance.ChangePools(configs[index]);
                    spawner.SetUpWaves(configs[index]);
                }
            }
        }
    }

    private void RunTime()
    {
        timeCounter -= Time.deltaTime;
    }
}
