using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinished : MonoBehaviour
{
    public void FirstLevelFinished()
    {
        LevelManager.secondScene = true;
        PlayerPrefs.SetInt("SecondSceneUnlocked",1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("LevelScene");
    }
    public void SecondLevelFinished()
    {
        LevelManager.thirdScene = true;
        PlayerPrefs.SetInt("ThirdSceneUnlocked",1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("LevelScene");
    }
    public void ThirdLevelFinished()
    {
        LevelManager.fourthScene = true;
        PlayerPrefs.SetInt("FourthSceneUnlocked",1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("LevelScene");
    }

    public void FourthLevelFinished()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
