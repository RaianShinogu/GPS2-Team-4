using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI,loseGameUI;
    public GameObject star1, star2, star3;
    public int TotalEnemy;
    [HideInInspector]
    public int enemyLeft;
    public WaveSpawnRyan waveSpawnRyan;

    public int loseAmount = 5;
    public static bool gameEnded = false;
    public int oneStar = 0, twoStar = 10, threeStar = 20;

    bool finalDeath;
    // Update is called once per frame



    private void Start()
    {
        Time.timeScale = 1f;
        gameOverUI.SetActive(false);
        finalDeath = false;
        enemyLeft = TotalEnemy;
    }

    void Update()
    {
        /*if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            test.text = Input.GetTouch(0).position.ToString();
        }*/

        if (gameEnded)
            return;
        if(finalDeath == true)
        {
            EndGame();
        }
        if (PlayerStats.losePoint >= loseAmount)
        {
            loseGame();
        }
        VisitorCounter();
        
    }

    public void playInGameSFX()
    {
        Global.audiomanager.getSFX("InGameClick").play();
    }

    public void loseGame()
    {
        Time.timeScale = 0.0f;
        loseGameUI.SetActive(true);
    }

    public void EndGame()
    {
        //gameEnded = true;
        gameOverUI.SetActive(true);

        if(PlayerStats.spookPoint >= oneStar && PlayerStats.spookPoint < twoStar)
        {
            star1.SetActive(true);
        }
        else if (PlayerStats.spookPoint >= twoStar && PlayerStats.spookPoint < threeStar)
        {
            star1.SetActive(true);
            star2.SetActive(true);
        }
        else if (PlayerStats.spookPoint >= threeStar)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
    }

    public void VisitorCounter()
    {
        if (enemyLeft <= 0)
        {
            finalDeath = true;
            //Debug.Log("Final enemy died");
        }
       
       
        
    }
}
