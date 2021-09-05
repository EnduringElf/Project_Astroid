using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //private int numAsteroidsSpawned = 0;
    //private float timeUntilNextAsteroid = 10;

    private int waveNum = 0;

    LevelManager levelManager;

    private PlayerController player;

    private int researchGoal = 250;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<PlayerController>();


        StartCoroutine(InitialGameStartDelay(3f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.Research >= researchGoal)
        {
            //Debug.Log("<<< GAME WIN!!! >>>");
        }
    }

    IEnumerator InitialGameStartDelay(float time)
    {
        yield return new WaitForSeconds(time);

        StartAsteroidWave();

        Debug.Log("GAME START!");
    }


    public void StartAsteroidWave()
    {
        Debug.Log($"CURRENT WAVE: {waveNum}");

        GameObject[] asteroidsToSpawn = SetUpWaves(levelManager.waves[waveNum]);
        float timeUntilNextWave = levelManager.waves[waveNum].delayAfterWave;

        StartCoroutine(SpawnAsteroidsInWave(asteroidsToSpawn, timeUntilNextWave));
    }

    IEnumerator SpawnAsteroidsInWave(GameObject[] asteroidsToSpawn, float timeUntilNextWave)
    {
        for(int i = 0; i < asteroidsToSpawn.Length; i++)
        {
            levelManager.SpawnAsteroid(asteroidsToSpawn[i]);

            //add a delay only if an asteroid will spawn next iteration
            if (i < (asteroidsToSpawn.Length - 1))
            {
                yield return new WaitForSeconds(Random.Range(2, 3f));
            }
        }


        yield return new WaitForSeconds(timeUntilNextWave);

        waveNum++;

        if(waveNum > (levelManager.waves.Length - 1))
        {
            waveNum--;
        }

        StartAsteroidWave();
    }


    public GameObject[] SetUpWaves(WaveSlot wave)
    {
        GameObject[] asteroids = new GameObject[wave.numDefaultAsteroids + wave.specialAsteroids.Length];

        //adds default asteroids
        for(int i = 0; i < wave.numDefaultAsteroids; i++)
        {
            asteroids[i] = levelManager.defaultAsteroid;
            //Debug.Log($"Default: {asteroids[i]}");
        }

        int counter = 0;

        //adds special asteroids
        for (int i = wave.numDefaultAsteroids; i < asteroids.Length; i++)
        {
            asteroids[i] = wave.specialAsteroids[counter];
            counter++;

            //Debug.Log($"Special: {asteroids[i]}");
        }


        //shuffle asteroids array
        for (int i = 0; i < asteroids.Length - 1; i++)
        {
            int rnd = Random.Range(i, asteroids.Length);
            GameObject tempAsteroid = asteroids[rnd];
            asteroids[rnd] = asteroids[i];
            asteroids[i] = tempAsteroid;
        }

        //for (int i = 0; i < asteroids.Length; i++)
        //{
        //    Debug.Log(asteroids[i]);
        //}

        return asteroids;
    }




    //IEnumerator IntialAsteroidSpawnTimer(int initialNumAsteroidsSpawn, float timeBetweenSpawns)
    //{
    //    for(int i = 1; i < initialNumAsteroidsSpawn; i++)
    //    {
    //        yield return new WaitForSeconds(timeBetweenSpawns);

    //        //SpawnAsteroid();
    //    }


    //    //start main asteroid spawning timer
    //    StartCoroutine(SpawnNextAsteroidTimer());
    //}

    //IEnumerator SpawnNextAsteroidTimer()
    //{
    //    yield return new WaitForSeconds(timeUntilNextAsteroid);

    //    SpawnAsteroid();



    //    StartCoroutine(SpawnNextAsteroidTimer());
    //}

}
