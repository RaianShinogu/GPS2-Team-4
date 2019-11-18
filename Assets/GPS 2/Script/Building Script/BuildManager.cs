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
    public GameObject Building3;
    public GameObject UpBuilding1;
    public GameObject UpBuilding2;
    public GameObject UpBuilding3;
    //public GameObject demolish;
    ///public GameObject buildUI;
    //public GameObject endStageButton;

    //public GameObject uiCanvas;

    [SerializeField]private GameObject buildingChoice;
    public string type;
    private int StageCount = 0;
    public int gold = 100;

    public GameObject getBuildingChoice()
    {
        return buildingChoice;
    }

    public void setBuildingChoice(GameObject building)
    {
        buildingChoice = building;
    }

    public void BuildingType(string buildingType)
    {
        type = buildingType;
    }

    public void EndStage()
    {
        //uiCanvas.SetActive(false);
        if (StageCount >= 1)
        {
            buildingChoice = null;
            //buildUI.SetActive(false);
            //endStageButton.SetActive(false);
           
        }
        StageCount++;
    }
    public void setDemolishMode()
    {
        
        //buildingChoice = demolish;
    }

    public void Building1Cost()
    {
        gold -= 10;
    }

    public void Building2Cost()
    {
        gold -= 20;
    }
    public void Building3Cost()
    {
        gold -= 30;
    }

    public void SellBuilding1Gold()
    {
        gold += 5;
    }

    public void SellBuilding2Gold()
    {
        gold += 7;
    }

    public void SellBuilding3Gold()
    {
        gold += 10;
    }

    public void UpgradeBuilding1Cost()
    {
        gold -= 5;
    }

    public void UpgradeBuilding2Cost()
    {
        gold -= 10;
    }

    public void UpgradeBuilding3Cost()
    {
        gold -= 15;
    }
}
