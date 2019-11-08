using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsPaused == true)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        //temp
        Global.audiomanager.stopAllSFX();
        Global.audiomanager.getBGM("main_menu").stop();
        Global.audiomanager.getBGM("pause_screen").stop();
        Global.audiomanager.getBGM("main_BGM").play();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        //
        //temp audio
        Global.audiomanager.stopAllSFX();
        Global.audiomanager.getBGM("main_menu").stop();
        Global.audiomanager.getBGM("main_BGM").stop();
        Global.audiomanager.getBGM("pause_screen").play();
    }

    public void backToMenu()
    {
        //change this when build complete
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GamePause()
    {
        GameIsPaused = !GameIsPaused;
    }
}
