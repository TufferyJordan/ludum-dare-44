using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int MovementVelocity = 7;
    
    public GamePhaseController gamePhaseController;

    private Collider _collider;

    void Start()
    {
        _collider = GetComponent<Collider>();
    }

    void Update()
    {
        switch (gamePhaseController.GetCurrentPhase())
        {
            case GamePhaseController.Phase.QTE_START:
            case GamePhaseController.Phase.QTE_END:
            case GamePhaseController.Phase.RUNNING:
                transform.position += new Vector3(MovementVelocity * Time.deltaTime, 0, 0);
                break;
            case GamePhaseController.Phase.QTE_ACTIVE:
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        DoActionsRelatedToObstacleCollision(other);
    }

    private void DoActionsRelatedToObstacleCollision(Collision other)
    {
        if (!other.gameObject.CompareTag("prop_obstacle"))
        {
            return;
        }

        var obstacleProp = other.transform.GetComponent<ObstacleProp>();
        if (obstacleProp != null && !obstacleProp.IsAlreadyCollidedWithPlayer())
        {
            Debug.Log("Collision!!!111111");
            obstacleProp.DoCollideWithPlayer(_collider);
        }
    }
}
