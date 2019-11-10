using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    public GameObject bottomNode;
    NodePathManager nodePathManager;
    NodePathChange NodePathChange;

    public float distanceToBaseNode;
    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        ray = new Ray(transform.position,-Vector3.up );
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(ray,out hit))
        {
            bottomNode = hit.collider.gameObject;
            nodePathManager = bottomNode.GetComponentInParent<NodePathManager>();
            NodePathChange = bottomNode.GetComponent<NodePathChange>();
        }
    }

    public void OnMouseOver()
    {
        /*if (Input.GetMouseButtonDown(0) && nodePathManager.demolish && NodePathChange.changedPath == true)
        {
            bottomNode.SendMessage("changeBackNode");
            
            Destroy(this.gameObject);
        }
        */
    }
    
}
