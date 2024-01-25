using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button levelButton;
    [SerializeField] private Button quitButton;
   
    private const string gameScene = "FirstScene";
    private const string levelScene = "LevelScene";

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(gameScene);
            Time.timeScale = 1f;
        });

        levelButton.onClick.AddListener(() => 
        {
            
            SceneManager.LoadScene(levelScene);

        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
            
        });
    }


 
}
