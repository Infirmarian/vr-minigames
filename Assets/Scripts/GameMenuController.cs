using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject splashMenu;
    public enum Games
    {
        SOCCER_GOALIE,
        NOSE_POP
    }
    public void StartMinigame(String title)
    {
        Debug.Log("Starting minigame "+title);
    }
    public void ShowSelectMenu(){
        splashMenu.SetActive(false);
    }
}