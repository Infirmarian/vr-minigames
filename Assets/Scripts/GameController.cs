using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Signleton
public class GameController : MonoBehaviour
{
    [SerializeField]
    public int numberOfPlayers = 1;
    public Difficulty difficulty;
    Dictionary<GameMenuController.Games, int[]> scores;
    public static GameController instance { get; private set; }
    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void ResetScores()
    {
        scores.Clear();
    }
}


public enum Difficulty
{
    EASY,
    MEDIUM,
    HARD
}