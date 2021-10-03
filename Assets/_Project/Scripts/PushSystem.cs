using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSystem : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;

    private PlayerController _playerController;

    private bool _isPushing;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Block"))
        {
            _isPushing = true;
            Rigidbody rb = hit.collider.attachedRigidbody;

            if (!_playerController.isOnBlock)
            {
                if (rb != null)
                {
                    Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                    forceDirection.y = 0;
                    forceDirection.Normalize();
                    rb.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);

                    _playerController.speed = 3;
                    _playerController.anim.SetBool("isPushing", true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _playerController.speed = 8;
        _isPushing = false;
        _playerController.anim.SetBool("isPushing", _isPushing);
    }
}