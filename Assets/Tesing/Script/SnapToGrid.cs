﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnapToGrid : MonoBehaviour
{
    public float grid = 6.65f;
    float x = 0f, y = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(grid > 0)
        {
            float reciprocalGrid = 1f / grid;
            x = Mathf.Round(transform.position.x * reciprocalGrid) / reciprocalGrid;
            y = Mathf.Round(transform.position.y * reciprocalGrid) / reciprocalGrid;

            transform.position = new Vector3 (x, transform.position.y, y);
        }
    }
}
