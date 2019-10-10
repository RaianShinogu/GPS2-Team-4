using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPath : MonoBehaviour
{
    [SerializeField] private int nodePathID = 0;
   
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
    bool leftClickedOn = false;
    bool rightClickedOn = false;
    public bool isTurnPath;
    public int touchCount = 0;



    // Update is called once per frame

    void Start()
    {
        thisObjectsMaterial = this.gameObject.GetComponent<Renderer>().material;
        uiPathManager = transform.parent.GetComponentInParent<UIPathManager>();
        nodePathManager = uiPathManager.nodePathManager.GetComponent<NodePathManager>();
    }

    void Update()
    {
        ExtraUI();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !leftClickedOn)
        {
            touchCount++;
            uiPathManager.pickedNode = this.gameObject;
            uiPathManager.changecolorclick();
            nodePath = this.gameObject.GetComponent<Renderer>().sharedMaterial;
            thisObjectsMaterial.color = Color.gray;
            leftClickedOn = true;
            nodePathManager.pathID = nodePathID;
            activatePathChange = true;

        }
        else if (Input.GetMouseButtonDown(0) && leftClickedOn)
        {
            touchCount++;
            nodePath = null;
            thisObjectsMaterial.color = Color.white;
            leftClickedOn = false;
            nodePathManager.pathID = 0;
                
            
            
        }
        
        

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



  