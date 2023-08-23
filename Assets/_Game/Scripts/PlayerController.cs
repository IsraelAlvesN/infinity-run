using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameController gameControllerScript;
    private Animator anim;
    private Rigidbody2D myRB;
    public LayerMask layerGround;
    public Transform checkGround;
    public float speed = 0f;
    public bool isGrounded = true;
    public string isGroundBool = "bIsGround";
    public float jumpForce = 500f;


    void Start()
    {
        anim = GetComponent<Animator>();
        myRB = GetComponent<Rigidbody2D>();
        gameControllerScript = FindObjectOfType(typeof(GameController)) as GameController;
        MovePlayer();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(speed, 0, 0));
        if (Physics2D.OverlapCircle(checkGround.transform.position, 0.2f, layerGround))
        {
            anim.SetBool(isGroundBool, true);
            isGrounded = true;
        }
        else
        {
            anim.SetBool(isGroundBool, false);
            isGrounded = false;
        }
    }

    private void MovePlayer()
    {
        transform.Translate(new Vector3(speed, 0, 0));
    }

    public void Jump()
    {
        if (isGrounded)
        {
            myRB.velocity = Vector2.zero;
            myRB.AddForce(new Vector2(0, jumpForce));
            gameControllerScript.fxGame.PlayOneShot(gameControllerScript.fxJump);
        }
    }
}
