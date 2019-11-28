using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        //temp audio
        Global.audiomanager.stopAllSFX();
        Global.audiomanager.getBGM("pause_screen").stop();
        Global.audiomanager.getBGM("main_BGM").stop();
        Global.audiomanager.getBGM("main_menu").play();
        
    }
    public void Play()
    {
        playSFX();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }


    public void Quit()
    {
        playSFX();
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void playSFX()
    {
        Global.audiomanager.getSFX("UIclick").play();
    }
}
