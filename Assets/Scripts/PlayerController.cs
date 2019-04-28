using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GamePhaseController gamePhaseController;
    public GameModifiers gameModifiers;

    private Collider _collider;
    private MeshRenderer _meshRenderer;
    private RunningRule _listener;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }

    public void RegisterRuleListener(RunningRule listener)
    {
        _listener = listener;
    }

    private void OnCollisionEnter(Collision other)
    {
        _listener.DoActionsOnAnyCollision(_collider, other);
    }

    private void Update()
    {
        BlinkPlayerWhenInvulnerable();
    }

    private void BlinkPlayerWhenInvulnerable()
    {
        if (gameModifiers.IsInvulnerable())
        {
            _meshRenderer.enabled = ((int) Math.Floor((gameModifiers.GetInvulnerabilityRemainingDuration() * 10) % 2)) == 0;
        }
        else
        {
            if (!_meshRenderer.enabled)
            {
                _meshRenderer.enabled = true;
            }
        }
    }
}
