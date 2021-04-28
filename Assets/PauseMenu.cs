using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu Settings")]

    [Tooltip("When game is not paused this will be false therefor the deafult will always be false, if game is paused it should set to true")]
    public static bool GameIsPaused = false;

    [Tooltip("Add the options menu")]
    public GameObject OptionsMenu;
    // Start is called before the first frame update


    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
        OptionsMenu.SetActive(false);
        GameIsPaused = false;
    }
    public void Resume()
    {
        OptionsMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;


    }

    public void Pause()
    {
        OptionsMenu.SetActive(true);
        Time.timeScale = 0F;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("LOADMENU");
        SceneManager.LoadScene("Lukas_Prototype");

    }

    public void Remainpaused()
    {
        Time.timeScale = 0f;
        Debug.Log("Timescale 0");

    }

    

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
