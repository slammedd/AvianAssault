using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsManager : MonoBehaviour
{
    [Header("Bounds")]
    public float xBounds;
    public float yBounds;

    [Header("Asteroids")]
    public GameObject asteroidGroupPrefab;
    public int groupsPerSpawn;
    public float minTimeBetweenSpawn;
    public float maxTimeBetweenSpawn;
    public int asteroidHealth;

    private float xPos;
    private float yPos;
    private float timer;
    private bool timerComplete = true;
    private int asteroidSpawnCounter = 0;


    private void Update()
    {
        if(timer > 0 && timerComplete)
        {
            timer -= Time.deltaTime;
            timerComplete = false;
        }

        if (timer <= 0)
        {
            timerComplete = true;
        }

        if (timerComplete)
        {
            SpawnAsteroid();
            InvokeRepeating("SpawnAsteroid", 0.5f, 0.5f);
        }

        if(asteroidSpawnCounter == groupsPerSpawn)
        {
            CancelInvoke("SpawnAsteroid");
            asteroidSpawnCounter = 0;
        }

        //debug replace
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            timerComplete = true;
        }
    }

    private void SpawnAsteroid()
    {
        FindRandomPositionWithinBounds();
        FindRandomSpawnTime();

        float randomZRot = Random.Range(0, 360);

        Instantiate(asteroidGroupPrefab, new Vector2(xPos, yPos), Quaternion.Euler(new Vector3(0,0, randomZRot)));
        asteroidSpawnCounter += 1;
    }

    private void FindRandomPositionWithinBounds()
    {
        xPos = Random.Range(-xBounds, xBounds);
        yPos = Random.Range(-yBounds, yBounds);
    }

    private void FindRandomSpawnTime()
    {
        timer = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
    }
}
