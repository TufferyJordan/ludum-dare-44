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

        GenerateSoundEffect(player);
    }

    private void GenerateSoundEffect(Collider player)
    {
        PropType type = gameObject.GetComponent<PropType>();
        if (type.type == PropType.TYPE_FENCE)
        {
            if (player.CompareTag("Player"))
            {
                AudioManager.instance.PlayerHitWood();
            }
            else
            {
                AudioManager.instance.HitWood();
            }
        } 
        else if (type.type == PropType.TYPE_TRASH)
        {
            if (player.CompareTag("Player"))
            {
                AudioManager.instance.PlayerHitGarbage();
            }
            else
            {
                AudioManager.instance.HitGarbage();
            }
        }
        else if (type.type == PropType.TYPE_BIG_TRASH)
        {
            if (player.CompareTag("Player"))
            {
                AudioManager.instance.PlayerHitMetal();
            }
            else
            {
                AudioManager.instance.HitMetal();
            }
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
