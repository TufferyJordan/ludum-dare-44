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
    private Quaternion cameraQteRotation;
    private Quaternion cameraRotation;
    float rotationVelocity = 0;
    
    void Start()
    {
        cameraVelocity = new Vector3();
        initialPlayerYpos = player.transform.position.y;
        cameraOffset = transform.position - player.transform.position;
        cameraQteOffset = cameraOffset - new Vector3(cameraOffset.x + 4, 1, -5);
//        cameraRotation = transform.rotation;
//        cameraQteRotation = transform.rotation * Quaternion.Euler(0, 20, 0);
        transform.position = CameraPositionOnPlayer();
    }

    void FixedUpdate()
    {
        transform.position = MutateSmoothPosition();
        MutateSmoothRotation();
    }

    private Vector3 MutateSmoothPosition()
    {
        return Vector3.SmoothDamp(
            transform.position,
            NextCameraPosition(),
            ref cameraVelocity,
            0.7F,
            20F,
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
