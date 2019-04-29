using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDashRule : MonoBehaviour
{
    private const float DebounceDuration = 0.2F;
    
    public int jumpForce = 250;
    public int dashForce = 250;
    public GameObject player;
    
    private float _distanceToGround;
    private float _lastYPosition;
    private float _jumpDebounce;
    private float _dashAndCrouchDebounce;
    private Rigidbody _playerRigidBody;
    private Animator _animator;
    private Vector3 _initialColliderCenter;
    private Vector3 _initialColliderSize;


    void Awake()
    {
        _jumpDebounce = 0;
        _dashAndCrouchDebounce = 0;
        _distanceToGround = player.transform.GetComponent<Collider>().bounds.extents.y;
        _playerRigidBody = player.transform.gameObject.GetComponent<Rigidbody>();
        _animator = GameObject.Find("Character").GetComponent<Animator>();
        _lastYPosition = player.transform.position.y;
        _initialColliderSize = player.GetComponent<BoxCollider>().size;
        _initialColliderCenter = player.GetComponent<BoxCollider>().center;
    }

    private void Update()
    {
        EndOfJump();
        _jumpDebounce -= Time.deltaTime;
        _dashAndCrouchDebounce -= Time.deltaTime;
    }


    public void Jump()
    {
        if (isActiveAndEnabled && IsGrounded() && _jumpDebounce <= 0)
        {
            AudioManager.instance.StartJump();
            _animator.SetBool("isJumping", true);
            _jumpDebounce = DebounceDuration;
            _playerRigidBody.AddForce(Vector3.up * jumpForce);
        }
    }

    public void Crouch()
    {
        if (isActiveAndEnabled && IsGrounded() && _dashAndCrouchDebounce <= 0)
        {
            _animator.SetBool("isCrouching", true);
            player.GetComponent<BoxCollider>().center = new Vector3(0.009640098f, -0.3015763f, 0);
            player.GetComponent<BoxCollider>().size = new Vector3(0.4023044f, 0.3389367f, 1);
            StartCoroutine(EndOfDash(0.8f));
            _dashAndCrouchDebounce = DebounceDuration;
        }
    }

    public void DashForward()
    {
        if (isActiveAndEnabled && IsGrounded() && _dashAndCrouchDebounce <= 0)
        {
            _animator.SetBool("isDashing", true);
            AudioManager.instance.Dash();
            StartCoroutine(EndOfDash(0.8f));
            _dashAndCrouchDebounce = DebounceDuration;
            _playerRigidBody.AddForce(Vector3.right * dashForce);
        }
    }

    private IEnumerator EndOfDash(float waitTime)
    {
        // suspend execution for 2 seconds
        yield return new WaitForSeconds(waitTime);
        _animator.SetBool("isDashing", false);
        _animator.SetBool("isCrouching", false);
        player.GetComponent<BoxCollider>().center = _initialColliderCenter;
        player.GetComponent<BoxCollider>().size = _initialColliderSize;
    }

    public void EndOfJump()
    {
        if(_lastYPosition >= player.transform.position.y)
        {
            if (IsGrounded())
            {
                AudioManager.instance.StopJump();
                _animator.SetBool("isJumping", false);
            }
        }
        _lastYPosition = player.transform.position.y;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(player.transform.position, -Vector3.up, _distanceToGround + 0.1f);
    }
}
