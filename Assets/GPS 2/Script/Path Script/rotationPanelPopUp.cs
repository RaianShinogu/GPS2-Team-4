using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationPanelPopUp : MonoBehaviour
{
    public GameObject buttonUI;
    

    public void activePanel()
    {
        if (buttonUI.GetComponent<UIPath>().activatePathChange)
        {
            
            buttonUI.GetComponent<UIPath>().manuelChangeNodeBack();
        }
        reducePanel();
       
    }

    public void reducePanel()
    {
        if (gameObject.activeSelf)
        {

            this.gameObject.SetActive(false);

        }
        else
            this.gameObject.SetActive(true);
     }
}
