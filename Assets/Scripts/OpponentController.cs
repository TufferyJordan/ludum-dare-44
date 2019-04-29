using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    public GameObject player;

    private OpponentRule _listener;
    private Collider _collider;
    private SkinnedMeshRenderer _meshRenderer;

    public void RegisterListener(OpponentRule listener)
    {
        _listener = listener;
        _collider = GetComponent<Collider>();
        _meshRenderer = GameObject.Find("Group63374").GetComponent<SkinnedMeshRenderer>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        _listener.DoActionOnCollision(_collider, other);
    }

    private void Update()
    {
        if (transform.position.x + 0.3F > player.transform.position.x)
        {
            if (_meshRenderer.enabled)
            {
                _meshRenderer.enabled = false;
            }
        }
        else
        {
            if (!_meshRenderer.enabled)
            {
                _meshRenderer.enabled = true;
            }
        }
    }
}
