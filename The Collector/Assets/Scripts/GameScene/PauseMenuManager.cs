using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameObject pauseMenuUI;

    private const string MAIN_MENU = "MainMenu";
    private void Update()
    {
       
        pauseButton.onClick.AddListener(() =>
        {
            if(!GameIsPaused)
                Pause();
            
        });

        resumeButton.onClick.AddListener(() =>
        {
            if (GameIsPaused)
            {
                Resume();
            }
        });

        menuButton.onClick.AddListener(() =>
        {
           BackToTheMenu();
        });

        quitButton.onClick.AddListener(() =>
        {
            if(GameIsPaused)
            {
                QuitTheGame();
            }
           
        });
    }



    private void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    private void BackToTheMenu()
    {
        SceneManager.LoadScene(MAIN_MENU);
    }

    private void QuitTheGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
