using UnityEngine;
using UnityEngine.UI;

public class SpookLevelUI : MonoBehaviour
{
    public Text spookLvlText;

    // Update is called once per frame
    void Update()
    {
        spookLvlText.text = "(Debug) Spook level: " + PlayerStats.spookPoint.ToString();
    }
}
