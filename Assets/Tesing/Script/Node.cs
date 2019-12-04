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
    public GameObject descriptionPanel;
    bool isDragging = false;
    private float delayTime = 0.2f;
    private float counterTime = 0.0f;
    string sellPrice;
    string upgradePrice;
    bool canUpgrade;

    [HideInInspector]public GameObject building;
    [HideInInspector] public GameObject buildingGhosh;
    public static bool haveGhost;
    public static GameObject ghostContainer;

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
       // buildingAnimation = BuildingAnimation.instance;
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

        if (haveGhost)
        {
            Destroy(ghostContainer);
            ghostContainer = null;
            haveGhost = false;
            nodeUI.ResetConfirmation();
        }

        //
        if (building != null)
        {
            if(building.tag == buildManager.Building1.tag)
            {
                sellPrice = "$ 5";
                upgradePrice = "$ 15";
            }

            else if (building.tag == buildManager.Building2.tag)
            {
                sellPrice = "$ 7";
                upgradePrice = "$ 29";
            }

            else
            {
                sellPrice = "$ 10";
                upgradePrice = "$ 44";
            }

            if(canUpgrade == false)
            {
                upgradePrice = "N/A";
            }

            nodeUI.ShowUpDemUI(this, sellPrice, upgradePrice);
            
            return;
        }
        nodeUI.ShowBuildUI(this);
       
    }

    void OnMouseDown()
    {

        Global.audiomanager.getSFX("InGameClick").play();
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
            Destroy(buildingGhosh);
            building = (GameObject)Instantiate(buildManager.Building1, transform.position , buildManager.Building1.transform.rotation);
            buildManager.Building1Cost();
            canUpgrade = true;
        }
    }

    public void selectedBuilding1Ghosh()
    {
        Destroy(buildingGhosh);
        buildingGhosh = (GameObject)Instantiate(buildManager.Building1Ghosh, transform.position, buildManager.Building1Ghosh.transform.rotation);
        haveGhost = true;
        ghostContainer = buildingGhosh;
    }

    public void selectedBuilding2()
    {
        if (gold >= 20)
        {
            Destroy(buildingGhosh);
            building = (GameObject)Instantiate(buildManager.Building2, transform.position + positionOffset, buildManager.Building2.transform.rotation);
            buildManager.Building2Cost();
            canUpgrade = true;
        }
    }

    public void selectedBuilding2Ghosh()
    {
        Destroy(buildingGhosh);
        buildingGhosh = (GameObject)Instantiate(buildManager.Building2Ghosh, transform.position, buildManager.Building2Ghosh.transform.rotation);
        haveGhost = true;
        ghostContainer = buildingGhosh;
    }

    public void selectedBuilding3()
    {
        if (gold >= 30)
        {
            Destroy(buildingGhosh);
            building = (GameObject)Instantiate(buildManager.Building3, transform.position , buildManager.Building3.transform.rotation);
            buildManager.Building3Cost();
            canUpgrade = true;
        }
    }

    public void selectedBuilding3Ghosh()
    {
        Destroy(buildingGhosh);
        buildingGhosh = (GameObject)Instantiate(buildManager.Building3Ghosh, transform.position, buildManager.Building3Ghosh.transform.rotation);
        haveGhost = true;
        ghostContainer = buildingGhosh;
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

    public void Upgrade()
    {
        if (canUpgrade)
        {    
            Destroy(building);

            if (building.tag == buildManager.Building1.tag && gold >= 15)
            {
                building = null;
                building = (GameObject)Instantiate(buildManager.UpBuilding1, transform.position + Vector3.down, buildManager.Building1.transform.rotation);
                buildManager.UpgradeBuilding1Cost();            
            }

            if (building.tag == buildManager.Building2.tag && gold >= 29)
            {
                building = null;
                building = (GameObject)Instantiate(buildManager.UpBuilding2, transform.position + Vector3.down, buildManager.Building2.transform.rotation);
                buildManager.UpgradeBuilding2Cost();
            }

            if (building.tag == buildManager.Building3.tag && gold >= 44)
            {
                building = null;
                building = (GameObject)Instantiate(buildManager.UpBuilding3, transform.position + Vector3.down, buildManager.Building3.transform.rotation);
                buildManager.UpgradeBuilding3Cost();
            }
            canUpgrade = false;
        }
    }

    public void DestroyGhosh()
    {
        Destroy(buildingGhosh);
        descriptionPanel.SetActive(false) ;
    }

}
