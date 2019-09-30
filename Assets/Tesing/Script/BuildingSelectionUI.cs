using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelectionUI : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void Slot1Building()
    {
        Debug.Log("Sphere selected!");
        buildManager.setBuildingChoice(buildManager.Building1);
    }

    public void Slot2Building()
    {
        Debug.Log("Cube selected!");
        buildManager.setBuildingChoice(buildManager.Building2);
    }
}
