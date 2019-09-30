﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPathManager : MonoBehaviour
{
   public GameObject nodePathManager;

    public GameObject lastNode;
    public GameObject currentNode;
    public GameObject pickedNode;

    void changeColorBackClicked()
    {
        if (lastNode != currentNode)
        {
            
            lastNode.GetComponent<Renderer>().material.color = Color.white;
        }

    }
    public void changecolorclick() {
        if (lastNode == null) lastNode = pickedNode;
        else lastNode = currentNode;

        currentNode = pickedNode;
        changeColorBackClicked();

    }
}
