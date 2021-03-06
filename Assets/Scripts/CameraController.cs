﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float NudgeDuration = 0.2F;
    public GameObject player;
    public SpawnerPlatform spawnerPlatform;
    public GamePhaseController gamePhaseController;
    
    private Vector3 cameraOffset;
    private Vector3 cameraQteOffset;
    private Vector3 cameraVelocity;
    private float initialPlayerYpos;
    private Quaternion cameraQteRotation;
    private Quaternion cameraRotation;
    private float rotationVelocity = 0;
    private Vector3 _nudgeVector;
    private double _nudgeRemaining;

    void Start()
    {
        _nudgeRemaining = 0;
        cameraVelocity = new Vector3();
        initialPlayerYpos = player.transform.position.y;
        var relativePosition = transform.position - player.transform.position;
        cameraOffset = relativePosition + new Vector3(-3, -2, 3);
        cameraQteOffset = relativePosition - new Vector3(relativePosition.x + 4, 1, -5);
        transform.position = CameraPositionOnPlayer();
    }

    public void Nudge()
    {
        _nudgeRemaining = NudgeDuration;
        _nudgeVector = new Vector3(RandomValue(), RandomValue(), RandomValue()).normalized * 0.05F;
    }

    private float RandomValue()
    {
        return Random.Range(-100, 100);
    }

    void FixedUpdate()
    {
        var nudgeFactor = (float)(_nudgeRemaining / NudgeDuration);
        transform.position = MutateSmoothPosition() + _nudgeVector * nudgeFactor;
        MutateSmoothRotation();
        
        _nudgeRemaining -= Time.fixedDeltaTime;
        if (_nudgeRemaining < 0)
        {
            _nudgeRemaining = 0;
        }
    }

    private Vector3 MutateSmoothPosition()
    {
        return Vector3.SmoothDamp(
            transform.position,
            NextCameraPosition(),
            ref cameraVelocity,
            0.7F,
            40F,
            Time.fixedDeltaTime
        );
    }

    private void MutateSmoothRotation()
    {
        Vector3 eulerAngles = this.transform.rotation.eulerAngles;
        eulerAngles.y = Mathf.SmoothDampAngle(
            eulerAngles.y,
            NextCameraRotation(),
            ref rotationVelocity, 
            0.7F, 
            1000
        );
        this.transform.rotation = Quaternion.Euler(eulerAngles);
    }
    private Vector3 NextCameraPosition()
    {
        var activePlatform = spawnerPlatform.FindActivePlatform();
        if (IsCurrentQteNotEnding(activePlatform))
        {
            return activePlatform.transform.position + cameraQteOffset;
        }
        
        var platform = spawnerPlatform.FindNextPlatform();
        if (platform.CompareTag("qte"))
        {
            return platform.transform.position + cameraQteOffset;
        }
        else
        {
            return CameraPositionOnPlayer();
        }
    }

    private float NextCameraRotation()
    {
        var platform = spawnerPlatform.FindActivePlatform();
        if (platform.CompareTag("qte"))
        {
            if (gamePhaseController.GetCurrentPhase() == GamePhaseController.Phase.QTE_START)
            {
                return 35;
                
            } else if (gamePhaseController.GetCurrentPhase() == GamePhaseController.Phase.QTE_ACTIVE)
            {
                return 35;
                
            }
        }
        
        var nextPlatform = spawnerPlatform.FindNextPlatform();
        if (nextPlatform.CompareTag("qte"))
        {
            return 20;
        }
        else
        {
            return 10F;
        }
    }


    private bool IsCurrentQteNotEnding(GameObject activePlatform)
    {
        return activePlatform.CompareTag("qte") && (gamePhaseController.GetCurrentPhase() == GamePhaseController.Phase.QTE_START ||
                                                    gamePhaseController.GetCurrentPhase() == GamePhaseController.Phase.QTE_ACTIVE);
    }

    private Vector3 CameraPositionOnPlayer()
    {
        var playerPosition = player.GetComponent<Rigidbody>().position;
        return new Vector3(playerPosition.x, initialPlayerYpos, playerPosition.z) + cameraOffset;
    }
}
