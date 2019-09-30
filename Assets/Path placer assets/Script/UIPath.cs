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

    public bool activatePathChange = false;

    Material nodePath;
    Material thisObjectsMaterial;

    Shader shader;
    Texture texture;
    Color color;
    bool clickedOn = false;



    // Update is called once per frame

    void Start()
    {
        thisObjectsMaterial = this.gameObject.GetComponent<Renderer>().material;
        uiPathManager = transform.parent.GetComponentInParent<UIPathManager>();
        nodePathManager = uiPathManager.nodePathManager.GetComponent<NodePathManager>();
    }

    void Update()
    {

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !clickedOn)
        {
            uiPathManager.pickedNode = this.gameObject;
            uiPathManager.changecolorclick();

            nodePath = this.gameObject.GetComponent<Renderer>().sharedMaterial;
            thisObjectsMaterial.color = Color.gray;
            clickedOn = true;
            nodePathManager.pathID = nodePathID;
            activatePathChange = true;

        }
        else if (Input.GetMouseButtonDown(0) && clickedOn)
        {
            nodePath = null;
            thisObjectsMaterial.color = Color.white;
            clickedOn = false;
            nodePathManager.pathID = 0;
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



  