using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchController : MonoBehaviour
{
    public int researchIncrease = 1;
    public int increaseTime = 1;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        StartCoroutine(IncreaseResearchTimer());

    }

    public void IncreaseResearch()
    {
        player.Research += researchIncrease;
        //Debug.Log($"{gameObject.name}: increased research");

    }

    IEnumerator IncreaseResearchTimer()
    {
        yield return new WaitForSeconds(increaseTime);

        IncreaseResearch();

        StartCoroutine(IncreaseResearchTimer());
    }
}
