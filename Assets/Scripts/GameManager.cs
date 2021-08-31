using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int numAsteroidsSpawned = 0;
    private float timeUntilNextAsteroid = 10;

    LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        //initial spawning of asteroids
        StartCoroutine(IntialAsteroidSpawnTimer(3, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IntialAsteroidSpawnTimer(int initialNumAsteroidsSpawn, float timeBetweenSpawns)
    {
        for(int i = 1; i < initialNumAsteroidsSpawn; i++)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);

            SpawnAsteroid();
        }


        //start main asteroid spawning timer
        StartCoroutine(SpawnNextAsteroidTimer());
    }

    IEnumerator SpawnNextAsteroidTimer()
    {
        yield return new WaitForSeconds(timeUntilNextAsteroid);

        SpawnAsteroid();

        StartCoroutine(SpawnNextAsteroidTimer());
    }

    private void SpawnAsteroid()
    {
        levelManager.SpawnAsteroid();
    }
}
