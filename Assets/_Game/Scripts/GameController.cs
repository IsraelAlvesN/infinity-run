using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Ground Configuration")]
    public GameObject groundPrefab;
    public float groundDestroyed;
    public float groundLength;
    public float groundVelocity;
    [Header("Obstacles Configuration")]
    public float obstacleTime;
    public float obstacleVelocity;
    public GameObject obstaclePrefab;


    void Start()
    {
        StartCoroutine("SpawnObstacle");
    }


    void Update()
    {
    }

    IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(obstacleTime);

        GameObject obstacleObjTemp = Instantiate(obstaclePrefab);
        StartCoroutine("SpawnObstacle");
    }
}
