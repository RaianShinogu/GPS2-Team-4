using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    [SerializeField] private Vector3 positionOffset;

    private GameObject building;
    
    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
       rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if(building != null)
        {
            // if there is already a building on it
            return;
        }

        GameObject buildingChoice = BuildManager.instance.getBuildingChoice();

        building = (GameObject)Instantiate(buildingChoice, transform.position + positionOffset, transform.rotation);
    }
}
