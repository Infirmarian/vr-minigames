using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.Extras;
public class GoalieSceneController : MinigameController
{
    [SerializeField]
    public int goals = 0;
    [SerializeField]
    private Text UIScore, VRScore, timer;
    [SerializeField]
    private VRMenuController vrMenu;
    [SerializeField]
    private FireSphere launcher;
    private float endTime;
    private bool inGame = false;
    private HmdQuad_t area;
    [SerializeField]
    private GameObject goal;
    [SerializeField]
    private SteamVR_LaserPointer pointer;
    void Start()
    {
        if (SteamVR_PlayArea.GetBounds(SteamVR_PlayArea.Size.Calibrated, ref area))
        {
            Debug.Log("Calibrating Area");
            Vector3 c0 = new Vector3(area.vCorners0.v0, area.vCorners0.v1, area.vCorners0.v2);
            Vector3 c1 = new Vector3(area.vCorners1.v0, area.vCorners1.v1, area.vCorners1.v2);
            Vector3 c2 = new Vector3(area.vCorners2.v0, area.vCorners2.v1, area.vCorners2.v2);
            Vector3 c3 = new Vector3(area.vCorners3.v0, area.vCorners3.v1, area.vCorners3.v2);
            // Instantiate(corner, c0, Quaternion.identity);
            // Instantiate(corner, c1, Quaternion.identity);
            float width = Mathf.Abs(c0.x - c1.x);
            goal.transform.localScale = new Vector3(width, goal.transform.localScale.y, goal.transform.localScale.z);
            // Instantiate(corner, c2, Quaternion.identity);
            // Instantiate(corner, c3, Quaternion.identity);
        }
        //        StartRound();
    }

    public override void StartRound()
    {
        pointer.active = false;
        vrMenu.HideMenu();
        endTime = Time.time + timeLimit;
        inGame = true;
        launcher.StartFiring();
    }

    public override void EndRound()
    {
        Debug.Log("Round Ended");
        vrMenu.ShowResults();
        launcher.StopFiring();
        inGame = false;
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
        //        VRScore.text = "Goals Missed: " + goals;
        timer.text = ((int)Mathf.Max(0, endTime - Time.time)).ToString();
        if (inGame && Time.time > endTime)
        {
            EndRound();
        }
    }
}
