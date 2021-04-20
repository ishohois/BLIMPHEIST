using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public int obstaclePoolSize = 5;
    public GameObject obstaclePrefab;
    public float spawnRate = 4f;
    public float planetMin = -1f;
    public float planetMax = 3.5f;

    private GameObject[] obstacles;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLatSpawned;
    private float spawnXPosition = 10f;
    private int currentPlanet = 0;

    public AudioClip obstacleSpawn;
    // Start is called before the first frame update
    void Start()
    {
        obstacles = new GameObject[obstaclePoolSize];
        for (int i = 0; i < obstaclePoolSize; i++)
        {
            obstacles[i] = (GameObject)Instantiate(obstaclePrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLatSpawned += Time.deltaTime;

        if (GameController.instance.gameOver == false && timeSinceLatSpawned >= spawnRate)
        {
            timeSinceLatSpawned = 0;
            float spawnYPosition = Random.Range(planetMin, planetMax);
            obstacles[currentPlanet].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentPlanet++;
            GameController.instance.PlaySound(obstacleSpawn);
            if (currentPlanet >= obstaclePoolSize)
            {
                currentPlanet = 0;
            }
        }
    }
}
