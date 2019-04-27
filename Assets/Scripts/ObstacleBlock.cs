using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBlock : MonoBehaviour
{
    private List<Transform> _deleteOnDestroy;
    
    void Start()
    {
        _deleteOnDestroy = new List<Transform>();
        
        foreach (Transform prop in transform)
        {
            prop.SetParent(null);
            _deleteOnDestroy.Add(prop);
        }
    }

    void Update()
    {
        
    }

    private void OnDestroy()
    {
        foreach (var delete in _deleteOnDestroy)
        {
            Destroy(delete.gameObject);
        }
    }
}
