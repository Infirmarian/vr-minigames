using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSphere : MonoBehaviour
{
    [SerializeField]
    private float timeBetweenShots = 1f;
    private float nextShotTime = 2f;
    [SerializeField]
    GameObject board, fireSpot;
    [SerializeField]
    GameObject soccerball;
    bool firing = false;
    private Bounds target;

    [SerializeField]
    float horizontalVelocity = 10f, velocityRange = 2f, rotationRange = 10f;

    List<GameObject> sphere_arr = new List<GameObject>();

    void Start()
    {
        target = board.GetComponent<Renderer>().bounds;
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

    public void Cleanup()
    {
        foreach (GameObject sphere in sphere_arr)
        {
            Animator a = sphere.GetComponent<Animator>();
            a.SetTrigger("Pop");
            Destroy(sphere, 4f);
        }
        sphere_arr.Clear();
    }

    private Vector3 ComputeRandomVelocity(Vector3 origin)
    {
        Vector3 goal = new Vector3(Random.Range(0f, target.size.x) + target.min.x, Random.Range(0f, target.size.y) + target.min.y, Random.Range(0f, target.size.z + target.min.z));
        Vector3 delta = goal - origin;
        float selectedHorizontalVelocity = horizontalVelocity + (Random.Range(0, velocityRange) - velocityRange / 2f);
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
        sphere_arr.Add(new_SoccerBall);
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
