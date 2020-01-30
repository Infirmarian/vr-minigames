using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalieSceneController : MonoBehaviour
{
    [SerializeField]
    private int timeLimit = 60;
    private float endTime;
    private bool ended = false;
    void Start()
    {
        endTime = Time.time + timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > endTime)
        {
            ended = true;
        }
    }
}
