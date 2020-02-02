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
    private Text score;
    private float endTime;
    private bool ended = false;
    void Start()
    {
        endTime = Time.time + timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Goals Missed: "+goals;
        if (Time.time > endTime)
        {
            ended = true;
        }
    }
}
