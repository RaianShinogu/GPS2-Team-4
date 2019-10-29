using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePathManager : MonoBehaviour
{
    //public GameObject[] nodeChange = new GameObject[3];
    public GameObject L_Path_Node;
    public GameObject Minus_Path_Node;
    public GameObject Plus_Path_Node;
    public GameObject T_Path_Node;
    public GameObject turnRight;
    public GameObject turnLeft;
    public GameObject inverseTurnRight;
    public GameObject inverseTurnLeft;
    public GameObject currentPathChose;
    public GameObject PathUI;
    public GameObject BuildingUI;

    public int pathID;
    public int maxCount;
    public int count;
    public bool isStage;

    //
    public GameObject[] madeNodePaths;
    public GameObject[] changedNodePaths;

    public int numberOfPaths = 0;

    private void Awake()
    {
        madeNodePaths = new GameObject[maxCount];
        changedNodePaths = new GameObject[maxCount];
    }

    private void Update()
    {
        choosePath();
    }
    void choosePath()
    {
        if (isStage == true)
        {
            if(count< maxCount)
            {
                if (pathID == 1)
                {
                    currentPathChose = L_Path_Node;
                }
                else if (pathID == 2)
                {
                    currentPathChose = Minus_Path_Node;
                }
                else if (pathID == 3)
                {
                    currentPathChose = Plus_Path_Node;
                }
                else if (pathID == 4)
                {
                    currentPathChose = T_Path_Node;
                }
                else if (pathID == 5)
                {
                    currentPathChose = turnLeft;
                }
                else if (pathID == 6)
                {
                    currentPathChose = turnRight;
                }
                else if (pathID == 7)
                {
                    currentPathChose = inverseTurnLeft;
                }
                else if (pathID == 8)
                {
                    currentPathChose = inverseTurnRight;
                }
                else 
                {
                
                    currentPathChose = null;
                }               
            }   
            else
            {
                currentPathChose = null;
            }
        }
        else { currentPathChose = null; }
       
    }
    
  

    public void EndStage()
    {
        
            isStage = false;
            PathUI.SetActive(false);
            BuildingUI.SetActive(true);
    
        
    }

    public void Count()
    {
        count++;
    }

    
}
