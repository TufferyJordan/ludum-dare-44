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
    private SkinnedMeshRenderer _meshRenderer;
    private RunningRule _listener;
    private float _meshDelay;

    void Start()
    {
        _meshRenderer = GameObject.Find("Group3123").GetComponent<SkinnedMeshRenderer>();
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
        if (gamePhaseController.GetCurrentPhase() == GamePhaseController.Phase.QTE_ACTIVE)
        {
            HidePlayerAfterAShortWhile();
            
        } else
        {
            BlinkPlayerWhenInvulnerable();
        }
    }

    private void HidePlayerAfterAShortWhile()
    {
        if (_meshDelay < 0)
        {
            _meshRenderer.enabled = false;
        }
        _meshDelay -= Time.deltaTime;
    }

    private void BlinkPlayerWhenInvulnerable()
    {
        _meshDelay = 0.1F;
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
