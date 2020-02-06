using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_sphere : MonoBehaviour
{
    Vector3 sphere_location; //sphere location at start
    Vector3 board_location; //center of board's location at start
    //Board size is 10x10 units

    GameObject board;
    GameObject soccerball;

    Vector3[] corner_positions;
    int time = 0;

    float scale = 2.5f;

    ArrayList sphere_arr;

    void Start()
    {

        this.soccerball = GameObject.Find("Soccer_ball");
        this.sphere_location = soccerball.transform.position;
        
        this.board = GameObject.Find("Plane");
        this.board_location = board.transform.position;

        this.corner_positions = get_corners(this.board);

        Rigidbody rb = soccerball.GetComponent<Rigidbody>();
        Vector3 direction = this.ComputeRandomPosition(this.board_location, this.corner_positions) - this.sphere_location;
        rb.velocity = new Vector3(this.scale *direction.x, this.scale *direction.y, this.scale *direction.z);
        sphere_arr = new ArrayList();
    }

    Vector3[] get_corners(GameObject board){
        Vector3[] arr = new Vector3[4];

        arr[0] = this.board.transform.Find("top_right_corner").position;
        arr[1] = this.board.transform.Find("top_left_corner").position;
        arr[2] = this.board.transform.Find("bottom_right_corner").position;
        arr[3] = this.board.transform.Find("bottom_left_corner").position;


        return arr;
    }

    private Vector3 ComputeRandomPosition(Vector3 board_origin, Vector3[] corner_positions)
    {
        float width = Mathf.Abs(corner_positions[0].y - corner_positions[2].y);
        float height = Mathf.Abs(corner_positions[2].z - corner_positions[3].z);

        float rand_y = Random.Range(board_origin.y-(width/2), board_origin.y+(width/2));
        float rand_z = Random.Range(board_origin.z-(height/2), board_origin.z+(height/2));

        Vector3 destination = new Vector3(board_origin.x, rand_y, rand_z);
        return destination;
    }

    public void cleanup(){
        foreach( GameObject sphere in sphere_arr){
            Destroy(sphere, 0.0f);
        }
    }

    void Update()
    {
        this.time += 1;

        if(this.time%100 == 0){
            GameObject new_SoccerBall = Instantiate(this.soccerball, this.sphere_location, Quaternion.identity);
            Rigidbody rb = new_SoccerBall.GetComponent<Rigidbody>();
            Vector3 direction = this.ComputeRandomPosition(this.board_location, this.corner_positions) - this.sphere_location;
            rb.velocity = new Vector3(this.scale *direction.x, this.scale *direction.y, this.scale *direction.z);
            sphere_arr.Add(new_SoccerBall);
        }
    }
}
