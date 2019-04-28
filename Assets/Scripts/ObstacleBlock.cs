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
        var prop = Instantiate(randomObstacle, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0, Random.Range(-35, 35) + invert, 0)) as GameObject;

        var physicalObject = prop.transform.GetChild(0).GetComponent<Collider>();
        prop.transform.position += new Vector3(0, physicalObject.bounds.extents.y + 0.2F, 0);
        
        _deleteOnDestroy.Add(prop.transform);
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
