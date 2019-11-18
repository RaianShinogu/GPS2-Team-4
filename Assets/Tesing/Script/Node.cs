using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    BuildManager buildManager;
    NodeUI nodeUI;
    [SerializeField] private Color hoverColor;
    public Vector3 positionOffset;
    bool isDragging = false;
    private float delayTime = 0.2f;
    private float counterTime = 0.0f;
    string sellPrice;

    [HideInInspector]public GameObject building;

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
        nodeUI = NodeUI.instance;
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

    void OnMouseDrag()
    {
        counterTime += Time.deltaTime;
        if(counterTime >= delayTime)
        {
            isDragging = true;
        }

        else
        {            
            isDragging = false;
        }
    }

    void OnMouseUp()
    {
        counterTime = 0.0f;
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (isDragging == true)
        {
            isDragging = false;
            return;
        }
        
        //
        if (building != null)
        {
            if(building.tag == buildManager.Building1.tag)
            {
                sellPrice = "$ 5";
            }

            else if (building.tag == buildManager.Building2.tag)
            {
                sellPrice = "$ 7";
            }

            else
            {
                sellPrice = "$ 10";
            }
            nodeUI.ShowUpDemUI(this, sellPrice);
            return;
        }

        nodeUI.ShowBuildUI(this);
    }

    void OnMouseDown()
    {
        buildingChoice = buildManager.getBuildingChoice();
        buildingType = buildManager.type;
        gold = buildManager.gold;

        /*
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(isDragging)
        {
            isDragging = false;
            return;
        }

        //
        if(building != null)
        {
            nodeUI.ShowUpDemUI(this);
            return;
        }

        nodeUI.ShowBuildUI(this);
        */


        /*
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
        */
    }

    public void selectedBuilding1()
    {
        if (gold >= 10)
        {
            building = (GameObject)Instantiate(buildManager.Building1, transform.position + Vector3.down, buildManager.Building1.transform.rotation);
            buildManager.Building1Cost();
        }
    }

    public void selectedBuilding2()
    {
        if (gold >= 20)
        {
            building = (GameObject)Instantiate(buildManager.Building2, transform.position + positionOffset, buildManager.Building2.transform.rotation);
            buildManager.Building2Cost();
        }
    }

    public void selectedBuilding3()
    {
        if (gold >= 30)
        {
            building = (GameObject)Instantiate(buildManager.Building3, transform.position + Vector3.down/2, buildManager.Building3.transform.rotation);
            buildManager.Building3Cost();
        }
    }

    public void Demolish()
    {
        Destroy(building);

        if (building.tag == buildManager.Building1.tag)
        {
            buildManager.SellBuilding1Gold();
        }

        else if (building.tag == buildManager.Building2.tag)
        {
            buildManager.SellBuilding2Gold();
        }

        else
        {
            buildManager.SellBuilding3Gold();
        }

        building = null;
    }

}
