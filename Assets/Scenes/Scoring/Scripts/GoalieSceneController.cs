using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
public class GoalieSceneController : MinigameController
{
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
    private HmdQuad_t area;
    void Start()
    {
        if (SteamVR_PlayArea.GetBounds(SteamVR_PlayArea.Size.Calibrated, ref area))
        {
            Debug.Log(area);
        }
        StartRound();
    }

    public override void StartRound()
    {
        instructions.SetActive(false);
        gamecast.SetActive(true);
        endTime = Time.time + timeLimit;
        ended = false;
        launcher.StartFiring();
    }

    public override void EndRound()
    {
        Debug.Log("Round Ended");
        launcher.StopFiring();
        ended = true;
        if (currentPlayer < GameController.instance.numberOfPlayers - 1)
        {
            goals = 0;
            currentPlayer++;
            ResetScene();
        }
        else
        {
            Debug.Log("All players are done");
            // TODO: Show results somehow and exit to menu
        }
    }

    public override void ResetScene()
    {

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
