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
        dialog.text = "Hello";
        
    }
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
            if(stage == 0)
            {
                dialog.text = "First Dialog";
                stage++;
            }

            else if(stage == 1)
            {
                dialog.text = "Second Dialog";
                stage++;
            }

            else if (stage == 2 && isFirstStep == 0)
            {
                dialog.text = "Third Dialog";
                instruction.SetActive(false);
                pathUI.SetActive(true);
            }

            else if(stage == 2 && isFirstStep == 1)
            {
                dialog.text = "Fourth Dialog";                
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
            dialog.text = "Nineth Dialog";
        }

         else if(stage == 6 && startGame == 1)
        {
            dialog.text = "Tenth Dialog";
        }
    }

    public void BuildingStage()
    {
        stage++;
    }
}
