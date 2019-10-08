using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePathManager : MonoBehaviour
{
    //public GameObject[] nodeChange = new GameObject[3];
    public GameObject J_Path_Node;
    public GameObject L_Path_Node;
    public GameObject Minus_Path_Node;
    public GameObject Plus_Path_Node;
    public GameObject T_Path_Node;
    public int pathID;
    public GameObject currentPathChose;
    public bool isStage ;
    public GameObject PathUI;
    public GameObject BuildingUI;
    

    private void Update()
    {
        choosePath();
    }
    void choosePath()
    {
        if (isStage == true)
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
                currentPathChose = J_Path_Node;
            }
            else
                currentPathChose = null;
        }
        else { currentPathChose = null; }

        
        
        
    }

    public void EndStage()
    {
        
            isStage = false;
            PathUI.SetActive(false);
            BuildingUI.SetActive(true);
    
        
    }
    
}
