using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    
    void Awake()
    {
        if(instance != null)
        {
            // if there is already an instance of BuildManager
            return;
        }
        instance = this;
    }

    [SerializeField] GameObject defaultBuilding;

    void Start()
    {
        buildingChoice = defaultBuilding;
    }

    private GameObject buildingChoice;

    public GameObject getBuildingChoice()
    {
        return buildingChoice;
    }
}
