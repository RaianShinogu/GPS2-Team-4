using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditScript : MonoBehaviour
{
    float countDown;
    public float secondBetween;
    public GameObject thankYouUI;
    public GameObject theTeamUI;
    // Start is called before the first frame update
    void Start()
    {
        thankYouUI.SetActive(true);
        theTeamUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(countDown >= secondBetween)
        {
            thankYouUI.SetActive(false);
            theTeamUI.SetActive(true);
        }

         if(countDown >= secondBetween*2)
        {
            SceneManager.LoadScene("Main Menu");
        }

        countDown += Time.deltaTime;
    }
}
