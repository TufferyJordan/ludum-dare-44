using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class ObstacleBlock : MonoBehaviour
{
    public Object[] props;
    
    private List<Transform> _deleteOnDestroy;
    
    void Start()
    {
        _deleteOnDestroy = new List<Transform>();
        
        var randomObstacle = props[Random.Range(0, props.Length)];

        var invert = Random.Range(0, 2) == 0 ? 0 : 180;

        var spawn = FindSpawnPoint();
        var prop = Instantiate(randomObstacle, spawn, Quaternion.Euler(0, Random.Range(-35, 35) + invert, 0)) as GameObject;

        _deleteOnDestroy.Add(prop.transform);
    }

    private Vector3 FindSpawnPoint()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, 0))
        {
            return hit.point;
        }
        else
        {
            return transform.position + new Vector3(0, 1, 0);
        }
    }

    void Update()
    {
        
    }

    private void OnDestroy()
    {
        foreach (var delete in _deleteOnDestroy)
        {
            if(delete != null)
            {
                Destroy(delete.gameObject);
            }
        }
    }
}
