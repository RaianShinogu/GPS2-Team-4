using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    BuildManager buildManager;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Vector3 positionOffset;

    private GameObject building;

    private GameObject buildingChoice;

    private string buildingType;

    private Renderer rend;
    private Color startColor;

    private int gold;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    
    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.getBuildingChoice() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }
    

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        buildingChoice = buildManager.getBuildingChoice();
        buildingType = buildManager.type;
        gold = buildManager.gold;

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildingChoice == null)
        {
            return;
        }

        if(building != null)
        {
            // if there is already a building on it
            if (buildingChoice == buildManager.demolish)
            {
                
                Destroy(building);
                building = null;
            }
            return;
        }
        
        if (buildingChoice == buildManager.demolish)
        {
            return;
        }

        if(buildingType == "Building1")
        {
            if(gold>= 10)
            {
                building = (GameObject)Instantiate(buildingChoice, transform.position + positionOffset, transform.rotation);
                buildManager.Building1Cost();
            }
            
 
        }

        else if (buildingType == "Building2")
        {
            if (gold >= 20)
            {
                building = (GameObject)Instantiate(buildingChoice, transform.position + positionOffset, transform.rotation);
                buildManager.Building2Cost();
            }


        }

    }

  
}
