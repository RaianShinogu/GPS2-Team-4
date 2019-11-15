using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject star1, star2, star3;

    public static bool gameEnded = false;
    public int oneStar = 0, twoStar = 10, threeStar = 20;
    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
            return;
        if(EnemyRyan.finalDeath == true)
        {
            EndGame();
        }
        
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
}
