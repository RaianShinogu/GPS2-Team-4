using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    [SerializeField] bool simulateMouse = false;
    [SerializeField] float dragSensitivity = 50f;
    Vector3 dragDirection = Vector3.zero; //The direction of our drag input
    float decayRate = 5f;
    private float maxZ = -5.0f;
    private float mixZ = -19.52f;

    private float maxX = 15.8f;
    private float mixX = 4.34f;

    public bool cameraLimit;
    Vector3 lastMousePosition = Vector3.zero;
    Vector3 mouseDelta = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
       
        if (simulateMouse) DragWithMouse();
        else DragWithTouch();

        MoveByDragDirection();
    }

    private void MoveByDragDirection()
    {
        Vector3 remappedDirection = Vector3.zero;
        remappedDirection.x = dragDirection.x;
        remappedDirection.z = dragDirection.y;

       // remappedDirection.x = Mathf.Clamp(dragDirection.x, mixX, maxX);
       // remappedDirection.z = Mathf.Clamp(dragDirection.y, mixZ, maxZ);
        Vector3 initPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if(cameraLimit == true)
        {
            if (remappedDirection.x >= maxX)
            {
                this.transform.position = new Vector3(maxX, initPosition.y, initPosition.z);

            }
            /*else if (remappedDirection.x <= mixX)
            {
                this.transform.position = new Vector3(mixX, initPosition.y, initPosition.z);
            }
            else if (remappedDirection.z >= maxZ)
            {
                this.transform.position = new Vector3(initPosition.x, initPosition.y, maxZ);
            }
            else if (remappedDirection.z <= mixZ)
            {
                this.transform.position = new Vector3(initPosition.x, initPosition.y, mixZ);
            }*/
        }
        
        transform.Translate(remappedDirection * Time.deltaTime * dragSensitivity, Space.World);

        dragDirection = Vector3.Lerp(dragDirection, Vector3.zero, Time.deltaTime * decayRate);
    }

    private void DragWithTouch()
    {
        if (Input.touchCount > 0)
        {
            
           //dragDirection.x = Input.GetTouch(0).deltaPosition.x / (float)-Screen.width;
           //dragDirection.y = Input.GetTouch(0).deltaPosition.y / (float)-Screen.height;
           Vector3 touchPosition = Input.GetTouch(0).position;
            touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);
           if(touchPosition.x < mixX )
            {
                dragDirection.x = 0;
                this.transform.position = new Vector3 (transform.position.x + 0.01f, transform.position.y, transform.position.z);
            }
            else if (touchPosition.x > maxX)
            {
                dragDirection.x = 0;
                this.transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
            }
            else
            {
                dragDirection.x = Input.GetTouch(0).deltaPosition.x / (float)-Screen.width;
            }

            if (touchPosition.z < mixZ)
            {
                dragDirection.y = 0;
                this.transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z + 0.01f);
            }
            else if (touchPosition.z > maxZ)
            {
                dragDirection.y = 0;
                this.transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z - 0.01f);
            }

            else
            {
                dragDirection.y = Input.GetTouch(0).deltaPosition.y / (float)-Screen.height;
            }


        }
    }

    private void DragWithMouse()
    {
        //Resets input reference point for delta calculation
        if (Input.GetMouseButtonDown(0))
            lastMousePosition = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            //dragDirection = Input.mousePosition - lastMousePosition;
            dragDirection =  lastMousePosition - Input.mousePosition;

            dragDirection.x /= (float)Screen.width;
            dragDirection.y /= (float)Screen.height;

            //dragDirection = dragDirection.normalized;
            lastMousePosition = Input.mousePosition;

            //dragDirection.x = Input.GetAxis("Mouse X");
            //dragDirection.y = Input.GetAxis("Mouse Y");

        }

    }
}
