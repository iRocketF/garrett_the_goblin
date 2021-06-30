using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 move;
    private Vector3 velocity;
    private bool isGrounded;

    public float debug;

    private bool isTouchingFront;
    public Transform frontCheck;
    private bool wallSliding;
    public float wallSlidingSpeed = -6;

    private float previousHeight;
    private bool isFalling;

    void Update()
    {
        UpdateMovement();
    }

    void UpdateMovement()
    {
        // Ground and front checks
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isTouchingFront = Physics.CheckSphere(frontCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Rotation of the character
        if (x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            move = transform.forward * x;
            move.z = 0;
        }   
        else if (x < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            move = -transform.forward * x;
            move.z = 0;
        }
            
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        isFalling = previousHeight > transform.position.y;

        if (isTouchingFront && !isGrounded && x != 0 && isFalling)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            velocity.y += wallSlidingSpeed * Time.deltaTime;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        previousHeight = transform.position.y;
        controller.Move((move * speed * Time.deltaTime) + velocity * Time.deltaTime);
    }
}
