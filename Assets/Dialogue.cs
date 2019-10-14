using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dialogue : MonoBehaviour
{
    UIPathManager uiPathManager;
    NodePathManager nodePathManager;
    public Text mytext = null;
    public Text GoldText = null;
    public Text spookText = null;
    public GameObject buildmanager;

    // Start is called before the first frame update
    void Start()
    {
        
        uiPathManager = transform.parent.GetComponentInParent<UIPathManager>();
        nodePathManager = uiPathManager.nodePathManager.GetComponent<NodePathManager>();
        mytext.text = (nodePathManager.maxCount-nodePathManager.count).ToString() + "/" + nodePathManager.maxCount.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(GoldText != null) GoldText.text = buildmanager.GetComponent<BuildManager>().gold.ToString();
        if(mytext != null) mytext.text = (nodePathManager.maxCount - nodePathManager.count).ToString() + "/" + nodePathManager.maxCount.ToString();
        if(spookText != null) spookText.text = PlayerStats.spookPoint.ToString();

    }

   
}
