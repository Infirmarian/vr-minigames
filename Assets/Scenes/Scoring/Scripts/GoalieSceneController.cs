using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoalieSceneController : MonoBehaviour
{
    [SerializeField]
    private int timeLimit = 60;
    [SerializeField]
    public int goals = 0;
    [SerializeField]
    private Text UIScore, VRScore, timer;
    [SerializeField]
    private GameObject instructions, gamecast;
    [SerializeField]
    private FireSphere launcher;
    private float endTime;
    private bool ended = false;
    private int player = 0;
    void Start()
    {
        StartRound();
    }

    public void StartRound()
    {
        instructions.SetActive(false);
        gamecast.SetActive(true);
        endTime = Time.time + timeLimit;
        ended = false;
        launcher.StartFiring();
    }

    void EndRound()
    {
        Debug.Log("Round Ended");
        launcher.StopFiring();
        ended = true;
        if (player < GameController.instance.numberOfPlayers - 1)
        {
            goals = 0;
            player++;
        }
        else
        {
            Debug.Log("All players are done");
            // TODO: Show results somehow and exit to menu
        }
    }

    // Update is called once per frame
    void Update()
    {
        UIScore.text = "Goals Missed: " + goals;
        VRScore.text = "Goals Missed: " + goals;
        timer.text = ((int)Mathf.Max(0, endTime - Time.time)).ToString();
        if (Time.time > endTime)
        {
            EndRound();
        }
    }
}
