using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private Rigidbody2D myRB; 
    private GameController gameControllerScript;
    private CameraShacker cameraShaker;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        gameControllerScript = FindObjectOfType(typeof(GameController)) as GameController;
        cameraShaker = FindObjectOfType(typeof(CameraShacker)) as CameraShacker;
        //myRB.velocity = new Vector2(-5f, 0);
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        MoveObject();
    }

    void MoveObject()
    {
        transform.Translate(Vector2.left * gameControllerScript.obstacleVelocity * Time.smoothDeltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameControllerScript.LoseLife(1);
            cameraShaker.ShakeIt();
        }
    }
}
