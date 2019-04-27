using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int MovementVelocity = 7;
    
    public GamePhaseController gamePhaseController;

    private Collider _collider;
    private Rigidbody _rigidbody;

    void Start()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        switch (gamePhaseController.GetCurrentPhase())
        {
            case GamePhaseController.Phase.QTE_START:
            case GamePhaseController.Phase.QTE_END:
            case GamePhaseController.Phase.RUNNING:
                var newPosition = _rigidbody.position + new Vector3(MovementVelocity * Time.fixedDeltaTime, 0, 0);
                _rigidbody.MovePosition(newPosition);
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
