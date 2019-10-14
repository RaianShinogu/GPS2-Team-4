using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class demolishPath : MonoBehaviour
{
    [SerializeField] private int nodePathID = 0;

    UIPathManager uiPathManager;

    NodePathManager nodePathManager;

    NodePathChange nodePathChange;

    public bool clickedOn = false;

    // Start is called before the first frame update
    void Start()
    {
        uiPathManager = transform.parent.GetComponentInParent<UIPathManager>();
        nodePathManager = uiPathManager.nodePathManager.GetComponent<NodePathManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        if (!clickedOn)
        {
            uiPathManager.pickedNode = this.gameObject;
            uiPathManager.changecolorclick();


            GetComponent<Image>().color = Color.red;
            clickedOn = true;
            nodePathManager.pathID = nodePathID;
            
            // print("works");
        }
        else if (clickedOn)
        {
            GetComponent<Image>().color = Color.white;
            clickedOn = false;
            nodePathManager.pathID = 0;
        }

    }
}
