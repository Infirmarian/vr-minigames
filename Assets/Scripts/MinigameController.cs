using UnityEngine;

public abstract class MinigameController : MonoBehaviour
{
    [SerializeField]
    protected int timeLimit;
    protected int currentPlayer;
    public abstract void StartRound();
    public abstract void EndRound();
    public abstract void ResetScene();
}