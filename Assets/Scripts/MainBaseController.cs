using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBaseController : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        AsteroidController asteroid = other.gameObject.GetComponent<AsteroidController>();

        if (asteroid != null)
        {
            healthController.health--;
            Debug.Log($"{gameObject.name} HP: {healthController.health}");

            asteroid.DestroyAsteroid();

            if (healthController.health <= 0)
            {
                Debug.LogError("GAME OVER");
                Destroy(gameObject);
            }
        }
    }
}
