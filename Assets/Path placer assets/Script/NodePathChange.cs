using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePathChange : MonoBehaviour
{
    
    NodePathManager nodePathManager;
    Vector3 originalPos;
    Vector3 instantiatePos;
   
    public int pathID;
    bool changedPath = false;
    UIPath uiPath;

    private void Awake()
    {
        originalPos = this.transform.position;
        instantiatePos = new Vector3(originalPos.x, originalPos.y + 1.0f, originalPos.z);
        
        nodePathManager = transform.parent.GetComponent<NodePathManager>();
          
    }

    private void OnMouseOver()
    {
       if (Input.GetMouseButtonDown(0) && !changedPath)
       {
            if(nodePathManager.pathID > 3)
            {
                Instantiate(nodePathManager.currentPathChose, instantiatePos, Quaternion.Euler(new Vector3(0,180,0)));
                changedPath = true;
            }
            else

            Instantiate(nodePathManager.currentPathChose, instantiatePos,Quaternion.identity);
            changedPath = true;
       }
    }

   
}
