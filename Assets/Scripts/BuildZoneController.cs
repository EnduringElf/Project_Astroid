using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildZoneController : MonoBehaviour
{
    private PlayerController player;

    private bool available = true;

    public GameObject[] structureOptions;
    public Material selectedMaterial;

    private MeshRenderer mesh;
    private Material unselectedMaterial;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        mesh = gameObject.GetComponent<MeshRenderer>();
        unselectedMaterial = mesh.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    //void OnMouseOver()
    {
        //Debug.Log("BUILD ZONE " + gameObject.name + " SELECTED");
        player.BuildZoneSelected = gameObject;
        mesh.material = selectedMaterial;
    }

    void OnMouseExit()
    {
        player.BuildZoneSelected = null;

        mesh.material = unselectedMaterial;
    }

    public void PlaceStructureOnZone(int structureNum)
    {
        if(available == true)
        {
            StructureController structureController = structureOptions[structureNum - 1].GetComponent<StructureController>();

            if (structureController.resourceCost <= player.Resource)
            {
                player.Resource -= structureController.resourceCost;

                GameObject placedStructure = (GameObject)Instantiate(structureOptions[structureNum - 1], gameObject.transform.position, gameObject.transform.rotation);
                placedStructure.GetComponent<StructureController>().BuildZone = gameObject.GetComponent<BuildZoneController>();

                available = false;
                gameObject.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                Debug.Log("Not enough resources to place structure");
            }
        }

    }

    public void StructureDestroyedOnZone()
    {
        available = true;

        gameObject.GetComponent<Renderer>().enabled = true;

    }
}
