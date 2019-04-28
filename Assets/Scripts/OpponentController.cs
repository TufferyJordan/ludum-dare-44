using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    private OpponentRule _listener;
    private Collider _collider;

    public void RegisterListener(OpponentRule listener)
    {
        _listener = listener;
        _collider = GetComponent<Collider>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        _listener.DoActionOnCollision(_collider, other);
    }
}
