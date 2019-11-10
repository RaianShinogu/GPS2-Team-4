using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class flashingText : MonoBehaviour
{
    public float timer;
    
    void Update()
    {
        timer += Time.deltaTime;

        if(timer>= 0.5)
        {
            GetComponent<Text>().enabled = true;
        }

        if(timer>= 1)
        {
            GetComponent<Text>().enabled = false;
            timer = 0;
        }
    }
}
