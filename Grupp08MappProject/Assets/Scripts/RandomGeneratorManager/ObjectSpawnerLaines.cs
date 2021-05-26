using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerLaines : MonoBehaviour
{
    private List<string> objectTypes = new List<string>();

    public float yMin;
    public float yMax;
    public float xMax;
    public float yPadding;
    public Collider2D[] colliders;
    public LayerMask layer;
    public GameObject[] spawnPositions;


    private float timeMax = 10f;
    private float timeMin = 5f;
    private float timeCounter;

    [SerializeField] private bool run = true;

    private void Start()
    {
        SetUpAppearBoundariesOnScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
            AppearRandomOnScreen();
            timeCounter = Random.Range(timeMin, timeMax);
            run = false;
        }

        if (timeCounter != 0)
        {
            timeCounter -= Time.deltaTime;
            if (timeCounter <= 0)
            {  
                AppearRandomOnScreen();
                timeCounter = Random.Range(timeMin, timeMax);
            }
        }
    }

    private void SetUpAppearBoundariesOnScreen()
    {
        Camera camera = Camera.main;
        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0 + yPadding, 0)).y;
        yMax = camera.ViewportToWorldPoint(new Vector3(0, 1f - yPadding, 0)).y;

        xMax = camera.ViewportToWorldPoint(new Vector3(1f, 0, 0)).x;
    }



    public void AppearRandomOnScreen()
    {
        string poolTag = objectTypes[Random.Range(0, objectTypes.Count)];
        Vector3 newPos = spawnPositions[Random.Range(0, spawnPositions.Length - 1)].transform.position;

        // Clouds Check
        if (poolTag == "Cloud")
        {

            PoolManager.Instance.SpawnFromPool(poolTag, new Vector2(xMax, yMax), Quaternion.identity);
        }
        else
        {
            PoolManager.Instance.SpawnFromPool(poolTag, newPos, Quaternion.identity);
        }
    }

    public void SetUpWaves(WaveConfig config)
    {

        if (config.HasNewPools)
        {
            for (int i = 0; i < config.ListOfPools.Count; i++)
            {
                objectTypes.Add(config.ListOfPools[i].tag);
            }
        }

        timeMin = config.MinRandomTime;
        timeMax = config.MaxRandomTime;

        Debug.Log("Spawning should take between " + timeMin + " s and " + timeMax + " s");
    }




}
