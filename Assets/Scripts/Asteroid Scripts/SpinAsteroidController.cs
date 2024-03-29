using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAsteroidController : MonoBehaviour
{
    private Rigidbody rb;

    private int spinDirection = 1;
    public float spinAngle = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.transform.eulerAngles = new Vector3(0f, rb.transform.eulerAngles.y + (spinAngle * spinDirection), 0f);
        rb.velocity += rb.transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        spinDirection *= -1;
    }

}
