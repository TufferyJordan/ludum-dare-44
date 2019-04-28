using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningRule : MonoBehaviour
{
    private const int MovementVelocity = 7;
    
    public PlayerController playerController;
    public Rigidbody playerRigid;
    public GameModifiers gameModifiers;

    void Awake()
    {
        playerController.RegisterRuleListener(this);
    }

    private void FixedUpdate()
    {
        var newPosition = playerRigid.position + new Vector3(MovementVelocity * Time.fixedDeltaTime, 0, 0);
        playerRigid.MovePosition(newPosition);
    }

    public void DoActionsOnAnyCollision(Collider player, Collision other)
    {
        if (!other.gameObject.CompareTag("prop_obstacle"))
        {
            return;
        }

        var obstacleProp = other.transform.GetComponent<ObstacleProp>();
        if (obstacleProp != null && !obstacleProp.IsAlreadyCollided())
        {
            obstacleProp.DoCollide(player, true);
            gameModifiers.TakeDamage(GameModifiers.DangerSource.OBSTACLE_COLLIDED);
        }
    }

}
