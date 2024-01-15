using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private Button quitButton;

    private const string gameScene = "GameScene";

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(gameScene);
        });
        optionButton.onClick.AddListener(() =>
        {

        });
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
            Debug.Log("Quit");
        });
    }
}
