using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private float timeBetweenSpawns = 1f, nextSpawnTime = 1f;
    [SerializeField]
    GameObject o, spawn_area;
    [SerializeField]
    private int objects_in_play = 0, maxObjects = 10;
    protected GameObject[] object_arr;

    // Returns index of array for the created object
    int Spawn(){
        GameObject new_object = Instantiate(o, spawn_area.transform.position, Quaternion.identity);
        if(object_arr[objects_in_play%maxObjects] != null)
        {
            DeleteObject(object_arr[objects_in_play%maxObjects]);
        }
        object_arr[objects_in_play%maxObjects] = new_object;
        objects_in_play++;
        return objects_in_play%maxObjects;
    }

    protected void DeleteObject(GameObject g)
    {
        Destroy(g, 3f);
    }
    public void Cleanup()
    {
        for(int i = 0; i<object_arr.Length; i++)
        {
            if(object_arr[i] != null)
                DeleteObject(object_arr[i]);
            object_arr[i] = null;
        }
    }

    void Start()
    {
        object_arr = new GameObject[maxObjects];
    }
    void Update()
    {
        if(Time.time > nextSpawnTime){
            nextSpawnTime = Time.time + timeBetweenSpawns;
            Spawn();
        }
    }
}
