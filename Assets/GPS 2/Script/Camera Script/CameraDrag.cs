using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    [SerializeField] bool simulateMouse = false;
    [SerializeField] float dragSensitivity ;
    Vector3 dragDirection = Vector3.zero; //The direction of our drag input
    float decayRate = 5f;
    public float maxZ = -5.0f;
    public float mixZ = -19.52f;

    public float maxX = 64.3f;
    public float mixX = -35.1f;

    bool canDrag = true;
    Vector3 lastMousePosition = Vector3.zero;
    Vector3 mouseDelta = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
       
        if (simulateMouse) DragWithMouse();
        else DragWithTouch();

        //MoveByDragDirection();
    }

    private void MoveByDragDirection()
    {
        Vector3 remappedDirection = Vector3.zero;
        remappedDirection.x = dragDirection.x;
        remappedDirection.z = dragDirection.y;

       // remappedDirection.x = Mathf.Clamp(dragDirection.x, mixX, maxX);
       // remappedDirection.z = Mathf.Clamp(dragDirection.y, mixZ, maxZ);
        Vector3 initPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

       

        transform.Translate(remappedDirection * Time.deltaTime * dragSensitivity, Space.World);
        dragDirection = Vector3.Lerp(dragDirection, Vector3.zero, Time.deltaTime * decayRate);
    }

    private void DragWithTouch()
    {
        
        if (Input.touchCount > 0)
        {
            
           Vector3 touchPosition = Input.GetTouch(0).position;
           touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            dragDirection.x = Input.GetTouch(0).deltaPosition.x / (float)-Screen.width;
            dragDirection.y = Input.GetTouch(0).deltaPosition.y / (float)-Screen.height;
            if (this.transform.position.x < mixX && dragDirection.x < 0)
            {
                dragDirection.x = 0;
            }

            if (this.transform.position.x > maxX && dragDirection.x > 0)
            {
                dragDirection.x = 0;
            }

            if (this.transform.position.z < mixZ && dragDirection.y < 0)
            {
                dragDirection.y = 0;
            }

            if (this.transform.position.z > maxZ && dragDirection.y > 0)
            {
                dragDirection.y  = 0;
            }

            MoveByDragDirection();
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

            MoveByDragDirection();
        }

    }
}
