using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBubble : MonoBehaviour {
    public float maxNumber = 0.1;
    public float minNumber = 0;
    public float randomNumber = Random.Range(0, 0.1);
    [SerializeField]
    private float verticalSpeed = randomNumber;
    private Vector3 tempPosition;
    void Start () 
    {
        tempPosition = transform.position;
    }
     void FixedUpdate () 
    {
        tempPosition.y += verticalSpeed;
        transform.position = tempPosition;
    }
}
