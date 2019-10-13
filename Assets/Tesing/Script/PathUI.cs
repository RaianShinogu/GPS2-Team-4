using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathUI : MonoBehaviour
{
    public GameObject Horizontal;
    public GameObject Vertical;
    public GameObject Plus_Path_Node;
    public GameObject T_Path_Node;
    public GameObject turnRight;
    public GameObject turnLeft;
    public GameObject inverseTurnRight;
    public GameObject inverseTurnLeft;
    public GameObject currentPathChose;
    public GameObject pathUI;
    public GameObject BuildingUI;
    public int maxCount;
    private int count;
    public bool isStage;
    public int pathID;

    public void leftPath()
    {
        currentPathChose = turnLeft;
        pathID = 6;
    }

    public void rightPath()
    {
        currentPathChose = turnRight;
        pathID = 7;
    }

    public void inverseLeftPath()
    {
        currentPathChose = inverseTurnLeft;
        pathID = 8;
    }

    public void inverseRightPath()
    {
        currentPathChose = inverseTurnRight;
    }

    public void horizontal()
    {
        currentPathChose = Horizontal;
        pathID = 1;
    }

    public void vertical()
    {
        currentPathChose = Vertical;
        pathID = 2;
    }

    public void EndStage()
    {

        isStage = false;
        pathUI.SetActive(false);
        BuildingUI.SetActive(true);


    }

    public void Count()
    {
        count++;
    }
}
