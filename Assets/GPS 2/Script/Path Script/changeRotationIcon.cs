using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeRotationIcon : MonoBehaviour
{
    UIPath buttonUIScript;
   // float thisRotation = 0f;
   // float takeRotation = 0f;
    private int takePathID = 0;
    public int thisNodePathID;
    rotationPanelPopUp panelPopUp;
    GameObject referenceButtonUI;
    public Sprite thisSprite,takeSprite;

    private void Start()
    {
        //thisRotation = this.transform.rotation.eulerAngles.z;     
        
        panelPopUp = gameObject.GetComponentInParent<rotationPanelPopUp>();
        buttonUIScript = panelPopUp.buttonUI.GetComponent<UIPath>();
        referenceButtonUI = panelPopUp.buttonUI;
    }

    public void OnMouseOver()
    {
        thisSprite = this.GetComponent<Image>().sprite;
        takeSprite = referenceButtonUI.GetComponent<Button>().GetComponent<Image>().sprite;
            //takeRotation = referenceButtonUI.transform.rotation.eulerAngles.z;
            //buttonSprite = referenceButtonUI.GetComponent<Button>().GetComponent<Image>().sprite;
           // takePathID = buttonUIScript.nodePathID;

            //referenceButtonUI.transform.rotation = Quaternion.Euler(0f,0f,thisRotation);
            referenceButtonUI.GetComponent<Button>().GetComponent<Image>().sprite = thisSprite;
            buttonUIScript.nodePathID = thisNodePathID;


        //thisRotation = takeRotation;
        // transform.rotation = Quaternion.Euler(0f, 0f, thisRotation);
            this.GetComponent<Image>().sprite = takeSprite;
            thisNodePathID = takePathID;
        
            panelPopUp.activePanel();
            buttonUIScript.GetButtonActive(); 

    }
}
