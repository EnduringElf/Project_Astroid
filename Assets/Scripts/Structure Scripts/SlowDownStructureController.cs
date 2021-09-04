using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownStructureController : MonoBehaviour
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
        //AsteroidController asteroidController = other.gameObject.GetComponent<AsteroidController>();

        if (other.gameObject.GetComponent<AsteroidController>() != null)
        {
            MovementController asteroidMovement = other.GetComponent<MovementController>();
            asteroidMovement.UpdateMovementSpeed(asteroidMovement.movementSpeed/1.25f);
        }
    }
}
