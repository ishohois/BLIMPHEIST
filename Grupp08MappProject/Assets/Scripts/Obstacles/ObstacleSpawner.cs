using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float spawnRate = 4f;
    public float planetMin = -1f;
    public float planetMax = 3.5f;

    public GameObject[] obstacles;
    public GameObject[] pickup;
    private float timeSinceLatSpawned;
    private float spawnXPosition = 10f;
    private GameObject currentObstacle;
    private GameObject currentPickup;

    public AudioClip obstacleSpawn;


    int counter = 0;

    // Update is called once per frame
    void Update()
    {
        timeSinceLatSpawned += Time.deltaTime;



        if (GameController.instance.gameOver == false && timeSinceLatSpawned >= spawnRate)
        {
            timeSinceLatSpawned = 0;


            int index = Random.Range(0, obstacles.Length);
            currentObstacle = obstacles[index];

            float spawnYPosition = Random.Range(planetMin, planetMax);
            Vector2 spawnPosition = new Vector2(spawnXPosition, spawnYPosition);
            Instantiate(currentObstacle, spawnPosition, Quaternion.identity);



            if (counter == 1)
            {
                index = Random.Range(0, pickup.Length);
                currentPickup = pickup[index];

                float newPosition = GetNewSpawnPosition(spawnYPosition);

                if(newPosition > -900f)
                    spawnPosition = new Vector2(spawnXPosition, newPosition);
                RecursiveCounter = 0;
                Instantiate(currentPickup, spawnPosition, Quaternion.identity);

                counter = -1;
            }

            counter++;

            GameController.instance.PlaySound(obstacleSpawn);
        }
    }

    int RecursiveCounter = 0; //Anv�nds s� att GetNewSpawnPoint elsen kan g�ras f�revigt. Kan crasha unity annars

    private float GetNewSpawnPosition(float oldYPosition)
    {
        float newYPosition = 0f;
        newYPosition = Random.Range(planetMin, planetMax);
        RecursiveCounter++;
        if (newYPosition > oldYPosition + 1f || newYPosition < oldYPosition - 1f)
        {
            //Det h�r �r bra    
            //pickups kan dock spawnas innuti obstacle om newYPosition �r utanf�r max och min f�r sk�rmen
        }
        else
        {
            if (RecursiveCounter < 20)
                GetNewSpawnPosition(oldYPosition);
            return -1000f;
        }

        return newYPosition;
    }






}
