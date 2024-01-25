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
    public Button nextButton;


    public static GameOverManager Instance { get; private set; }

    
    private const string MENU_SCENE = "MainMenu";

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerScript.OnGameFinished += PlayerScript_OnGameFinished;
    }

    private void PlayerScript_OnGameFinished(object sender, System.EventArgs e)
    {
        if (playerScript.isFinishLineTouched)
        {
            goldAmountText.text = PlayerPrefs.GetInt("HighGold").ToString();
        }
        GameOver();
        
    }

    public void RestartTheGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(MENU_SCENE);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }
}
