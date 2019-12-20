using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditScript : MonoBehaviour
{
    float countDown;
    bool hadChange;
    public float secondBetween;
    public GameObject TeamUI;
    public GameObject theTeamUI;
    public GameObject thankYouUI;
    // Start is called before the first frame update
    void Start()
    {
        TeamUI.SetActive(true);
        theTeamUI.SetActive(false);
        thankYouUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(countDown >= secondBetween)
        {
            if(hadChange == false)
            {
                TeamUI.SetActive(false);
                theTeamUI.SetActive(true);
                hadChange = true;
                countDown = 0;
            }

            else
            {
                theTeamUI.SetActive(false);
                thankYouUI.SetActive(true);
            }
            

        }

         if(countDown >= secondBetween*2)
        {
            SceneManager.LoadScene("Main Menu");
        }

        countDown += Time.deltaTime;
    }
}
