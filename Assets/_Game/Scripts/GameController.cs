using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [Header("Coin Configuration")]
    public float coinTime;
    public GameObject collectableCoinPrefab;
    [Header("UI Configuration")]
    public int playerPoints;
    public Text txtPoints;
    public int playerLife;
    public Text txtLife;
    public Text txtMeters;
    [Header("Distance Control")]
    public int travelledMeters = 0;

    void Start()
    {
        StartCoroutine("SpawnObstacle");
        StartCoroutine("SpawnCoin");
        InvokeRepeating("TravelledDistance", 0f, 0.2f);
    }


    void Update()
    {
    }

    public void EarnPoints(int qtdPoints)
    {
        playerPoints += qtdPoints;
        txtPoints.text = playerPoints.ToString();
    }
    public void LoseLife(int qtdPoints)
    {
        playerLife -= qtdPoints;
        if(playerLife <= 0)
        {
            txtLife.text = "0";
            SceneManager.LoadScene("lvl_1");
        }
        else
        {
            txtLife.text = playerLife.ToString();
        }
    }

    void TravelledDistance()
    {
        travelledMeters++;
        txtMeters.text = travelledMeters.ToString() + " m";
    }

    IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(obstacleTime);

        GameObject obstacleObjTemp = Instantiate(obstaclePrefab);
        StartCoroutine("SpawnObstacle");
    }

    IEnumerator SpawnCoin()
    {
        int randomCoin = Random.Range(1, 5);
        for (int i = 1; i <= randomCoin; i++)
        {
            yield return new WaitForSeconds(coinTime);
            GameObject objSpawner = Instantiate(collectableCoinPrefab);
            objSpawner.transform.position = new Vector3(objSpawner.transform.position.x, objSpawner.transform.position.y, 0);
        }
    }
}
