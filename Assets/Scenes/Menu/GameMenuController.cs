using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject splashMenu, selectMenu, settingsMenu;
    [SerializeField]
    private GameObject leftPanel, rightPanel, centerPanel;
    [SerializeField]
    private Text difficultyButton;
    [SerializeField]
    private Color easyColor, mediumColor, hardColor;
    [SerializeField]
    private Text minigameTitle;
    public enum Games
    {
        SOCCER_GOALIE,
        NOSE_POP,
        TEMP
    }
    private string[] games = { "Soccer", "NOSE_POP", "TEMP" };
    private int currentGame = 0;
    private void Start()
    {
        minigameTitle.text = games[currentGame];
        SwitchDifficulty();
        ShowSplashMenu();
    }
    public void StartMinigame()
    {
        Debug.Log("Starting minigame " + games[currentGame]);
        SceneManager.LoadScene(games[currentGame]);
    }
    public void ShowSelectMenu()
    {
        settingsMenu.SetActive(false);
        splashMenu.SetActive(false);
        selectMenu.SetActive(true);
    }
    public void ShowSplashMenu()
    {
        selectMenu.SetActive(false);
        settingsMenu.SetActive(false);
        splashMenu.SetActive(true);
    }
    public void ShowSettingsMenu()
    {
        splashMenu.SetActive(false);
        selectMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void CycleLeft()
    {
        if (currentGame == 0)
            currentGame = games.Length - 1;
        else
            currentGame -= 1;

        minigameTitle.text = games[currentGame];

    }
    public void CycleRight()
    {
        if (currentGame == games.Length - 1)
            currentGame = 0;
        else
            currentGame += 1;
        minigameTitle.text = games[currentGame];

    }

    public void SwitchDifficulty()
    {
        switch (GameController.instance.difficulty)
        {
            case Difficulty.EASY:
                GameController.instance.difficulty = Difficulty.MEDIUM;
                difficultyButton.color = mediumColor;
                difficultyButton.text = "Medium";
                break;
            case Difficulty.MEDIUM:
                GameController.instance.difficulty = Difficulty.HARD;
                difficultyButton.color = hardColor;
                difficultyButton.text = "Hard";
                break;
            case Difficulty.HARD:
                GameController.instance.difficulty = Difficulty.EASY;
                difficultyButton.color = easyColor;
                difficultyButton.text = "Easy";
                break;
            default:
                break;
        }
    }
}