using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    public int resourceIncrease = 1;
    public int increaseTime = 1;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        StartCoroutine(IncreaseResourcesTimer());

    }

    public void IncreaseResources()
    {
        player.Resource += resourceIncrease;
        //Debug.Log($"{gameObject.name}: increased resources");

    }

    IEnumerator IncreaseResourcesTimer()
    {
        yield return new WaitForSeconds(increaseTime);

        IncreaseResources();

        StartCoroutine(IncreaseResourcesTimer());
    }
}
