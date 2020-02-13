using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBubble : MonoBehaviour {
    public float maxNumber = 0.1f;
    public float minNumber = 0f;
    public float randomNumber;
    public float randomNumber2;
    public float verticalSpeed;
    public float horizontalSpeed;
    public Vector3 tempPosition;
    void Start () 
    {
        randomNumber = Random.Range(0.05f, 0.15f);
        verticalSpeed = randomNumber;
        tempPosition = transform.position;
    }
     void FixedUpdate () 
    {
        tempPosition.y += verticalSpeed;
        randomNumber2 = Random.Range(-0.1f, 0.1f);
        horizontalSpeed = randomNumber2;
        tempPosition.x += horizontalSpeed;
        transform.position = tempPosition;
    }
}
