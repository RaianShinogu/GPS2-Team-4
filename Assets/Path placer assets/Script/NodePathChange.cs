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
    bool isPathStage = true;
     public bool allowPath = false;
    UIPath uiPath;



    /*void Update()
    {

        RaycastHit backHit;
        RaycastHit leftHit;
        RaycastHit rightHit;
        RaycastHit forwardHit;
        Debug.DrawRay(transform.position + Vector3.up, transform.TransformDirection(Vector3.back) * 1.5f, Color.red); //(back of the object)
        Debug.DrawRay(transform.position + Vector3.up, transform.TransformDirection(Vector3.left) * 1.5f, Color.red); //(left of the object)
        Debug.DrawRay(transform.position + Vector3.up, transform.TransformDirection(Vector3.right) * 1.5f, Color.red);//(right of the object)
        Debug.DrawRay(transform.position + Vector3.up, transform.TransformDirection(Vector3.forward) * 1.5f, Color.red);//(forward of the object)
        
        // X axis path
        if(nodePathManager.pathID != 2)
        {
            allowPath = false;
        }
        if (Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.left), out leftHit, 1.5f) )
        {
            
            if (leftHit.transform.CompareTag("Enemy"))
            {
                //Debug.Log("Hello");
                if(nodePathManager.pathID == 2)
                {
                    allowPath = true;
                }
               
                
            }
        }

        else if (Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.right), out rightHit, 1.5f))
        {

            if (rightHit.transform.CompareTag("Enemy"))
            {
                //Debug.Log("Hello");
                //if(nodePathManager.pathID == 2)
                //{
                allowPath = true;
                //}


            }
        }






    }*/
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
            //if(allowPath == true)
            //{
                if (nodePathManager.pathID > 3)
                {
                    Instantiate(nodePathManager.currentPathChose, instantiatePos, Quaternion.Euler(new Vector3(0, 180, 0)));
                    changedPath = true;
                }
                else

                    Instantiate(nodePathManager.currentPathChose, instantiatePos, Quaternion.identity);
                changedPath = true;
           //}
                
       }
            
       
    }

    public void EndStage()
    {
        isPathStage = false;
    }

    
   
}
