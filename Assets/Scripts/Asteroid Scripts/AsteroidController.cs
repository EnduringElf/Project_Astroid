using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    HealthController healthController;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        ////rotate asteroid to move towards the centre of the screen when spawned
        //rb.transform.LookAt(Vector3.zero);

        healthController = GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        healthController.health--;
        Debug.Log($"{gameObject.name} HP: {healthController.health}");

        if (healthController.health <= 0)
        {
            DestroyAsteroid();
        }
    }

    public void DestroyAsteroid()
    {
        Destroy(gameObject);
    }
}
