using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region BuildManager
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
    #endregion

    #region Public Variable
    public GameObject Building1;
    public GameObject Building2;
    public GameObject Building3;
    public GameObject UpBuilding1;
    public GameObject UpBuilding2;
    public GameObject UpBuilding3;
    public GameObject Building1Ghost;
    public GameObject Building2Ghost;
    public GameObject Building3Ghost;
    [HideInInspector]
    public string type;
    #endregion

    #region Designer Editor
    [Header("Designer Editor")]
    public int gold = 100;
    #endregion

    #region Private Variable
    [SerializeField]private GameObject buildingChoice;
    private int StageCount = 0;
    #endregion

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
        if (StageCount >= 1)
        {
            buildingChoice = null;
           
        }
        StageCount++;
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
        gold -= 15;
    }

    public void UpgradeBuilding2Cost()
    {
        gold -= 29;
    }

    public void UpgradeBuilding3Cost()
    {
        gold -= 44;
    }

    #region incomeManager
    public void income(int amount)
    {    
        gold += amount;     
        
    }
    #endregion
}
