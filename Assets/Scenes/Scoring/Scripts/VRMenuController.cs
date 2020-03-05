using UnityEngine;
using UnityEngine.UI;
using System;
public class VRMenuController : MonoBehaviour
{
    [SerializeField]
    private Text header, body, startText;
    [SerializeField]
    private Button start, finish, exit;
    [SerializeField]
    private Canvas menu;
    private void Start()
    {
        finish.gameObject.SetActive(false);
    }

    public void HideMenu()
    {
        menu.gameObject.SetActive(false);
    }

    public void ShowResults(float[] scores)
    {
        start.gameObject.SetActive(false);
        header.text = "Final Results";
        string result = "";
        float max = 0f;
        int maxIndex = 0;
        for (int i = 0; i < scores.Length; i++)
        {
            result += String.Format("Player {0}: {1,3:F2}% Blocked\n", i + 1, 100 * scores[i]);
            if (scores[i] > max)
            {
                max = scores[i];
                maxIndex = i;
            }
        }
        result += String.Format("\nPlayer {0} Wins!", maxIndex + 1);
        body.text = result;
        finish.gameObject.SetActive(true);
    }
    public void ShowIndividualResults(int playerNumber, int shots, float score)
    {
        menu.gameObject.SetActive(true);
        header.text = "Player " + playerNumber;
        body.text = String.Format("Shots taken: {0}\nShots blocked: {1}\nBlock Percentage: {2,3:F2}%",
                                    shots, (int)(shots * score), 100 * score);
        if (playerNumber >= GameController.instance.numberOfPlayers)
        {
            startText.text = "Results";
        }
        else
        {
            startText.text = "Next Player";
        }
    }
}
