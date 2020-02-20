using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBubble : MonoBehaviour
{
    public Rigidbody rb;

    private float time = 0.0f;
    private bool isMoving = false;
    private bool isJumpPressed = false;
    public float speed;
    public int i = 1;

    void Start () 
    {
        rb = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        speed = 10.0f;
        
    }

    
     void Update () 
    {
        rb.velocity = new Vector3(0, 2, 0);
        rb.AddForce(transform.forward * 100);
        transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime * speed, Space.World);
        
    }
}
