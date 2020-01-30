using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    [SerializeField]
    private int goals = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "soccerball")
        {
            if (other.GetComponent<SoccerBall>().Score())
            {
                goals++;
                Debug.Log("Soccer Ball Scored!");
            }
        }
    }
}
