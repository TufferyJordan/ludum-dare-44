using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class SpawnerPlatform : MonoBehaviour
{
    private const int PlatformLength = 8;
    private const int PlatformCountAhead = 5;

    public Object[] basicPlatform;
    public Object[] obstaclePlatform;
    public Object[] buildingPlatform;
    
    public GameObject player;

    private int _nextSpawnLocation;
    
    // Start is called before the first frame update
    void Start()
    {
        _nextSpawnLocation = -1;
        
        while (_nextSpawnLocation < PlatformCountAhead)
        {
            var selectedPlatform = RandomPlatformOf(basicPlatform);
            CreateNewPlatform(selectedPlatform, _nextSpawnLocation);
            _nextSpawnLocation++;
        }
    }

    private GameObject CreateNewPlatform(Object selectedPlatform, int location)
    {
        var newPlatform = Instantiate(selectedPlatform, new Vector3(location * PlatformLength, 0, 0), Quaternion.identity) as GameObject;
        newPlatform.transform.SetParent(this.transform);
        return newPlatform;
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
        if (ShouldSpawnNewPlatform())
        {
            SpawnNextPlatform();
        }
    }

    private bool ShouldSpawnNewPlatform()
    {
        return player.transform.position.x - ((_nextSpawnLocation - PlatformCountAhead) * PlatformLength) > 0;
    }
    
    private void SpawnNextPlatform()
    {
        var selectedPlatform = SelectRandomPlatform();
        CreateNewPlatform(selectedPlatform, _nextSpawnLocation);
        _nextSpawnLocation++;
    }

    public GameObject FindActivePlatform()
    {
        return FindPlatformUnder(player.transform.position.x);
    }

    public GameObject FindNextPlatform()
    {
        return FindPlatformUnder(player.transform.position.x + PlatformLength);
    }

    private GameObject FindPlatformUnder(float position)
    {
        foreach (Transform platform in transform)
        {
            var platformLeftmost = platform.position.x - PlatformLength / 2F;
            if (platformLeftmost < position && position < (platformLeftmost + PlatformLength))
            {
                return platform.gameObject;
            }
        }

        throw new IndexOutOfRangeException();
    }

    public float FindPlatformRelativePosition()
    {
        var playerLeftmost = (player.transform.position.x - PlatformLength / 2F);
        return (playerLeftmost % PlatformLength) / (PlatformLength * 1F);
    }
}
