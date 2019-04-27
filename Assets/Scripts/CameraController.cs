using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject camera;
    private Vector3 cameraOffset;
    private Vector3 cameraVelocity;
    
    void Start()
    {
        cameraVelocity = new Vector3();
        cameraOffset = camera.transform.position - transform.position;
        camera.transform.position = NextCameraPosition();
    }

    void Update()
    {
        camera.transform.position = MutateSmoothPosition();
    }

    private Vector3 MutateSmoothPosition()
    {
        return Vector3.SmoothDamp(
            camera.transform.position,
            NextCameraPosition(),
            ref cameraVelocity,
            0.4F,
            10F,
            Time.deltaTime
        );
    }

    private Vector3 NextCameraPosition()
    {
        return transform.position + cameraOffset;
    }
}
