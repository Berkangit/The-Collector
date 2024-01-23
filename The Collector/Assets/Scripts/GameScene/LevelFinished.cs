using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinished : MonoBehaviour
{
    public void FirstLevelFinished()
    {
        LevelManager.secondScene = true;
        SceneManager.LoadScene("LevelScene");
    }
    public void SecondLevelFinished()
    {
        LevelManager.thirdScene = true;
        SceneManager.LoadScene("LevelScene");
    }
    public void ThirdLevelFinished()
    {
        LevelManager.fourthScene = true;
        SceneManager.LoadScene("LevelScene");
    }

    public void FourthLevelFinished()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
