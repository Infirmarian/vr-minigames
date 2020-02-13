using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSphere : MonoBehaviour
{
    [SerializeField]
    private float easyTimeBetweenShots, mediumTimeBetweenShots, hardTimeBetweenShots;
    private float timeBetweenShots, nextShotTime = 1f;
    [SerializeField]
    private GameObject board, easyFireSpot, mediumFireSpot, hardFireSpot;
    private GameObject fireSpot;
    [SerializeField]
    private GameObject soccerball;
    [SerializeField]
    private Difficulty difficulty;
    private bool firing = false;
    private Bounds target;

    [SerializeField]
    private float easyVelocity, mediumVelocity, hardVelocity;
    private float velocity;
    private float velocityRange = 2f, rotationRange = 10f;
    [SerializeField]
    private int numberOfShots = 0, maxSoccerballsOnScreen = 10;

    private GameObject[] sphere_arr;

    void Start()
    {
        sphere_arr = new GameObject[maxSoccerballsOnScreen];
        target = board.GetComponent<Renderer>().bounds;
        switch (difficulty)
        {
            case Difficulty.EASY:
                fireSpot = easyFireSpot;
                velocity = easyVelocity;
                timeBetweenShots = easyTimeBetweenShots;
                break;
            case Difficulty.MEDIUM:
                fireSpot = mediumFireSpot;
                velocity = mediumVelocity;
                timeBetweenShots = mediumTimeBetweenShots;
                break;
            case Difficulty.HARD:
                fireSpot = hardFireSpot;
                velocity = hardVelocity;
                timeBetweenShots = hardTimeBetweenShots;
                break;
            default:
                return; // SHOULD NEVER BE EXECUTED
        }
    }

    // Start shooting (signal sent from GoalieSceneController)
    public void StartFiring()
    {
        firing = true;
        nextShotTime = Time.time + timeBetweenShots;
    }

    // Stop shooting (signal sent from GoalieSceneController)
    public void StopFiring()
    {
        firing = false;
        Cleanup();
    }
    private void DeleteSoccerball(GameObject g)
    {
        Animator a = g.GetComponent<Animator>();
        a.SetTrigger("Pop");
        Destroy(g, 3f);
    }
    public void Cleanup()
    {
        for (int i = 0; i < sphere_arr.Length; i++)
        {
            if (sphere_arr[i] != null)
                DeleteSoccerball(sphere_arr[i]);
            sphere_arr[i] = null;
        }
    }

    private Vector3 ComputeRandomVelocity(Vector3 origin)
    {
        Vector3 goal = new Vector3(Random.Range(0f, target.size.x) + target.min.x, Random.Range(0f, target.size.y) + target.min.y, Random.Range(0f, target.size.z + target.min.z));
        Vector3 delta = goal - origin;
        float selectedHorizontalVelocity = velocity + (Random.Range(0, velocityRange) - velocityRange / 2f);
        float horizontalDistance = Mathf.Sqrt(Mathf.Pow(delta.x, 2f) + Mathf.Pow(delta.z, 2f));
        float verticalDistance = delta.y;
        float airTime = horizontalDistance / selectedHorizontalVelocity;
        float fallDistance = 0.5f * Physics.gravity.y * Mathf.Pow(airTime, 2f);
        float velocityY = (verticalDistance - fallDistance) / airTime;
        delta = delta.normalized * selectedHorizontalVelocity;
        delta.y = velocityY;
        return delta;
    }

    void Fire()
    {
        GameObject new_SoccerBall = Instantiate(soccerball, fireSpot.transform.position, Quaternion.identity);
        Rigidbody rb = new_SoccerBall.GetComponent<Rigidbody>();
        rb.velocity = ComputeRandomVelocity(fireSpot.transform.position);
        rb.angularVelocity = Random.insideUnitSphere * rotationRange;
        if (sphere_arr[numberOfShots % maxSoccerballsOnScreen] != null)
        {
            DeleteSoccerball(sphere_arr[numberOfShots % maxSoccerballsOnScreen]);
        }
        sphere_arr[numberOfShots % maxSoccerballsOnScreen] = new_SoccerBall;

        numberOfShots++;
    }

    void Update()
    {
        if (firing && Time.time > nextShotTime)
        {
            nextShotTime = Time.time + timeBetweenShots;
            Fire();
        }
    }
}
