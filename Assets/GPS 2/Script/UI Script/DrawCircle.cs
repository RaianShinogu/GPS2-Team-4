﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}