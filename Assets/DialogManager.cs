using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string Explaination;
    public string BuildingUI;
    public string BuildingExplaination;
    public string ChoosingBuilding;
    public string Wave;
    public string Demolish;
    public string Ending;

    public float countDown;
    public Text IntrotextBox;
    public Text textBox;
    public Text bottomRight;
    public Text bottomMiddle;
    public Text Tapin;
    public Color color;
    public GameObject otherNodes;
    public GameObject tapContinue;
    public GameObject tutorialCanvas;
    public GameObject buildingTutorialCanvas;
    public GameObject blink;
    public GameObject blinkCanvas;
    public GameObject node;
    public GameObject BottomRight;
    public GameObject MiddleBottom;
    public GameObject TapIn;
    public GameObject WaveButton;

    
    bool endIntro;
    bool endBuildingUI;
    bool ending;
    bool endTutorial;
    public bool endSelectBuilding;
    public bool waveStart;
    public bool buildingDemolish;
    public Blink blinkObject;
    void Start()
    {
        endIntro = false;
        endBuildingUI = true;
        endSelectBuilding = true;
        waveStart = true;
        buildingDemolish = true;
        ending = true;
        endTutorial = true;
        IntrotextBox.text = Explaination;
        IntrotextBox.color = color;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (endIntro == false)
            {
                tutorialCanvas.SetActive(false);
                buildingTutorialCanvas.SetActive(true);
                textBox.text = BuildingUI;
                endIntro = true;
                endBuildingUI = false;
            }
            else if (endBuildingUI == false)
            {
                tapContinue.SetActive(false);
                buildingTutorialCanvas.SetActive(false);
                TapIn.SetActive(true);
                Tapin.text = BuildingExplaination;
                blink.SetActive(true);
                blinkObject.active = true;
                blinkCanvas.SetActive(true);
                endBuildingUI = true;
                node.SetActive(true);
            }    
            else if(ending == false)
            {
                buildingTutorialCanvas.SetActive(true);
                MiddleBottom.SetActive(false);
                textBox.text = Ending;
                ending = true;
                endTutorial = false;
            }
            else if(endTutorial == false)
            {
                buildingTutorialCanvas.SetActive(false);
                tapContinue.SetActive(false);
            }
        }

       if (endSelectBuilding == false)
        {
            textBox.text = ChoosingBuilding;
            endSelectBuilding = true;
        }

       else if (waveStart == false)
        {
            BottomRight.SetActive(true);
            TapIn.SetActive(false);
            bottomRight.text = Wave;
            WaveButton.SetActive(true);
            waveStart = true;
        }

       else if(buildingDemolish == false)
        {
            BottomRight.SetActive(false);
            if(countDown <= 0)
            {
                MiddleBottom.SetActive(true);
                bottomMiddle.text = Demolish;
                tapContinue.SetActive(true);
                ending = false;
                buildingDemolish = true;
                return;
            }
            countDown -= Time.deltaTime;
        }
    }

    public void setActiveOtherNode()
    {
        otherNodes.SetActive(true);
    }
}
