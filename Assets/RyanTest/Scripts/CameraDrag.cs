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
