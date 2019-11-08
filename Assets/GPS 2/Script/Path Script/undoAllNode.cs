﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class undoAllNode : MonoBehaviour
{
    UIPathManager uiPathManager;
    NodePathManager nodePathManager;
    NodePathChange nodePathChange;
    public GameObject gameManager;
    public GameObject Instruction;

    private void Start()
    {
        uiPathManager = transform.parent.GetComponentInParent<UIPathManager>();
        nodePathManager = uiPathManager.nodePathManager.GetComponent<NodePathManager>();
        nodePathChange = nodePathManager.GetComponentInChildren<NodePathChange>();
    }


    public void undoAll()
    {
        nodePathChange.undoComplete();
        gameManager.GetComponent<tutorialManager>().undoTutorial = 2;
        Instruction.SetActive(true);
    }
}