using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeRotationIcon : MonoBehaviour
{
    UIPath buttonUIScript;
    float thisRotation = 0f;
    float takeRotation = 0f;
    private int takePathID = 0;
    public int thisNodePathID;
    rotationPanelPopUp panelPopUp;
    GameObject referenceButtonUI;

    private void Start()
    {
        thisRotation = this.transform.rotation.eulerAngles.z;
        panelPopUp = gameObject.GetComponentInParent<rotationPanelPopUp>();
        buttonUIScript = panelPopUp.buttonUI.GetComponent<UIPath>();
        referenceButtonUI = panelPopUp.buttonUI;

    }

    public void OnMouseOver()
    {
            takeRotation = referenceButtonUI.transform.rotation.eulerAngles.z;
            takePathID = buttonUIScript.nodePathID;

            referenceButtonUI.transform.rotation = Quaternion.Euler(0f,0f,thisRotation);
            buttonUIScript.nodePathID = thisNodePathID;

            thisRotation = takeRotation;
            transform.rotation = Quaternion.Euler(0f, 0f, thisRotation);
            thisNodePathID = takePathID;
        
            panelPopUp.activePanel();
        buttonUIScript.GetButtonActive(); 

    }
}
