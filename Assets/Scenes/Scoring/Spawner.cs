using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject soccerball;
    private int counter = 0;
    // Update is called once per frame
    void Update()
    {
        counter ++;
        if(counter % 120 == 0){
            GameObject sb = Instantiate(soccerball, transform.position, Quaternion.identity);
            Rigidbody rb = sb.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 10;
        }
    }
}
