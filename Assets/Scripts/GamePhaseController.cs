using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhaseController : MonoBehaviour
{
    private const double QteTempTimeLimit = 1D;

    public SpawnerPlatform spawnerPlatform;
    
    private Phase _currentPhase;
    private float _timeSpentInQte;

    public enum Phase
    {
        RUNNING,
        QTE_START,
        QTE_ACTIVE,
        QTE_END
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _currentPhase = Phase.RUNNING;
    }

    // Update is called once per frame
    void Update()
    {
        var newPhase = CalculateNewPhase();
        if (_currentPhase != newPhase)
        {
            Debug.Log(newPhase);
            _currentPhase = newPhase;

            if (newPhase == Phase.QTE_ACTIVE)
            {
                _timeSpentInQte = 0;
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
                _timeSpentInQte += Time.deltaTime;
                if (_timeSpentInQte > QteTempTimeLimit)
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
