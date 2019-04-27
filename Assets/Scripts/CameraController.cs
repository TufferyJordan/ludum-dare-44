using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public SpawnerPlatform spawnerPlatform;
    public GamePhaseController gamePhaseController;
    
    private Vector3 cameraOffset;
    private Vector3 cameraQteOffset;
    private Vector3 cameraVelocity;
    private float initialPlayerYpos;
    
    void Start()
    {
        cameraVelocity = new Vector3();
        initialPlayerYpos = player.transform.position.y;
        cameraOffset = transform.position - player.transform.position;
        cameraQteOffset = cameraOffset - new Vector3(cameraOffset.x, 0, -3);
        transform.position = CameraPositionOnPlayer();
    }

    void LateUpdate()
    {
        transform.position = MutateSmoothPosition();
    }

    private Vector3 MutateSmoothPosition()
    {
        return Vector3.SmoothDamp(
            transform.position,
            NextCameraPosition(),
            ref cameraVelocity,
            0.4F,
            10F,
            Time.deltaTime
        );
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

    private bool IsCurrentQteNotEnding(GameObject activePlatform)
    {
        return activePlatform.CompareTag("qte") && (gamePhaseController.GetCurrentPhase() == GamePhaseController.Phase.QTE_START ||
                                                    gamePhaseController.GetCurrentPhase() == GamePhaseController.Phase.QTE_ACTIVE);
    }

    private Vector3 CameraPositionOnPlayer()
    {
        var playerPosition = player.transform.position;
        return new Vector3(playerPosition.x, initialPlayerYpos, playerPosition.z) + cameraOffset;
    }
}
