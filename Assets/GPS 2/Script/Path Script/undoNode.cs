using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class undoNode : MonoBehaviour
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


    public void undoOne()
    {
        nodePathChange.undo();
        Instruction.SetActive(true);
        gameManager.GetComponent<tutorialManager>().isFirstStep = 2;
    }
    
}
