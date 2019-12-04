using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int spookPoint;
    public static int losePoint;
    public int startSpook = 0;
    public int startlosePoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        spookPoint = startSpook;
        losePoint = startlosePoint;
    }

    
}
