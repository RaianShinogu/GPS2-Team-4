using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildUIManager2: MonoBehaviour
{
    [SerializeField] GameObject Building1;
    [SerializeField] GameObject Building2;
    [SerializeField] Transform node;
    [SerializeField] GameObject UI;
    bool isBuild = false;

    public void Selection1()
    {
        if(isBuild == false)
        {
            Debug.Log("Im gay1");
            Instantiate(Building1, node.position, Quaternion.identity);
            isBuild = true;
            
        }
        
    }

    public void Selection2()
    {
        if(isBuild == false)
        {
            Debug.Log("Im gay2");
            Instantiate(Building2, node.position + Vector3.up*2.0f, Quaternion.identity);
            isBuild = true;
            
        }
       
    }

}
