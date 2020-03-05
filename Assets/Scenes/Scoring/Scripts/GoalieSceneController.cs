using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.Extras;
public class GoalieSceneController : MinigameController
{
    private float[] scores;
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
        scores = new float[GameController.instance.numberOfPlayers];
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
    // Start the round, or display the results if all players have aready gone
    public override void StartRound()
    {
        if (currentPlayer == GameController.instance.numberOfPlayers)
        {
            vrMenu.ShowResults(scores);
            return;
        }
        pointer.active = false;
        vrMenu.HideMenu();
        endTime = Time.time + timeLimit;
        inGame = true;
        launcher.StartFiring();
    }

    public override void EndRound()
    {
        pointer.active = true;
        scores[currentPlayer] = 1f - (float)goals / launcher.numberOfShots;
        vrMenu.ShowIndividualResults(currentPlayer + 1, launcher.numberOfShots, scores[currentPlayer]);
        launcher.StopFiring();
        inGame = false;
        ResetScene();
        currentPlayer++;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public override void ResetScene()
    {
        goals = 0;

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
