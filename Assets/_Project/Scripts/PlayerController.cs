using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    private Vector3 _direction;
    public float speed = 8;
    public float jumpForce = 10f;
    public float gravity = -8.92f;
    
    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool canDoubleJump = true;


    private void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
       
        _direction.x = hInput * speed;
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);


        if (isGrounded)
        {
            // _direction.y = 0;
            canDoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                _direction.y = jumpForce;
            }
        }
        else
        {
            _direction.y += gravity * Time.deltaTime;
            if (canDoubleJump && Input.GetButtonDown("Jump"))
            {
                _direction.y = jumpForce;
                canDoubleJump = false;
            }
        }

        controller.Move(_direction * Time.deltaTime);
    }
}
