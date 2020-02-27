using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabber_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision){
        GameObject bubble = collision.gameObject;
        if(bubble.name == "Bubble(Clone)"){
            // Animator a = bubble.GetComponent<Animator>();
            // bubble.SetTrigger("Pop");
            Destroy(bubble);
        }
        else if(bubble.name == "Bubble"){
            bubble.transform.Translate(new Vector3(0,15,0));
        }
    }
}
