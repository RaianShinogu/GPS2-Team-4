using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int spookPoint;
    public static int losePoint;
    public int startSpook = 0;
    public int startlosePoint = 0;
    public Text textUI;

    // Start is called before the first frame update
    void Start()
    {
        spookPoint = startSpook;
        losePoint = startlosePoint;
    }

    void Update()
    {
        textUI.text = losePoint.ToString();
    }

    
}
