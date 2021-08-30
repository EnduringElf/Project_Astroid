using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildZoneController : MonoBehaviour
{
    private PlayerController player;

    private bool available = true;

    public GameObject[] buildingOptions;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    //void OnMouseOver()
    {
        Debug.Log("BUILD ZONE " + gameObject.name + " SELECTED");
        player.BuildZoneSelected = gameObject;
    }

    void OnMouseExit()
    {
        player.BuildZoneSelected = null;
    }

    public void PlaceBuildingOnZone(int buildingNum)
    {
        if(available == true)
        {
            Instantiate(buildingOptions[buildingNum - 1], gameObject.transform.position, gameObject.transform.rotation);

            //gameObject.transform.position += new Vector3(0f, 10f, 0f);
            available = false;
        }

    }

    public void BuildingDestroyedOnZone()
    {
        available = true;
    }
}
