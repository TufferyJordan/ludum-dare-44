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
    private float _dashDebounce;
    private Rigidbody _playerRigidBody;
    private Animator _animator;

    void Awake()
    {
        _jumpDebounce = 0;
        _dashDebounce = 0;
        _distanceToGround = player.transform.GetComponent<Collider>().bounds.extents.y;
        _playerRigidBody = player.transform.gameObject.GetComponent<Rigidbody>();
        _animator = GameObject.Find("Character").GetComponent<Animator>();
        _lastYPosition = player.transform.position.y;
    }

    private void Update()
    {
        EndOfJump();
        _jumpDebounce -= Time.deltaTime;
        _dashDebounce -= Time.deltaTime;
    }


    public void Jump()
    {
        if (isActiveAndEnabled && IsGrounded() && _jumpDebounce <= 0)
        {
            _animator.SetBool("isJumping", true);
            _jumpDebounce = DebounceDuration;
            _playerRigidBody.AddForce(Vector3.up * jumpForce);
        }
    }

    public void DashForward()
    {
        AudioManager.instance.Dash();
        if (isActiveAndEnabled && IsGrounded() && _dashDebounce <= 0)
        {
            _animator.SetBool("isDashing", true);
            StartCoroutine(EndOfDash(0.8f));
            _dashDebounce = DebounceDuration;
            _playerRigidBody.AddForce(Vector3.right * dashForce);
        }
    }

    private IEnumerator EndOfDash(float waitTime)
    {
        // suspend execution for 2 seconds
        yield return new WaitForSeconds(waitTime);
        _animator.SetBool("isDashing", false);
    }

    public void EndOfJump()
    {
        if(_lastYPosition >= player.transform.position.y) {
            if(IsGrounded())
            {
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
