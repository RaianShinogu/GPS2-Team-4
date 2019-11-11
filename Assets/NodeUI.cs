using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject buildUI;
    public GameObject upgradeDemolishUI;
    public static NodeUI instance;
    [SerializeField] private bool isOpenBuildingUI;
    bool isTutorial = false;
    public GameObject Blink;
    public bool inTutorialLevel;
    [SerializeField] private Vector3 uiOffset;
    Node node;

    public Text sellPriceDisplay;

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
        
    }

    public void HideBuildUI()
    {
        buildUI.SetActive(false);
        isOpenBuildingUI = false;
    }

    public void BuildBuilding1()
    {
       // isOpenBuildingUI = false;
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
                
            }
        }
        HideBuildUI();
    }

    public void BuildBuilding2()
    {
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
                
            }
        }
        HideBuildUI();
    }

    public void BuildBuilding3()
    {
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
            }
        }

        HideBuildUI();
    }
    public void ShowUpDemUI(Node node, string sellPrice)
    {
        if(isOpenBuildingUI == false)
        {
            sellPriceDisplay.text = sellPrice;
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

}
