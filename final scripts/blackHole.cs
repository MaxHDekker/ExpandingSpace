﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackHole : MonoBehaviour
{
    private float speed;
    private float health = 100f;
    private float jumpHeight = 1f;
    public float moveSpeed;
    public float jumpForce;
    private int count;
    public static int score;
    public float seconds;

    public float jumpTime;
    private float jumpTimeCounter;
    private bool IsTiming = false;
    private bool onPlatform;
    public LayerMask whatIsPlatform;

    private Collider2D myCollider;

    private Rigidbody2D myRigidbody;

    void Start()
    {
        count = 0;
        seconds = 2;
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        jumpTimeCounter = jumpTime;
    }

    void beginTimer()
    {
        seconds = 1;
        IsTiming = false;
    }

    void Update()
    {
        if (IsTiming)
        {
            seconds -= Time.deltaTime;
        }
        if (seconds <= 0)
        {
            IsTiming = false;
            count = count - 1;
            moveSpeed = speed - 500;

        }
        onPlatform = Physics2D.IsTouchingLayers(myCollider, whatIsPlatform);

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (onPlatform)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            jumpTimeCounter = 0;
        }

        if (onPlatform)
        {
            jumpTimeCounter = jumpTime;
        }

    }





}
