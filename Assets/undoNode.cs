using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoNode : MonoBehaviour
{
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
        
    }
    public void undoAll()
    {
        nodePathChange.undoComplete();
    }
}
