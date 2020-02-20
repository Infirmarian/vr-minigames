using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBubble : MonoBehaviour
{
    public Rigidbody rb;

    private float time = 0.0f;
    public float speed;
    public int randomNumber1;
    public int randomNumber2;
    public int randomNumber3;
    public int binaryInt;

    void Start () 
    {
        rb = GetComponent<Rigidbody>();
        speed = 10.0f;

        randomNumber1 = Random.Range(5, 10);
        randomNumber2 = Random.Range(10, 20);
        randomNumber3 = Random.Range(1, 2);

        if (randomNumber3 % 2 == 0)
            binaryInt = 1;
        else
            binaryInt = -1;
        
    }

    
     void Update () 
    {
        rb.velocity = new Vector3(0, randomNumber1, 0);
        rb.AddForce(transform.forward * 100);
        transform.Rotate(new Vector3(0, randomNumber2 * binaryInt, 0) * Time.deltaTime * speed, Space.World);
        
    }
}
