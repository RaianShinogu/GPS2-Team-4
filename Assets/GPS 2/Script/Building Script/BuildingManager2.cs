using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BuildingManager2 : MonoBehaviour
{
    public GameObject UI;
    public GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();
    static bool isOpen;
    
    WaveSpawnRyan waveSpawn;
    // Use this for initialization
    void Start()
    {
        definedButton = this.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;
        
        if (Input.GetMouseButtonDown(0))
        {
            
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {
                
                if (isOpen == false)
                {
                    Debug.Log("Button Clicked");
                    OnClick.Invoke();
                    isOpen = true;
                }
                
            }
            
        }
    }

    public void CloseUI()
    {
        isOpen = false;
        UI.SetActive(false);
    }

    public void activeUI()
    {
        UI.SetActive(true);
    }
}
