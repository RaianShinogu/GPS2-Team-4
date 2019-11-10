using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class tutorialManager : MonoBehaviour
{
    public Text dialog;
    public GameObject pathUI;
    public GameObject Undo;
    public GameObject UndoAll;
    public GameObject instruction;
    public int isFirstStep;
    public int undoTutorial;
    public int startGame;
    bool isComplete = false;
    int stage = 0;
    
    void Start()
    {
        dialog.text = "Welcome, to your very own haunted theme park!";
        
    }
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
            if(stage == 0)
            {
                dialog.text = "Where everyone's nightmares come true.Scare your visitors to be the spookiest park in town!";
                stage++;
            }

            else if(stage == 1)
            {
                dialog.text = "Let me help you get a head start on how to build your park!";
                stage++;
            }

            else if (stage == 2 && isFirstStep == 0)
            {
                dialog.text = "First, tap on a tile next to the path and choose what you want to build. ";
                instruction.SetActive(false);
                pathUI.SetActive(true);
            }

            else if(stage == 2 && isFirstStep == 1)
            {
                dialog.text = "If you ever make a mistake you can demolish it. Just click on the building then the demolish button. ";                
                Undo.SetActive(true);
                
                
            }

            else if (stage == 2 && isFirstStep == 2)
            {
                dialog.text = "Fifth Dialog";
                instruction.SetActive(false);
                //UndoAll.SetActive(true);
                stage++;

            }

            else if (stage == 3 && undoTutorial == 1)
            {
               
                dialog.text = "Sixth Dialog";
                instruction.SetActive(false);
                UndoAll.SetActive(true);
                isComplete = true;
                stage++;
            }

            else if (stage == 4 && undoTutorial == 2)
            {
                if (isComplete == true)
                {
                    dialog.text = "Seventh Dialog";
                    instruction.SetActive(false);
                }
                              
            }

            
        }
         if (stage == 4 && startGame == 1)
        {
            dialog.text = "Eighth Dialog";
        }

        else if (stage == 5 && startGame == 1)
        {
            dialog.text = "Now that you know what to do, here are some places you can place your buildings on. ";
        }

         else if(stage == 6 && startGame == 1)
        {
            dialog.text = "Now just press that button on the bottom right and visitors will come flooding in! ";
        }
    }

    public void BuildingStage()
    {
        stage++;
    }
}
