using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAsteroidStructureController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        AsteroidController asteroid = other.gameObject.GetComponent<AsteroidController>();
        if (asteroid != null)
        {
            asteroid.DestroyAsteroid();
        }
    }
}
