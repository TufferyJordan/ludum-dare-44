using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleProp : MonoBehaviour
{
    private bool alreadyCollided;
    private Collider[] _colliders;
    private Rigidbody _rigidbody;

    void Start()
    {
        alreadyCollided = false;
        _colliders = GetComponents<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
    }

    public void DoCollide(Collider player, bool ignoreFutureCollisions)
    {
        if (alreadyCollided)
        {
            return;
        }

        alreadyCollided = true;
        if (ignoreFutureCollisions)
        {
            foreach (var collider in _colliders)
            {
                Physics.IgnoreCollision(player, collider, true);
            }
        }
        _rigidbody.AddForce(new Vector3(4, 1, 1) * _rigidbody.mass * 100);
        _rigidbody.AddTorque(new Vector3(RandomValue(), RandomValue(), RandomValue()) * _rigidbody.mass);

        if (player.CompareTag("Player"))
        {
            AudioManager.instance.HitMetal();
        }
    }

    private float RandomValue()
    {
        return Random.Range(-100, 100);
    }

    public bool IsAlreadyCollided()
    {
        return alreadyCollided;
    }
}
