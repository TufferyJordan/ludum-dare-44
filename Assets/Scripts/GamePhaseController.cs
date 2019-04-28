﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhaseController : MonoBehaviour
{
    public SpawnerPlatform spawnerPlatform;
    public RunningRule runningRule;
    public JumpDashRule jumpDash;
    public QteRule qteController;
    
    private Phase _currentPhase;

    public enum Phase
    {
        RUNNING,
        QTE_START,
        QTE_ACTIVE,
        QTE_END
    }
    
    void Start()
    {
        _currentPhase = Phase.RUNNING;
        runningRule.enabled = true;
        jumpDash.enabled = true;
    }

    void FixedUpdate()
    {
        var newPhase = CalculateNewPhase();
        if (_currentPhase != newPhase)
        {
            Debug.Log(newPhase);
            _currentPhase = newPhase;

            switch (newPhase)
            {
                case Phase.RUNNING:
                    break;
                case Phase.QTE_START:
                    jumpDash.enabled = false;
                    break;
                case Phase.QTE_ACTIVE:
                    runningRule.enabled = false;
                    qteController.Begin();
                    break;
                case Phase.QTE_END:
                    runningRule.enabled = true;
                    jumpDash.enabled = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private Phase CalculateNewPhase()
    {
        var activePlatform = spawnerPlatform.FindActivePlatform();
        switch (_currentPhase)
        {
            case Phase.RUNNING:
                if (activePlatform.CompareTag("qte"))
                {
                    return Phase.QTE_START;
                }
                break;
            case Phase.QTE_START:
                if (spawnerPlatform.FindPlatformRelativePosition() > 0.5F)
                {
                    return Phase.QTE_ACTIVE;
                }
                break;
            case Phase.QTE_END:
                if (!activePlatform.CompareTag("qte"))
                {
                    return Phase.RUNNING;
                }
                if (spawnerPlatform.FindPlatformRelativePosition() < 0.5F)
                {
                    return Phase.QTE_START;
                }
                break;
            case Phase.QTE_ACTIVE:
                if (!qteController.IsQteRunning())
                {
                    return Phase.QTE_END;
                }
                break;
            default:
                throw new NotImplementedException();
        }

        return _currentPhase;
    }

    public Phase GetCurrentPhase()
    {
        return _currentPhase;
    }
}
