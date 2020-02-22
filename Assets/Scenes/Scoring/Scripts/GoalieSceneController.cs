using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
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
    private HmdQuad_t area;
    [SerializeField]
    private GameObject goal;
    void Start()
    {
        if(SteamVR_PlayArea.GetBounds(SteamVR_PlayArea.Size.Calibrated, ref area))
        {
            Debug.Log("Calibrating Area");
            Vector3 c0 = new Vector3(area.vCorners0.v0, area.vCorners0.v1, area.vCorners0.v2);
            Vector3 c1 = new Vector3(area.vCorners1.v0, area.vCorners1.v1, area.vCorners1.v2);
            Vector3 c2 = new Vector3(area.vCorners2.v0, area.vCorners2.v1, area.vCorners2.v2);
            Vector3 c3 = new Vector3(area.vCorners3.v0, area.vCorners3.v1, area.vCorners3.v2);
            // Instantiate(corner, c0, Quaternion.identity);
            // Instantiate(corner, c1, Quaternion.identity);
            float width = Mathf.Abs(c0.x, c1.x);
            goal.transform.scale.x = width;
           // Instantiate(corner, c2, Quaternion.identity);
           // Instantiate(corner, c3, Quaternion.identity);
        }
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
