using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Rigidbody2D coinRB;
    private GameController gameControllerScript;

    void Start()
    {
        coinRB = GetComponent<Rigidbody2D>();
        coinRB.velocity = new Vector2(-6f, 0);
        gameControllerScript = FindObjectOfType(typeof(GameController)) as GameController;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            gameControllerScript.EarnPoints(1);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
