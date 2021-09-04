using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureController : MonoBehaviour
{
    HealthController healthController;

    public int resourceCost = 10;

    public BuildZoneController BuildZone { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        healthController = GetComponent<HealthController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<AsteroidController>() != null)
        {
            healthController.health--;
            Debug.Log($"{gameObject.name} HP: {healthController.health}");

            if (healthController.health <= 0)
            {
                BuildZone.StructureDestroyedOnZone();

                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<AsteroidController>() != null)
        {
            healthController.health--;
            Debug.Log($"{gameObject.name} HP: {healthController.health}");

            if (healthController.health <= 0)
            {
                BuildZone.StructureDestroyedOnZone();

                Destroy(gameObject);
            }
        }
    }
}
