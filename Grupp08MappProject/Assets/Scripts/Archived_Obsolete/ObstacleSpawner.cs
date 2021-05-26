using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float spawnRate;
    public float planetMin = -5f;
    public float planetMax = 4f;

    public string[] objectTypes;

    //public GameObject[] obstacles;
    //public GameObject[] pickup;
    private float timeSinceLatSpawned;
    private float spawnXPosition = 10f;
    //private GameObject currentObstacle;
    //private GameObject currentPickup;

    //public AudioClip obstacleSpawner;
    public AudioSource obstacleSpawn;


    int counter = 0;

    // Update is called once per frame
    void Update()
    {
        timeSinceLatSpawned += Time.deltaTime;


        if (GameController.instance.gameOver == false && timeSinceLatSpawned >= spawnRate)
        {
            timeSinceLatSpawned = 0;


            //int index = Random.Range(0, obstacles.Length);
            //currentObstacle = obstacles[index];

            float spawnYPosition = Random.Range(planetMin, planetMax);
            string tag = objectTypes[Random.Range(0, objectTypes.Length)];
            Vector2 spawnPosition = new Vector2(spawnXPosition, spawnYPosition);
            //Instantiate(currentObstacle, spawnPosition, Quaternion.identity);
            PoolManager.Instance.SpawnFromPool(tag, spawnPosition, Quaternion.identity);



            //if (counter == 1)
            //{
       
            //    //index = Random.Range(0, pickup.Length);
            //    //currentPickup = pickup[index];

            //    float newPosition = GetNewSpawnPosition(spawnYPosition);

            //    if (newPosition > -900f)
            //        spawnPosition = new Vector2(spawnXPosition, newPosition);
            //    RecursiveCounter = 0;
            //    //Instantiate(currentPickup, spawnPosition, Quaternion.identity);

            //    //Logic for spawning object from the pool
                

            //    counter = -1;
            //}

            //counter++;

            
            float target = -15.0f;
            float delta = target + spawnRate;
            delta *= Time.deltaTime;
            spawnRate += delta / 2;
            

            //obstacleSpawn.Play();
            //GameController.instance.PlaySound(obstacleSpawn);
        }
    }

    int RecursiveCounter = 0; //Används så att GetNewSpawnPoint elsen kan göras förevigt. Kan crasha unity annars

    private float GetNewSpawnPosition(float oldYPosition)
    {
        float newYPosition = 0f;
        newYPosition = Random.Range(planetMin, planetMax);
        RecursiveCounter++;
        if (newYPosition > oldYPosition + 1f || newYPosition < oldYPosition - 1f)
        {
            //Det här är bra    
            //pickups kan dock spawnas innuti obstacle om newYPosition är utanför max och min för skärmen
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
