using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAnimation : MonoBehaviour
{
    
    public Animator building;
    public static BuildingAnimation instance;
    private void Awake()
    {
        instance = this;
    }
    public void playTap(string name)
    {
        building.Play(name, 0, 0.25f);
    }

    public void OnMouseDown()
    {
        building.Play("Tap", 0, 0.25f);
    }

}
