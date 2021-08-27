using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;

    public float movementSpeed = 10;
    public bool allowReflect = true;
    private bool allowMove = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        direction = transform.forward;
    }


    void FixedUpdate()
    {
        if (allowMove)
        {
            rb.velocity = transform.forward * movementSpeed;
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    public void UpdateAllowMove(bool newAllowMove)
    {
        allowMove = newAllowMove;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (allowReflect)
        {
            direction = Vector3.Reflect(transform.forward, collision.contacts[0].normal);

            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotation.eulerAngles.y, transform.rotation.eulerAngles.x);

            Debug.Log(collision.contacts[0].normal);
        }
    }
}
