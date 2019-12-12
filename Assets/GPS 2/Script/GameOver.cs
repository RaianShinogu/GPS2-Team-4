using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Retry()
    {
        Global.audiomanager.getSFX("InGameClick").play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Global.audiomanager.getSFX("InGameClick").play();
        Time.timeScale = 1f;
        Debug.Log("Go to menu");
        SceneManager.LoadScene(0);
    }

    public void Next()
    {
        Global.audiomanager.getSFX("InGameClick").play();
        Debug.Log("Go next level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
