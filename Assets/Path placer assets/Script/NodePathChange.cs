using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodePathChange : MonoBehaviour
{

    NodePathManager nodePathManager;
    Vector3 originalPos;
    Vector3 instantiatePos;

    
    private int lastPathID;
    private int MaxCount , CurrentCount;
    
    bool changedPath = false;
    bool isPathStage = true;
    public bool allowPath ;
    public GameObject Counter;
    UIPath uiPath;

    private string VerticalPath = "Vertical Path";
    private string HorizontalPath = "Horizontal Path";
    private string TurnLeftPath = "Turn Left";
    private string TurnRightPath = "Turn Right";
    private string InverseTurnRightPath = "Inverse Turn Right";
    private string InverseTurnLeftPath = "Inverse Turn Left";

    RaycastHit backHit;
    RaycastHit leftHit;
    RaycastHit rightHit;
    RaycastHit forwardHit;

    Renderer renderer;

    void Update()
    {


        //Debug.DrawRay(transform.position + Vector3.up, transform.TransformDirection(Vector3.back) * 1.5f, Color.red); //(back of the object)
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 1.3f, Color.red); //(left of the object)
        //Debug.DrawRay(transform.position , transform.TransformDirection(Vector3.right) * 1.5f, Color.red);//(right of the object)
        //Debug.DrawRay(transform.position + Vector3.up, transform.TransformDirection(Vector3.forward) * 1.3f, Color.red);//(forward of the object)

        // X axis path
        if (nodePathManager.pathID != lastPathID)
        {
            allowPath = false;
        }

        verticalPath();
        horizontalPath();
        rightPath();
        leftPath();
        inverseLeftPath();
        inverseRightPath();

    }
    private void Awake()
    {
        originalPos = this.transform.position;
        instantiatePos = new Vector3(originalPos.x, originalPos.y , originalPos.z);
        nodePathManager = transform.parent.GetComponent<NodePathManager>();

    }

    private void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0) && !changedPath)
        {
            CurrentCount = nodePathManager.count;
            MaxCount = nodePathManager.maxCount;
            Counter.GetComponent<Text>().text = MaxCount - CurrentCount + "/ 25";
            if (allowPath == true)
            {
                Instantiate(nodePathManager.currentPathChose, instantiatePos, Quaternion.identity);
                changedPath = true;
                nodePathManager.Count();
                Destroy(gameObject);
            }  
        }
    }

    public void EndStage()
    {
        isPathStage = false;
    }


    void verticalPath() //Vertical
    {

        if (Physics.Raycast(transform.position , transform.TransformDirection(Vector3.left), out leftHit, 1.3f))
        {

            if (leftHit.transform.CompareTag(VerticalPath) || leftHit.transform.CompareTag("Enemy")
                || leftHit.transform.CompareTag(InverseTurnLeftPath) || leftHit.transform.CompareTag(InverseTurnRightPath))
            {
                if (nodePathManager.pathID == 2)
                {
                    allowPath = true;
                    lastPathID = nodePathManager.pathID;
                }


            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out rightHit, 1.3f))
            {

                if (rightHit.transform.CompareTag(VerticalPath) || rightHit.transform.CompareTag(TurnRightPath)
                    || rightHit.transform.CompareTag(TurnLeftPath))
                {
                    if (nodePathManager.pathID == 2)
                    {
                        allowPath = true;
                        lastPathID = nodePathManager.pathID;
                    }
                }
            }
        }

        /* else if (Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.left), out leftHit, 1.3f))
         {

             if (leftHit.transform.CompareTag(inverseTurnLeftPath))
             {
                 //Debug.Log("Hello");
                 if (nodePathManager.pathID == 2)
                 {
                     allowPath = true;
                     lastPathID = nodePathManager.pathID;
                 }


             }
         }

         else if (Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.left), out leftHit, 1.5f))
         {

             if (leftHit.transform.CompareTag(inverseTurnRIghtPath))
             {
                 //Debug.Log("Hello");
                 if (nodePathManager.pathID == 2)
                 {
                     allowPath = true;
                     lastPathID = nodePathManager.pathID;
                 }


             }
         }*/

        /*else if (Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.right), out rightHit, 1.3f))
        {

            if (rightHit.transform.CompareTag(turnRightPath))
            {
                //Debug.Log("Hello");
                if(nodePathManager.pathID == 2)
                {
                     allowPath = true;
                     lastPathID = nodePathManager.pathID;
                }


            }
        }

        else if (Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.right), out rightHit, 1.3f))
        {

            if (rightHit.transform.CompareTag(turnLeftPath))
            {
                //Debug.Log("Hello");
                if (nodePathManager.pathID == 2)
                {
                    allowPath = true;
                    lastPathID = nodePathManager.pathID;
                }


            }
        }*/
    }
    void horizontalPath() //Horizontal

    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out forwardHit, 1.3f))
        {

            if (forwardHit.transform.CompareTag(HorizontalPath) || forwardHit.transform.CompareTag(TurnRightPath)
                || forwardHit.transform.CompareTag(InverseTurnLeftPath))
            {
                if (nodePathManager.pathID == 1)
                {
                    allowPath = true;
                    lastPathID = nodePathManager.pathID;
                }


            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out backHit, 1.3f))
            {

                if (backHit.transform.CompareTag(HorizontalPath) || backHit.transform.CompareTag(InverseTurnRightPath)
                    || backHit.transform.CompareTag(TurnLeftPath))
                {
                    if (nodePathManager.pathID == 1)
                    {
                        allowPath = true;
                        lastPathID = nodePathManager.pathID;
                    }
                }
            }
        }
    }
    void rightPath()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out leftHit, 1.3f))
        {

            if (leftHit.transform.CompareTag(VerticalPath) || leftHit.transform.CompareTag("Enemy") || leftHit.transform.CompareTag(InverseTurnRightPath) || leftHit.transform.CompareTag(InverseTurnLeftPath))
                
            {
                if (nodePathManager.pathID == 6)
                {
                    allowPath = true;
                    lastPathID = nodePathManager.pathID;
                }


            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out backHit, 1.3f))
            {

                if (backHit.transform.CompareTag(HorizontalPath) || backHit.transform.CompareTag(InverseTurnRightPath) || backHit.transform.CompareTag(TurnLeftPath ))
                {
                    if (nodePathManager.pathID == 6)
                    {
                        allowPath = true;
                        lastPathID = nodePathManager.pathID;
                    }
                }
            }
        }
    }
    void leftPath()
    {
        if (Physics.Raycast(transform.position , transform.TransformDirection(Vector3.left), out leftHit, 1.3f))
        {

            if (leftHit.transform.CompareTag(VerticalPath) || leftHit.transform.CompareTag("Enemy") || leftHit.transform.CompareTag(InverseTurnRightPath) || leftHit.transform.CompareTag(InverseTurnLeftPath))
            {
                if (nodePathManager.pathID == 5)
                {
                    allowPath = true;
                    lastPathID = nodePathManager.pathID;
                }


            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out forwardHit, 1.3f))
            {

                if (forwardHit.transform.CompareTag(HorizontalPath) || forwardHit.transform.CompareTag(InverseTurnLeftPath) || forwardHit.transform.CompareTag(TurnRightPath))
                {
                    if (nodePathManager.pathID == 5)
                    {
                        allowPath = true;
                        lastPathID = nodePathManager.pathID;
                    }
                }
            }
        }
    }
    void inverseLeftPath()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out rightHit, 1.3f))
        {

            if (rightHit.transform.CompareTag(VerticalPath) || rightHit.transform.CompareTag(TurnRightPath) || rightHit.transform.CompareTag(TurnLeftPath))
            {
                if (nodePathManager.pathID == 7)
                {
                    allowPath = true;
                    lastPathID = nodePathManager.pathID;
                }


            }
            else if (Physics.Raycast(transform.position , transform.TransformDirection(Vector3.back), out backHit, 1.3f))
            {

                if (backHit.transform.CompareTag(HorizontalPath) || backHit.transform.CompareTag(TurnLeftPath) || backHit.transform.CompareTag(InverseTurnLeftPath))
                {
                    if (nodePathManager.pathID == 7)
                    {
                        allowPath = true;
                        lastPathID = nodePathManager.pathID;
                    }
                }
            }
        }
    }
    void inverseRightPath()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out rightHit, 1.3f))
        {

            if (rightHit.transform.CompareTag(VerticalPath) || rightHit.transform.CompareTag(TurnLeftPath) || rightHit.transform.CompareTag(TurnRightPath))
            {
                if (nodePathManager.pathID == 8)
                {
                    allowPath = true;
                    lastPathID = nodePathManager.pathID;
                }


            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out forwardHit, 1.3f))
            {

                if (forwardHit.transform.CompareTag(HorizontalPath) || forwardHit.transform.CompareTag(InverseTurnLeftPath) || forwardHit.transform.CompareTag(TurnRightPath))
                {
                    if (nodePathManager.pathID == 8)
                    {
                        allowPath = true;
                        lastPathID = nodePathManager.pathID;
                    }
                }
            }
        }
    }
}