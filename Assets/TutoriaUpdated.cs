using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutoriaUpdated : MonoBehaviour
{
    public int stage = 1;
    bool isBuild = false;
    public Text textBox;
    public GameObject tapToContinue;
    public GameObject startWave;
    public GameObject blink;
    public GameObject GuyTalking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(stage == 1)
            {
                blink.SetActive(true);
                textBox.text = "Let me help you get a head start on how to build your park! First, tap on a tile next to the path and choose what you want to build. ";
                //stage++;
            }
            else if( stage == 4)
            {
                tapToContinue.SetActive(false);
                textBox.text = "Now just press that button on the bottom right and visitors will come flooding in!";
                startWave.SetActive(true);
            }

            if(stage == 6)
            {
                tapToContinue.SetActive(false);
                GuyTalking.SetActive(false);
            }

            
        }

         if (stage == 2)
        {
            textBox.text = "If you ever make a mistake you can demolish it. Just click on the building then the demolish button. ";
            
        }

         else if(stage == 3)
        {
            textBox.text = "Now that you know what to do, here are some places you can place your buildings on.  ";
            stage = 4;
        }

         else if(stage == 5)
        {
            textBox.text = "The more you scare visitors, the higher your park's rating will go! But visitors will get bored over time if they don't get scared.   ";
            tapToContinue.SetActive(true);
            stage++;
        }

    }

    public void Stage()
    {
        if(isBuild == false)
        {                      
            if (stage == 2)
            {
                
                isBuild = true;
            }
            stage++;
        }
    }

    public void LastDialogue()
    {
        stage = 5;
    }

    public void SkipTutorial()
    {
        SceneManager.LoadScene("Actual Game Scene", LoadSceneMode.Single);
    }
}
