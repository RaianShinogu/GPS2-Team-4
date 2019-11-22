using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    Node prevNode;
    public GameObject buildUI;
    public GameObject upgradeDemolishUI;
    public static NodeUI instance;
    [SerializeField] private bool isOpenBuildingUI;
    bool isTutorial = false;
    public GameObject Blink;
    public bool inTutorialLevel;
    [SerializeField] private Vector3 uiOffset;
    bool conformSelectBuilding1 = false;
    bool conformSelectBuilding2 = false;
    bool conformSelectBuilding3 = false;
    Node node;
    public Text description;
    public GameObject descriptionPanel;
    public Text sellPriceDisplay;
    public Text upgradePriceDisplay;

    void Awake()
    {
        if (instance != null)
        {
            // if there is already an instance of NodeUI
            return;
        }
        instance = this;
    }

    private void Start()
    {
        isOpenBuildingUI = false;
        this.prevNode = null;
        
    }
    public void ShowBuildUI(Node node)
    {
            if(isOpenBuildingUI == false)
        {
            isOpenBuildingUI = true;
            //buildUI.SetActive(false);   // reset any opened UI, if any
            buildUI.SetActive(true);
            buildUI.transform.position = node.transform.position + uiOffset;
            if (inTutorialLevel == true)
            {
                if (node.name == "Node (116)")
                {
                    Destroy(Blink);
                    isTutorial = true;
                }
            }
            this.node = node;
            upgradeDemolishUI.SetActive(false);
        }
            
  
        
        
        if (this.prevNode != node)
        {
            //! reset prev node stuff here            
            prevNode = FindObjectOfType<Node>();
            prevNode.DestroyGhosh();
            this.prevNode = node;
            //Debug.Log("prevNode" + this.prevNode);
        }
        else if (prevNode == null)
        {
            this.prevNode = node;
        }

        
        //Debug.Log("Node" + node);
        //Debug.Log("this.Node" + this.node);
        conformSelectBuilding1 = false;
        conformSelectBuilding2 = false;
        conformSelectBuilding3 = false;


    }

    public void HideBuildUI()
    {
        buildUI.SetActive(false);
        isOpenBuildingUI = false;
        prevNode = null;
    }

    public void BuildBuilding1()
    {
       // isOpenBuildingUI = false;
       if(!conformSelectBuilding1)
        {
           node.selectedBuilding1Ghosh();
            descriptionPanel.SetActive(true);
            description.text = "Building 1";
            conformSelectBuilding1 = true;
            conformSelectBuilding2 = false;
            conformSelectBuilding3 = false;
           return;
        }
        node.selectedBuilding1();
        if (inTutorialLevel == true)
        {
            if (isTutorial == true)
            {
                //tutorialUI.SetActive(false);
                //tutorialVistor.SetActive(true);
                //wave.SetActive(true);
                isTutorial = false;
                inTutorialLevel = false;
                conformSelectBuilding1 = false;
                conformSelectBuilding2 = false;
                conformSelectBuilding3 = false;


            }
        }
        HideBuildUI();
    }

    public void BuildBuilding2()
    {
        if (!conformSelectBuilding2)
        {
            node.selectedBuilding2Ghosh();
            descriptionPanel.SetActive(true);
            description.text = "Building 2";
            conformSelectBuilding1 = false;
            conformSelectBuilding2 = true;
            conformSelectBuilding3 = false;
            return;
        }
        // isOpenBuildingUI = false;
        node.selectedBuilding2();
        if (inTutorialLevel == true)
        {
            if (isTutorial == true)
            {
                //tutorialUI.SetActive(false);
                //tutorialVistor.SetActive(true);
                //wave.SetActive(true);
                isTutorial = false;
                inTutorialLevel = false;
                conformSelectBuilding1 = false;
                conformSelectBuilding2 = false;
                conformSelectBuilding3 = false;
            }
        }
        HideBuildUI();
    }

    public void BuildBuilding3()
    {
        if (!conformSelectBuilding3)
        {
            node.selectedBuilding3Ghosh();
            descriptionPanel.SetActive(true);
            description.text = "Building 3";
            conformSelectBuilding1 = false;
            conformSelectBuilding2 = false;
            conformSelectBuilding3 = true;
            return;
        }
        // isOpenBuildingUI = false;
        node.selectedBuilding3();
        if (inTutorialLevel == true)
        {
            if (isTutorial == true)
            {
                //tutorialUI.SetActive(false);
                //tutorialVistor.SetActive(true);
                //wave.SetActive(true);
                isTutorial = false;
                inTutorialLevel = false;
                conformSelectBuilding1 = false;
                conformSelectBuilding2 = false;
                conformSelectBuilding3 = false;
            }
        }

        HideBuildUI();
    }
    public void ShowUpDemUI(Node node, string sellPrice, string upgradePrice)
    {
        if(isOpenBuildingUI == false)
        {
            sellPriceDisplay.text = sellPrice;
            upgradePriceDisplay.text = upgradePrice;
            upgradeDemolishUI.SetActive(false); // reset any opened UI, if any
            upgradeDemolishUI.SetActive(true);
            upgradeDemolishUI.transform.position = node.transform.position + uiOffset;
            this.node = node;
            buildUI.SetActive(false);
            isTutorial = false;
            isOpenBuildingUI = true;
        }
       
    }

    public void HideUpDemUI()
    {
        upgradeDemolishUI.SetActive(false);
        isOpenBuildingUI = false;
    }

    public void Demolish()
    {
        node.Demolish();
        HideUpDemUI();
        isOpenBuildingUI = false;
    }

    public void Upgrade()
    {
        node.Upgrade();
        HideUpDemUI();
        isOpenBuildingUI = false;
    }

    

}
