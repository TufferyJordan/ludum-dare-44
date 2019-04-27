using UnityEngine;
using UnityEngine.Experimental.Input;

public class InputController : MonoBehaviour
{
    private Controls controls;
    
    public int jumpForce;
    public int dashForce;
    public GamePhaseController gamePhaseController;
    
    private float distanceToGround;

    public GameObject player;

    private void Awake()
    {
        //Init controls
        controls = new Controls();

        //Adds listeners
        controls.PlayerControls.Jump.performed += context => Jump();
        controls.PlayerControls.DashForward.performed += context => DashForward();

        distanceToGround = player.transform.GetComponent<Collider>().bounds.extents.y;
    }

    private bool CanMove()
    {
        return gamePhaseController.GetCurrentPhase() == GamePhaseController.Phase.RUNNING ||
               gamePhaseController.GetCurrentPhase() == GamePhaseController.Phase.QTE_END;
    }

    private void Jump()
    {
        if (!CanMove())
        {
            return;
        }
        
        if (IsGrounded())
        {
            player.transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }

    private void DashForward()
    {
        if (!CanMove())
        {
            return;
        }
        
        if (IsGrounded())
        {
            player.transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * dashForce);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(player.transform.position, -Vector3.up, distanceToGround + 0.1f);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
