using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    [SerializeField]
    private GoalieSceneController gsc;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "soccerball")
        {
            if (other.GetComponent<SoccerBall>().Score())
            {
                gsc.goals++;
                Debug.Log("Soccer Ball Scored!");
            }
        }
    }
}
