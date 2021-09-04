using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] spawnPoints;

    public GameObject defaultAsteroid;

    public WaveSlot[] waves;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAsteroid(GameObject asteroidToSpawn)
    {
        GameObject randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(asteroidToSpawn, randomSpawnPoint.transform.position, randomSpawnPoint.transform.rotation);
    }

    //public void SpawnAsteroid(bool isSpecialAsteroid)
    //{
    //    GameObject randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
    //    SpawnPointController randomSpawnPointController = randomSpawnPoint.GetComponent<SpawnPointController>();

    //    GameObject asteroid;

    //    if (isSpecialAsteroid == false)
    //    {
    //        //spawn default asteroid
    //        asteroid = Instantiate(randomSpawnPointController.defaultAsteroid, randomSpawnPoint.transform.position, randomSpawnPoint.transform.rotation);
    //    }
    //    else
    //    {
    //        int rnd = Random.Range(0, randomSpawnPointController.specialAsteroids.Length);
    //        //spawn random special asteroid
    //        asteroid = Instantiate(randomSpawnPointController.specialAsteroids[rnd], randomSpawnPoint.transform.position, randomSpawnPoint.transform.rotation);
    //    }

    //    Debug.Log(randomSpawnPoint.transform.rotation);
    //}
}
