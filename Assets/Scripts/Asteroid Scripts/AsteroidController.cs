using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    HealthController healthController;

    // Start is called before the first frame update
    void Start()
    {
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
