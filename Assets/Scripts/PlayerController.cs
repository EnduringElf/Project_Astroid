using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private Camera mainCamera;

    private int resource;

    public int Resource
    {
        get 
        { 
            return resource; 
        }
        set 
        { 
            resource = value;
            //Debug.Log($"Resource: {resource}");
        }
    }

    public GameObject BuildZoneSelected { get; set; }   


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();

        //Resource = 10;
        //StartCoroutine(IncreaseResourcesTimer());
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

            //Debug.DrawRay(Input.mousePosition + new Vector3(0f, 100f, 0f), -Vector3.up, Color.green, 2, false);

        }
        //rb.transform.eulerAngles = new Vector3(0f,rb.transform.eulerAngles.y + 20f,0f);
        //rb.MoveRotation(Quaternion.Euler(0f, rb.transform.rotation.eulerAngles.y + 10, 0f));
        //rb.angularVelocity = new Vector3(0, 3, 0);
        //rb.AddTorque(new Vector3(0f, 200f, 0f));

        if(BuildZoneSelected != null)
        {
            Debug.Log(BuildZoneSelected.name);

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(BuildZoneSelected != null)
            {
                BuildZoneSelected.GetComponent<BuildZoneController>().PlaceStructureOnZone(3);
            }

            //Destroy(BuildZoneSelected);
        }
    }

    //public void IncreaseResources(int change)
    //{
    //    Resource += change;
    //}

    //IEnumerator IncreaseResourcesTimer()
    //{
    //    yield return new WaitForSeconds(1);

    //    IncreaseResources(1);

    //    StartCoroutine(IncreaseResourcesTimer());
    //}
}
