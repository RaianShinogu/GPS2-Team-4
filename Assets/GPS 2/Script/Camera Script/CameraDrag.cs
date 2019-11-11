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
    private float maxZ = -7.42f;
    private float mixZ = -19.52f;

    private float maxX = 15.62f;
    private float mixX = 5.39f;

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
        Vector3 initPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if(cameraLimit == true)
        {
            if (this.transform.position.x >= maxX)
            {
                this.transform.position = new Vector3(maxX, initPosition.y, initPosition.z);

            }
            else if (this.transform.position.x <= mixX)
            {
                this.transform.position = new Vector3(mixX, initPosition.y, initPosition.z);
            }
            else if (this.transform.position.z >= maxZ)
            {
                this.transform.position = new Vector3(initPosition.x, initPosition.y, maxZ);
            }
            else if (this.transform.position.z <= mixZ)
            {
                this.transform.position = new Vector3(initPosition.x, initPosition.y, mixZ);
            }
        }
        
        transform.Translate(remappedDirection * Time.deltaTime * dragSensitivity, Space.World);

        dragDirection = Vector3.Lerp(dragDirection, Vector3.zero, Time.deltaTime * decayRate);
    }

    private void DragWithTouch()
    {
        if (Input.touchCount > 0)
        {
            dragDirection.x = Input.GetTouch(0).deltaPosition.x / (float)-Screen.width;
            dragDirection.y = Input.GetTouch(0).deltaPosition.y / (float)-Screen.height;
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
