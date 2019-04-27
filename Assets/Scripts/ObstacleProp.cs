﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleProp : MonoBehaviour
{
    private bool alreadyCollided;
    private Collider _collider;
    private Rigidbody _rigidbody;

    void Start()
    {
        transform.position = transform.position + new Vector3(Random.Range(-2.5F, 2.5F), 0, 0);
        alreadyCollided = false;
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
    }

    public void DoCollideWithPlayer(Collider player)
    {
        if (alreadyCollided)
        {
            return;
        }
        
        alreadyCollided = true;
        Physics.IgnoreCollision(player, _collider, true);
        _rigidbody.AddForce(new Vector3(4, 1, 1) * _rigidbody.mass * 100);
        _rigidbody.AddTorque(new Vector3(RandomValue(), RandomValue(), RandomValue())  * _rigidbody.mass);
    }

    private float RandomValue()
    {
        return Random.Range(-100, 100);
    }

    public bool IsAlreadyCollidedWithPlayer()
    {
        return alreadyCollided;
    }
}
