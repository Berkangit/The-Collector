using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TMP_Text goldAmountText;
    [SerializeField] private PlayerScript playerScript;

    private void Update()
    {
        if(playerScript.isFinishLineTouched || playerScript.isPlayerDead)
        {
            GameOver();
        }
    }



    private const string GAME_SCENE = "GameScene";
    private const string MENU_SCENE = "MainMenu";




    public void RestartTheGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(MENU_SCENE);
    }

    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


    public void GameOver()
    {
        this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }
}
