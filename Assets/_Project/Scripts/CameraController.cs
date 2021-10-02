using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform target;
    private Vector3 _offset;

    public float smoothSpeed = 0.15f;

    private void Start()
    {
        _offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
