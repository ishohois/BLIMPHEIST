using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float spawnRate = 4f;
    public float planetMin = -1f;
    public float planetMax = 3.5f;

    public GameObject[] obstacles;
    private float timeSinceLatSpawned;
    private float spawnXPosition = 10f;
    private GameObject currentObstacle;
    private int index;

    public AudioClip obstacleSpawn;

    // Update is called once per frame
    void Update()
    {
        timeSinceLatSpawned += Time.deltaTime;
        index = Random.Range(0, obstacles.Length);
        currentObstacle = obstacles[index];

        if (GameController.instance.gameOver == false && timeSinceLatSpawned >= spawnRate)
        {
            timeSinceLatSpawned = 0;
            float spawnYPosition = Random.Range(planetMin, planetMax);
            Vector2 spawnPosition = new Vector2(spawnXPosition, spawnYPosition);
            Instantiate(currentObstacle, spawnPosition, Quaternion.identity);
            GameController.instance.PlaySound(obstacleSpawn);
        }
    }
}
