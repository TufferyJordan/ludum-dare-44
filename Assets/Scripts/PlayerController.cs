using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private const int MovementVelocity = 7;
    
    public GamePhaseController gamePhaseController;
    public Text dangerMeter; 

    private Collider _collider;
    private Rigidbody _rigidbody;
    private int _danger;

    void Start()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        _danger = 0;
        UpdateDangerView();
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
            obstacleProp.DoCollideWithPlayer(_collider);
            IncrementDanger();
        }
    }

    private void IncrementDanger()
    {
        _danger++;
        
        // TODO danger view
        UpdateDangerView();
    }

    private void UpdateDangerView()
    {
        dangerMeter.text = "Danger: " + _danger;
    }
}
