using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string Explaination;
    public string BuildingUI;
    public string BuildingExplaination;
    public string Demolish;
    public string Gold;

    public GameObject otherNodes;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setActiveOtherNode()
    {
        otherNodes.SetActive(true);
    }
}
