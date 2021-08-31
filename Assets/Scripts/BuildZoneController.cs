using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildZoneController : MonoBehaviour
{
    private PlayerController player;

    private bool available = true;

    public GameObject[] structureOptions;

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

    public void PlaceStructureOnZone(int structureNum)
    {
        if(available == true)
        {

            GameObject placedStructure = (GameObject)Instantiate(structureOptions[structureNum - 1], gameObject.transform.position, gameObject.transform.rotation);
            placedStructure.GetComponent<StructureController>().BuildZone = gameObject.GetComponent<BuildZoneController>();

            available = false;
        }

    }

    public void StructureDestroyedOnZone()
    {
        available = true;
    }
}
