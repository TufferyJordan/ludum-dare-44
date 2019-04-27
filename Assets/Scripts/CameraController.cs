using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public SpawnerPlatform spawnerPlatform;
    
    private Vector3 cameraOffset;
    private Vector3 cameraQteOffset;
    private Vector3 cameraVelocity;
    
    void Start()
    {
        cameraVelocity = new Vector3();
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
        if (activePlatform.CompareTag("qte"))
        {
            return activePlatform.transform.position + cameraQteOffset;
        }
        else
        {
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
    }

    private Vector3 CameraPositionOnPlayer()
    {
        return player.transform.position + cameraOffset;
    }
}
