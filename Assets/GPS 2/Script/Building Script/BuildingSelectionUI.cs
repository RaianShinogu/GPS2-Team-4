using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSelectionUI : MonoBehaviour
{
    BuildManager buildManager;
    [SerializeField] GameObject actor1, actor2, demolish;
    Image actor1button, actor2button, demolishbutton;

    void Start()
    {
        buildManager = BuildManager.instance;
        //actor1button = actor1.GetComponent<Image>();
        //actor2button = actor2.GetComponent<Image>();
        //demolishbutton = demolish.GetComponent<Image>();
    }

    public void Slot1Building()
    {
        Debug.Log("Sphere selected!");
        buildManager.setBuildingChoice(buildManager.Building1);
        buildManager.BuildingType("Building1");
        //actor1button.color = Color.green;
        //actor2button.color = Color.white;
        //demolishbutton.color = Color.black;
    }

    public void Slot2Building()
    {
        Debug.Log("Cube selected!");
        buildManager.setBuildingChoice(buildManager.Building2);
        buildManager.BuildingType("Building2");
        //actor1button.color = Color.white;
        //actor2button.color = Color.green;
        //demolishbutton.color = Color.black;

    }

    public void DemolishBuilding()
    {
        Debug.Log("Demolish mode!");
        actor1button.color = Color.white;
        actor2button.color = Color.white;
        //demolishbutton.color = Color.red;
    }

  


}
