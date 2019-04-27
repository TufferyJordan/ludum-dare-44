using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GamePhaseController gamePhaseController;
    
    private const int MovementVelocity = 7;
    
    void Start()
    {
        
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
}
