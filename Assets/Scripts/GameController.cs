using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Signleton
public class GameController : MonoBehaviour
{
    [SerializeField]
    public int numberOfPlayers = 1;
    Dictionary<GameMenuController.Games, int[]> scores;
    private static GameController instance;
    private void Start()
    {
        if (instance == null) instance = this;
        if (this != instance) Destroy(this);
    }
    public void ResetScores()
    {
        scores.Clear();
    }
}