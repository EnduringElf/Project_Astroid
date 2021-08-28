using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class base_tower : MonoBehaviour
{

    public int basehealth = 3;
    public int maxhealth = 10;
    public int currenthealth;


    // Start is called before the first frame update
    void Start()
    {
        currenthealth = basehealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Astroid")
        {
            currenthealth--;
            isdead();
        }
    }

    private void isdead()
    {
        if(currenthealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}
