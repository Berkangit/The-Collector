using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip[] danceAnimClip;
    [SerializeField] private Button firstLevelButton,secondLevelButton,thirdLevelButton,fourthLevelButton;
    private const string DANCE_INDEX = "DanceIndex";
    private const string DANCE = "Dance";

    public static bool firstScene, secondScene, thirdScene,fourthScene;


    private void Start()
    {
        firstScene = true;
        int randomDanceIndex = Random.Range(0, 3);
        animator.SetInteger(DANCE_INDEX, randomDanceIndex);
        animator.SetTrigger(DANCE);
    }
    private void Update()
    {
        if(secondScene == true)
            secondLevelButton.interactable = true;
        
        if (thirdScene == true)
            thirdLevelButton.interactable = true;

        if (fourthScene == true)
            fourthLevelButton.interactable = true;
    }
    public void BackToMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void LoadFirstScene()
    {
        SceneManager.LoadScene("FirstScene");
    }

    public void LoadSecondScene()
    {
        SceneManager.LoadScene("SecondLevelScene");
    }
    public void LoadThirdScene()
    {
        SceneManager.LoadScene("ThirdLevelScene");
    }
    public void LoadFourthScene()
    {
        SceneManager.LoadScene("FourthLevelScene");

    }

}
