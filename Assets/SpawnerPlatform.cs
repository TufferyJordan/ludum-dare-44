using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class SpawnerPlatform : MonoBehaviour
{
    private const int PlatformLength = 8;
    private const int PlatformCountAhead = 5;
    private const int MovementVelocity = 7;
    
    public Object[] basicPlatform;
    public Object[] obstaclePlatform;
    public Object[] buildingPlatform;

    private int _nextSpawnLocation;
    private List<GameObject> _spawned;
    
    // Start is called before the first frame update
    void Start()
    {
        _nextSpawnLocation = -1;
        
        _spawned = new List<GameObject>();

        while (_nextSpawnLocation < PlatformCountAhead)
        {
            var selectedPlatform = RandomPlatformOf(basicPlatform);
            _spawned.Add(CreateNewPlatform(selectedPlatform, _nextSpawnLocation));
            _nextSpawnLocation++;
        }
    }

    private GameObject CreateNewPlatform(Object selectedPlatform, int location)
    {
        return Instantiate(selectedPlatform, new Vector3(location * PlatformLength, 0, 0), Quaternion.identity) as GameObject;
    }

    private Object SelectRandomPlatform()
    {
        var platforms = new[] {basicPlatform, obstaclePlatform, buildingPlatform};
        var platformType = RandomIntRange(0, 3);
        var currentPlatformType = platforms[platformType];
        var selectedPlatform = RandomPlatformOf(currentPlatformType);
        return selectedPlatform;
    }

    private static Object RandomPlatformOf(Object[] currentPlatformType)
    {
        return currentPlatformType[RandomIntRange(0, currentPlatformType.Length)];
    }

    private static int RandomIntRange(int min, int max)
    {
        return (int)Math.Floor((double)Random.Range(min, max));
    }

    void Update()
    {
        transform.position += new Vector3(MovementVelocity * Time.deltaTime, 0, 0);
        if (ShouldSpawnNewPlatform())
        {
            SpawnNextPlatform();
        }
    }

    private bool ShouldSpawnNewPlatform()
    {
        return transform.position.x - ((_nextSpawnLocation - PlatformCountAhead) * PlatformLength) > 0;
    }
    
    private void SpawnNextPlatform()
    {
        var selectedPlatform = SelectRandomPlatform();
        _spawned.Add(CreateNewPlatform(selectedPlatform, _nextSpawnLocation));
        _nextSpawnLocation++;
    }
}
