using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject buildUI;
    public GameObject upgradeDemolishUI;
    public static NodeUI instance;
    [SerializeField] private Vector3 uiOffset;
    Node node;

    void Awake()
    {
        if (instance != null)
        {
            // if there is already an instance of NodeUI
            return;
        }
        instance = this;
    }

    public void ShowBuildUI(Node node)
    {
        buildUI.SetActive(false);   // reset any opened UI, if any
        buildUI.SetActive(true);
        buildUI.transform.position = node.transform.position + uiOffset;
        this.node = node;
        upgradeDemolishUI.SetActive(false);
    }

    public void HideBuildUI()
    {
        buildUI.SetActive(false);
    }

    public void BuildBuilding1()
    {
        node.selectedBuilding1();
        HideBuildUI();
    }

    public void BuildBuilding2()
    {
        node.selectedBuilding2();
        HideBuildUI();
    }

    public void ShowUpDemUI(Node node)
    {
        upgradeDemolishUI.SetActive(false);
        upgradeDemolishUI.SetActive(true);
        upgradeDemolishUI.transform.position = node.transform.position + uiOffset;
        this.node = node;
        buildUI.SetActive(false);
    }

    public void HideUpDemUI()
    {
        upgradeDemolishUI.SetActive(false);
    }

    public void Demolish()
    {
        node.Demolish();
        HideUpDemUI();
    }

}
