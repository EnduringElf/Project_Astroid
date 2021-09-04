using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateAsteroidController : MonoBehaviour
{
    private MovementController movement;
    private int accelOrDecel = 1;

    public float speedIncreaseDecrease = 0.2f;
    private float minSpeed;
    public float maxSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        movement = gameObject.GetComponent<MovementController>();

        minSpeed = movement.minMovementSpeed;

        //StartCoroutine(SwapAccelerateOrDecelerate());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        movement.UpdateMovementSpeed(movement.movementSpeed + (speedIncreaseDecrease * accelOrDecel));

        if(movement.movementSpeed >= maxSpeed)
        {
            accelOrDecel = -1;
            Debug.Log("DECELERATE");
        }
        if(movement.movementSpeed <= minSpeed)
        {
            accelOrDecel = 1;
            Debug.Log("ACCELERATE");

        }
    }

    IEnumerator SwapAccelerateOrDecelerate()
    {
        yield return new WaitForSeconds(1);
        accelOrDecel *= -1;

        StartCoroutine(SwapAccelerateOrDecelerate());
    }
}
