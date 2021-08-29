using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject testObject;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(TestCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(1);

        Instantiate(testObject, gameObject.transform.position, gameObject.transform.rotation);

        //StartCoroutine(TestCoroutine());
    }
}
