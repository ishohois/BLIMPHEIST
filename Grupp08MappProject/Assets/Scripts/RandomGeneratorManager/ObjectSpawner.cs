using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private List<string> objectTypes = new List<string>();

    public float yMin;
    public float yMax;
    public float yPadding;
    public Collider2D[] colliders;
    public LayerMask layer;
    public float spawnRadius = 1f;

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
            Debug.Log(timeCounter);
            run = false;
        }

        if (timeCounter != 0)
        {
            timeCounter -= Time.deltaTime;
            if (timeCounter <= 0)
            {
                AppearRandomOnScreen();
                timeCounter = Random.Range(timeMin, timeMax);
                Debug.Log(timeCounter);
            }
        }
    }

    private void SetUpAppearBoundariesOnScreen()
    {
        Camera camera = Camera.main;
        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0 + yPadding, 0)).y;
        yMax = camera.ViewportToWorldPoint(new Vector3(0, 1f - yPadding, 0)).y;
    }

    private Vector3 GetRandomPos()
    {
        var newYPos = Random.Range(yMin, yMax);
        var squarePos = new Vector3(gameObject.transform.position.x, newYPos, 0f);
        return squarePos;
    }

    private bool PreventOverlappingPosition()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, spawnRadius, layer);

        return colliders.Length == 0;
    }

    public void AppearRandomOnScreen()
    {
        string poolTag = objectTypes[Random.Range(0, objectTypes.Count)];
        int tries = 0;
        transform.position = GetRandomPos();
        while (!PreventOverlappingPosition())
        {
            transform.position = GetRandomPos();
            Debug.Log("Searching new pos");
            tries++;
            if (tries >= 20)
            {
                break;
            }
        }

        if (PreventOverlappingPosition())
        {
            PoolManager.Instance.SpawnFromPool(poolTag, transform.position, Quaternion.identity);
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
