using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    public Animator anim;
    private Vector3 _direction;
    public float speed = 8;
    public float jumpForce = 10f;
    public float gravity = -8.92f;
    
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool isGrounded;

    public Transform model;

    

    private void Update()
    {
        float hInput = Input.GetAxis("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(hInput));
        _direction.x = hInput * speed;
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        
        anim.SetBool("isGrounded", isGrounded);



        if (isGrounded)
        {
            // _direction.y = 0;
            if (Input.GetButtonDown("Jump"))
            {

                _direction.y = jumpForce;
            }
        }
        else
        {
            _direction.y += gravity * Time.deltaTime;
        }

        if (hInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
            model.rotation = newRotation;
        }

        controller.Move(_direction * Time.deltaTime);
    }
}
