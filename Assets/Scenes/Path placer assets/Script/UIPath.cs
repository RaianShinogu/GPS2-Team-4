using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPath : MonoBehaviour
{
    private Vector3 mOffset;

    private float mZCoordinate;

    public bool activatePathChange = false;

    Material nodePath;
    Material thisObjectsMaterial;

    Shader shader;
    Texture texture;
    Color color;

    public bool works = false;
    private Vector3 startPosition;
    // Update is called once per frame

    void Start()
    {
        startPosition = transform.position;
        thisObjectsMaterial = this.gameObject.GetComponent<Renderer>().material;
    }

    void Update()
    {

    }

    private void OnMouseDown()
    {
        mZCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();


    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoordinate;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        activatePathChange = true;
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private void OnMouseUp()
    {
        activatePathChange = false;
        //transform.position = startPosition;
       
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Node")
        {           
            if (!activatePathChange)
            {
                //nodePath = collision.gameObject.GetComponent<Renderer>().material;
                //nodePath.shader = thisObjectsMaterial.shader;
                //nodePath.mainTexture = thisObjectsMaterial.mainTexture;
                works = true;
            }
        }
    }
}
