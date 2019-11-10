using UnityEngine;
using UnityEngine.UI;

public class SpookLevelUI : MonoBehaviour
{
    public Text spookLvlText;

    // Update is called once per frame
    void Update()
    {
        spookLvlText.text = "Profit: " + PlayerStats.spookPoint.ToString();
    }
}
