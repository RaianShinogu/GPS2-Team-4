using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraRaycast : MonoBehaviour
{
    NodeUI nodeUI;
    //int layerMask = 6;
    Ray ray;
    RaycastHit hit;
    public Text test;
    public bool isOnPc;
    void Start()
    {
        nodeUI = NodeUI.instance;

    }


    void Update()
    {
        if(isOnPc != true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Touch touch = Input.GetTouch(0);
                ray = Camera.main.ScreenPointToRay(touch.position);


                //layerMask = ~layerMask;
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    Debug.Log(hit.collider.name);
                    Debug.Log(EventSystem.current.IsPointerOverGameObject());
                    if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                        return;
                    }

                    else if (!hit.collider.CompareTag("Node"))
                    {
                        nodeUI.HideBuildUI();
                        nodeUI.ResetConfirmation();
                        Destroy(Node.ghostContainer);
                        Node.ghostContainer = null;
                        Node.haveGhost = false;
                        nodeUI.HideUpDemUI();
                        //test.text = Input.GetTouch(0).position.ToString();
                    }
                }

                Debug.DrawLine(ray.origin, hit.point, Color.red, 5.0f);
            }
            
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);


                //layerMask = ~layerMask;
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    Debug.Log(hit.collider.name);
                    Debug.Log(EventSystem.current.IsPointerOverGameObject());
                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        return;
                    }

                    else if (!hit.collider.CompareTag("Node"))
                    {
                        nodeUI.HideBuildUI();
                        nodeUI.ResetConfirmation();
                        Destroy(Node.ghostContainer);
                        Node.ghostContainer = null;
                        Node.haveGhost = false;
                        nodeUI.HideUpDemUI();
                        //test.text = Input.GetTouch(0).position.ToString();
                    }
                }

                Debug.DrawLine(ray.origin, hit.point, Color.red, 5.0f);
            }
        }

    }
}
