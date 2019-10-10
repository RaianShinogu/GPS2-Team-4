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

    public GameObject Building1;
    public GameObject Building2;
    public GameObject demolish;
    public GameObject buildUI;
    public GameObject endStageButton;

    private GameObject buildingChoice;
    private int StageCount = 0;

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
        if(StageCount >= 1)
        {
            buildingChoice = null;
            buildUI.SetActive(false);
            endStageButton.SetActive(false);
        }
        StageCount++;
    }
    public void setDemolishMode()
    {
        buildingChoice = demolish;
    }
}
