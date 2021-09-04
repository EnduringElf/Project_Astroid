using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHUDController : MonoBehaviour
{
    public TextMeshProUGUI resourceText;
    public TextMeshProUGUI researchText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetResourceText(int resourceAmnt)
    {
        resourceText.text = $"Power: {resourceAmnt}";
    }

    public void SetResearchText(int researchAmnt)
    {
        researchText.text = $"Research: {researchAmnt}";
    }
}
