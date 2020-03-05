using UnityEngine;
using System.Collections.Generic;
public abstract class MinigameController : MonoBehaviour
{
    [SerializeField]
    protected int timeLimit;
    protected int currentPlayer;
    protected List<int> scores = new List<int>();
    public abstract void StartRound();
    public abstract void EndRound();
    public abstract void ResetScene();
}