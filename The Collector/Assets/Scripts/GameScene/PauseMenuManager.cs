using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class PauseMenuManager : MonoBehaviour
{
   
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private GameObject pauseMenuUI;

    private const string MAIN_MENU = "MainMenu";
 
    private void Awake()
    {
        pauseButton.onClick.AddListener(() =>
        {

            Pause();

        });

        soundButton.onClick.AddListener(() =>
        {
            SoundManager.instance.ChangeVolume();
            soundEffectsText.text = "SOUND : " + Mathf.Round(SoundManager.instance.GetVolume() * 10f);
        });

        resumeButton.onClick.AddListener(() =>
        {

            Resume();

        });

    }


    private void Start()
    {
        soundEffectsText.text = "SOUND : " + Mathf.Round(SoundManager.instance.GetVolume() * 10f);
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
