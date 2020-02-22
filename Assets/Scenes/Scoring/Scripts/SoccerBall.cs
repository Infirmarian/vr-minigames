using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{
    private bool inGoal = false;
    // Prevents the ball from scoring multiple times
    public bool Score()
    {
        bool rv = !inGoal;
        inGoal = true;
        return rv;
    }
}
