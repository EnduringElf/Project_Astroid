using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }


    void FixedUpdate()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (ground.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            rb.transform.LookAt(pointToLook);

        }
        //rb.transform.eulerAngles = new Vector3(0f,rb.transform.eulerAngles.y + 10f,0f);
        //rb.MoveRotation(Quaternion.Euler(0f, rb.transform.rotation.eulerAngles.y + 10, 0f));
        //rb.angularVelocity = new Vector3(0, 3, 0);
        //rb.AddTorque(new Vector3(0f, 200f, 0f));

        //if (Input.GetKey(KeyCode.D))
        //{
        //    rb.transform.eulerAngles = new Vector3(0f,rb.transform.eulerAngles.y + 8f,0f);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    rb.transform.eulerAngles = new Vector3(0f, rb.transform.eulerAngles.y - 8f, 0f);
        //}
    }
}
