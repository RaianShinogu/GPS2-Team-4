using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public int StageCount;
    public GameObject BuildingUI;


    void Awake()
    {
        if(instance != null)
        {
            // if there is already an instance of BuildManager
            return;
        }
        instance = this;
    }

    public GameObject Building1;
    public GameObject Building2;

    private GameObject buildingChoice;

    public GameObject getBuildingChoice()
    {
        return buildingChoice;
    }

    public void setBuildingChoice(GameObject building)
    {
        buildingChoice = building;
    }

    public void EndStage()
    {
        if (StageCount >=    1)
        {
            buildingChoice = null;
            BuildingUI.SetActive(false) ;
        }
        StageCount++;
        
    }
}
