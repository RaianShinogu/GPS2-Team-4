﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject Currency;

    private GameObject buildingChoice;
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
        if(StageCount >= 1)
        {
            buildingChoice = null;
            endStageButton.SetActive(false);
        }
        StageCount++;
    }
    public void setDemolishMode()
    {
        buildingChoice = demolish;
    }

    public void Building1Cost()
    {
        gold -= 10;
        Currency.GetComponent<Text>().text = "Currency: " + (gold - 10);
    }

    public void Building2Cost()
    {
        gold -= 20;
        Currency.GetComponent<Text>().text = "Currency: " + (gold - 20);
    }
}
