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
    public DialogManager dialogManager;
    void Awake()
    {
        if (instance != null)
        {
            // if there is already an instance of NodeUI
            return;
        }
        instance = this;
    }

    void Start()
    {
        isOpenBuildingUI = false;
        this.prevNode = null;
        dialogManager = FindObjectOfType<DialogManager>();
        
    }
    public void ShowBuildUI(Node node)
    {
            //if(isOpenBuildingUI == false)
        //{
            //isOpenBuildingUI = true;
            buildUI.SetActive(false);   // reset any opened UI, if any
            buildUI.SetActive(true);
            buildUI.transform.position = node.transform.position + uiOffset;
            this.node = node;
            upgradeDemolishUI.SetActive(false);
        if(inTutorialLevel == true)
        {
            Blink.SetActive(false);
            inTutorialLevel = false;
            dialogManager.setActiveOtherNode();
        }
        //}
            
  
        
        
        if (this.prevNode != node)
        {
            //! reset prev node stuff here            
            //prevNode = FindObjectOfType<Node>();
            //prevNode.DestroyGhosh();
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
        Global.audiomanager.getSFX("InGameClick").play();
        buildUI.SetActive(false);
        isOpenBuildingUI = false;
        prevNode = null;
    }

    public void BuildBuilding1()
    {
        Global.audiomanager.getSFX("InGameClick").play();
        // isOpenBuildingUI = false;
        if (!conformSelectBuilding1)
        {
           node.selectedBuilding1Ghost();
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
        Global.audiomanager.getSFX("InGameClick").play();
        if (!conformSelectBuilding2)
        {
            node.selectedBuilding2Ghost();
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
        Global.audiomanager.getSFX("InGameClick").play();
        if (!conformSelectBuilding3)
        {
            node.selectedBuilding3Ghost();
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

    public void ResetConfirmation() // to turn off opened description box and reset confirmation
    {
        descriptionPanel.SetActive(false);
        conformSelectBuilding1 = false;
        conformSelectBuilding2 = false;
        conformSelectBuilding3 = false;
    }

}
