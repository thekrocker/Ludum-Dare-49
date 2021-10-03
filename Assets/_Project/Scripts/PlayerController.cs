using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    private Health _health;
    private Vector3 _direction;
    public float speed = 8;
    public float jumpForce = 10f;
    public float gravity = -8.92f;

    public float tickTime;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool isGrounded;
    public bool IsToggleLamp { get; private set; }

    public Transform model;
    public Material lampMat;
    public Volume volume;
    private Bloom _bloom;
    

    private void Start()
    {
        lampMat.DisableKeyword("_EMISSION");
        volume.profile.TryGet<Bloom>(out _bloom);
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        ToggleLamp();

        if (!IsToggleLamp)
        {
            tickTime -= Time.deltaTime;
            if (tickTime <= 0)
            {
                _health.TakeDamage(5);
                tickTime = 1;
            }
        }

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

    private void ToggleLamp()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsToggleLamp = !IsToggleLamp;
            ToggleLight();
        }
    }

    private void ToggleLight()
    {
        if (IsToggleLamp)
        {
            lampMat.EnableKeyword("_EMISSION");
            _bloom.threshold.value = 0;
            
            // HEALTH REGENATION
        }
        else
        {
            lampMat.DisableKeyword("_EMISSION");
            _bloom.threshold.value = 0.5f;
            // HEALTH DEGENERATION
        }
    }
}