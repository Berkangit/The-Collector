using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PauseMenuManager : MonoBehaviour
{
   
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
           
                Pause();
            
        });

        resumeButton.onClick.AddListener(() =>
        {

                Resume();
            
        });
    }



    private void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BackToTheMenu()
    {
       
        SceneManager.LoadScene(MAIN_MENU);
        GameManager.gameManagerInstance.gameState = false;
        
      
    }

    public void QuitTheGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
