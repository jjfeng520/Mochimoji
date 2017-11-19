using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGoalTerrain : MonoBehaviour {
    public GameObject[] obj;
    public float spawnTime = 1f;

    public void SpawnGoal()
    {
        Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
        Invoke("SpawnGoal", spawnTime);
    }
}
