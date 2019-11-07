using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoNode : MonoBehaviour
{
    public GameObject gameManager;
    UIPathManager uiPathManager;
    NodePathManager nodePathManager;
    NodePathChange nodePathChange;
    
    

    private void Start()
    {
        uiPathManager = transform.parent.GetComponentInParent<UIPathManager>();
        nodePathManager = uiPathManager.nodePathManager.GetComponent<NodePathManager>();
        nodePathChange = nodePathManager.GetComponentInChildren<NodePathChange>();
    }


    public void undoOne()
    {
        nodePathChange.undo();
        gameManager.GetComponent<tutorialManager>().isFirstStep = 2;

    }
    public void undoAll()
    {
        nodePathChange.undoComplete();
        gameManager.GetComponent<tutorialManager>().isFirstStep = 3;
    }
}
