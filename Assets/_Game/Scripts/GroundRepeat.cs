using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRepeat : MonoBehaviour
{
    private GameController  gameController;
    public bool             instancedGround = false;

    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    void Update()
    {
        if (!instancedGround)
        {
            if(transform.position.x <= 0)
            {
                instancedGround = true;
                GameObject tempGround = Instantiate(gameController.groundPrefab);
                tempGround.transform.position = new Vector3(transform.position.x + gameController.groundLength, transform.position.y, 0);
                Debug.Log("Chão instanicado");
            }
        }

        if (transform.position.x < gameController.groundDestroyed)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        GroundMove();
    }

    void GroundMove()
    {
        transform.Translate(Vector2.left * gameController.groundVelocity * Time.deltaTime);
    }
}
