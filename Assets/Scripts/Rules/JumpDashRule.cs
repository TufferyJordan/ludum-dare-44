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
    private float _jumpDebounce;
    private float _dashDebounce;
    private Rigidbody _playerRigidBody;

    void Awake()
    {
        _jumpDebounce = 0;
        _dashDebounce = 0;
        _distanceToGround = player.transform.GetComponent<Collider>().bounds.extents.y;
        _playerRigidBody = player.transform.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _jumpDebounce -= Time.deltaTime;
        _dashDebounce -= Time.deltaTime;
    }


    public void Jump()
    {
        if (isActiveAndEnabled && IsGrounded() && _jumpDebounce <= 0)
        {
            _jumpDebounce = DebounceDuration;
            _playerRigidBody.AddForce(Vector3.up * jumpForce);
        }
    }

    public void DashForward()
    {
        if (isActiveAndEnabled && IsGrounded() && _dashDebounce <= 0)
        {
            _dashDebounce = DebounceDuration;
            _playerRigidBody.AddForce(Vector3.right * dashForce);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(player.transform.position, -Vector3.up, _distanceToGround + 0.1f);
    }
}
