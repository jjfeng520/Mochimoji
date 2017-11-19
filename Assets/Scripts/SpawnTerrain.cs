using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTerrain : MonoBehaviour {
    public GameObject[] obj;
    public float spawnTime = 1f;
    //public SpawnGoalTerrain goal;

    void Start () {
        SpawnRandom();
        //for (var i = 0; i < 10; i++)
        //{
        //    SpawnRandom();
        //}
        //goal.SpawnGoal();
    }

    void SpawnRandom ()
    {
        Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
        Invoke("SpawnRandom", spawnTime);
    }
}
