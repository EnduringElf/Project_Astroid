using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;

    public float movementSpeed = 10;
    public float minMovementSpeed = 1;
    private bool allowMove = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //direction = transform.forward;


        //StartCoroutine(TestCoroutine());
    }



    void FixedUpdate()
    {
        
        if (allowMove)
        {
            //rb.velocity = transform.forward * movementSpeed;

            float changeSpeed = movementSpeed - rb.velocity.magnitude;
            Vector3 changeVelocity = changeSpeed * rb.transform.forward;
            rb.velocity += changeVelocity;

            //Quaternion rotation = Quaternion.LookRotation(rb.velocity);
            //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotation.eulerAngles.y, transform.rotation.eulerAngles.x);

            //Debug.Log(rb.velocity.magnitude);

        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    private void LateUpdate()
    {
        if(rb.velocity.magnitude != 0)
        {
            Quaternion rotation = Quaternion.LookRotation(rb.velocity);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotation.eulerAngles.y, transform.rotation.eulerAngles.x);
        }

    }

    public void UpdateAllowMove(bool newAllowMove)
    {
        allowMove = newAllowMove;
    }

    public void UpdateMovementSpeed(float newSpeed)
    {
        movementSpeed = newSpeed;

        if(movementSpeed < minMovementSpeed)
        {
            movementSpeed = minMovementSpeed;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
        //if (allowReflect)
        //{
        //    RaycastHit hit;
        //    if (Physics.Raycast(transform.position, collision.contacts[0].point, out hit))
        //    {
        //        Debug.Log("Point of contact: " + hit.point);
        //        direction = Vector3.Reflect(transform.forward, hit.normal);

        //        //direction = transform.forward * -1;

        //        Quaternion rotation = Quaternion.LookRotation(direction);
        //        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotation.eulerAngles.y, transform.rotation.eulerAngles.x);
        //    }
        //}

        //if (allowReflect)
        //{
        //    direction = Vector3.Reflect(transform.forward, collision.contacts[0].normal);

        //    Quaternion rotation = Quaternion.LookRotation(direction);
        //    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotation.eulerAngles.y, transform.rotation.eulerAngles.x);

        //}

        //Destroy(gameObject);
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (allowReflect)
    //    {
    //        RaycastHit hit;
    //        if (Physics.Raycast(transform.position, other.transform.position, out hit))
    //        {
    //            Debug.Log("Point of contact: " + hit.point);
    //            direction = Vector3.Reflect(transform.forward, hit.normal);

    //            Quaternion rotation = Quaternion.LookRotation(direction);
    //            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotation.eulerAngles.y, transform.rotation.eulerAngles.x);
    //        }
    //    }

    //}


    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(5);

        movementSpeed = 20;

        yield return new WaitForSeconds(5);

        movementSpeed = 5;

        yield return new WaitForSeconds(5);

        movementSpeed = 30;

    }

}
