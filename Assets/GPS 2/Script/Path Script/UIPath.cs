using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPath : MonoBehaviour
{
    public int nodePathID = 0;
   
    UIPathManager uiPathManager;

    NodePathManager nodePathManager;

    NodePathChange nodePathChange;

    public GameObject lastNode;
    public GameObject currentNode;
    public GameObject extraTurnPath;

    public bool activatePathChange = false;

    Material nodePath;
    Material thisObjectsMaterial;

    Shader shader;
    Texture texture;
    Color color;
   [SerializeField] bool leftClickedOn = false;
    bool rightClickedOn = false;
    public bool isTurnPath;
    public int touchCount = 0;
    //
    ColorBlock buttonColor;
    


    // Update is called once per frame

    void Start()
    {
        //thisObjectsMaterial = this.gameObject.GetComponent<Renderer>().material;
        uiPathManager = transform.parent.GetComponentInParent<UIPathManager>();
        nodePathManager = uiPathManager.nodePathManager.GetComponent<NodePathManager>();
    }

    void Update()
    {
        if(isTurnPath)
        {
            ExtraUI();
        }
        
    }

    public void OnMouseOver()
    {
        if (!leftClickedOn)
        {
            ActivateButton();
        }
        else if (leftClickedOn)
        {
            touchCount++;
            nodePath = null;
            GetComponent<Image>().color = Color.white;
            leftClickedOn = false;
            nodePathManager.pathID = 0;
            activatePathChange = false;
            //nodePathManager.demolish = false;


        }



    }

    void ActivateButton()
    {
        touchCount++;
        uiPathManager.pickedNode = this.gameObject;
        uiPathManager.changecolorclick();

        GetComponent<Image>().color = Color.grey;
        // thisObjectsMaterial.color = Color.gray;
        leftClickedOn = true;
        nodePathManager.pathID = nodePathID;
        activatePathChange = true;
        //transform.parent.GetComponentInChildren<rotationPanelPopUp>().reducePanel();
    }

    public void GetButtonActive()
    {
        ActivateButton();
    }
    void ExtraUI()
    {
        if(touchCount == 2)
        {
            extraTurnPath.SetActive(true);
        }

        else if(touchCount ==4)
        {
            extraTurnPath.SetActive(false);
            touchCount = 0;
        }
        
    }

    public void manuelChangeNodeBack()
    {
        nodePath = null;
        GetComponent<Image>().color = Color.white;
        leftClickedOn = false;
        nodePathManager.pathID = 0;
        //nodePathManager.demolish = false;
        activatePathChange = false;
    }

    public void leftClickDeactive()
    {
        leftClickedOn = false;
        activatePathChange = false;
    }
    /* void changeColorBackClicked()
     {
        if (lastNode!= currentNode)
         {
             nodePath = null;
             lastNode.GetComponent<Renderer>().material.color = Color.white;
         }

     }*/

    /* void raycastCameraChangeColor()
     {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;

         if (Physics.Raycast(ray, out hit, 100.0F))
         {
             if (hit.collider.gameObject.name == )
             {
                 changeColorBackClicked();
             }

         }

     }*/



}



  