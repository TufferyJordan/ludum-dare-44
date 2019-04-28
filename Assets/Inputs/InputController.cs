using UnityEngine;
using UnityEngine.Experimental.Input;

public class InputController : MonoBehaviour
{
    private Controls controls;
    
    public QteRule qteRule;
    public JumpDashRule jumpDashRule;

    private void Awake()
    {
        //Init controls
        controls = new Controls();

        //Adds listeners
        controls.PlayerControls.Jump.performed += context => jumpDashRule.Jump();
        controls.PlayerControls.DashForward.performed += context => jumpDashRule.DashForward();

        controls.QteControls.Up.performed += context => qteRule.Input(QteRule.QteAction.UP);
        controls.QteControls.Down.performed += context => qteRule.Input(QteRule.QteAction.DOWN);
        controls.QteControls.Left.performed += context => qteRule.Input(QteRule.QteAction.LEFT);
        controls.QteControls.Right.performed += context => qteRule.Input(QteRule.QteAction.RIGHT);
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
