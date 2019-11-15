using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPopUP : MonoBehaviour
{
    private int totalEnemy = 20;
    public GameObject gameOverUI;
    bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOver == true)
        {
            gameOverUI.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            totalEnemy--;
            if(totalEnemy < 0)
            {
                GameOver = true;
            }
        }
    }
}
