using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    [SerializeField] private GameObject circleSelector2;
    [SerializeField] private GameObject circleSelector1;
    [SerializeField] private GameObject circleSelector3;

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
    public Text priceText;
    public Text scareText;
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
            circleSelector1.SetActive(false);
            circleSelector2.SetActive(false);
            circleSelector3.SetActive(false);
            upgradeDemolishUI.SetActive(false);
            descriptionPanel.SetActive(false);
        if (inTutorialLevel == true)
        {
            Blink.SetActive(false);
            dialogManager.setActiveOtherNode();
            dialogManager.endSelectBuilding = false;
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
            description.text = "What's in the box? Dare to take a look?";
            priceText.text = "10 gold";
            scareText.text = "10 scares";
            circleSelector1.SetActive(true);
            circleSelector2.SetActive(false);
            circleSelector3.SetActive(false);
            conformSelectBuilding1 = true;
            conformSelectBuilding2 = false;
            conformSelectBuilding3 = false;
            if (inTutorialLevel == true)
            {
                inTutorialLevel = false;
                conformSelectBuilding1 = false;
                conformSelectBuilding2 = false;
                conformSelectBuilding3 = false;
                dialogManager.waveStart = false;
                Debug.Log("Gayy");
            }
            return;
        }
        node.selectedBuilding1();
        
        HideBuildUI();
    }

    public void BuildBuilding2()
    {
        Global.audiomanager.getSFX("InGameClick").play();
        if (!conformSelectBuilding2)
        {
            node.selectedBuilding2Ghost();
            descriptionPanel.SetActive(true);
            description.text = "Something seems to be lurking in the cave's shadows....";
            priceText.text = "20 gold";
            scareText.text = "20 scares";
            circleSelector1.SetActive(false);
            circleSelector2.SetActive(true);
            circleSelector3.SetActive(false);
            conformSelectBuilding1 = false;
            conformSelectBuilding2 = true;
            conformSelectBuilding3 = false;
            if (inTutorialLevel == true)
            {
                inTutorialLevel = false;
                conformSelectBuilding1 = false;
                conformSelectBuilding2 = false;
                conformSelectBuilding3 = false;
                dialogManager.waveStart = false;
                Debug.Log("Gayy");
            }
            return;
        }
        // isOpenBuildingUI = false;
        node.selectedBuilding2();
       
        HideBuildUI();
    }

    public void BuildBuilding3()
    {
        Global.audiomanager.getSFX("InGameClick").play();
        if (!conformSelectBuilding3)
        {
            node.selectedBuilding3Ghost();
            descriptionPanel.SetActive(true);
            description.text = "The moon casts a faint glow on this innocent bush.";
            priceText.text = "30 gold";
            scareText.text = "30 scares";
            circleSelector1.SetActive(false);
            circleSelector2.SetActive(false);
            circleSelector3.SetActive(true);
            conformSelectBuilding1 = false;
            conformSelectBuilding2 = false;
            conformSelectBuilding3 = true;
            if (inTutorialLevel == true)
            {
                inTutorialLevel = false;
                conformSelectBuilding1 = false;
                conformSelectBuilding2 = false;
                conformSelectBuilding3 = false;
                dialogManager.waveStart = false;
                Debug.Log("Gayy");
            }
            return;
        }
        // isOpenBuildingUI = false;
        node.selectedBuilding3();
        

        HideBuildUI();
    }
    public void ShowUpDemUI(Node node, string sellPrice, string upgradePrice)
    {
        if(isOpenBuildingUI == false)
        {
            sellPriceDisplay.text = sellPrice;
            //upgradePriceDisplay.text = upgradePrice;
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
