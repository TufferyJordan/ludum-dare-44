using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class SpawnerPlatform : MonoBehaviour
{
    public Object[] basicPlatform;
    public Object[] obstaclePlatform;
    public Object[] buildingPlatform;

    private int currentLocation;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentLocation = -1;

        var spawned = new List<GameObject>();

        var PLATFORM_LENGTH = 8;
        while (currentLocation < 4)
        {
            var selectedPlatform = SelectRandomPlatform();
            spawned.Add(Instantiate(selectedPlatform, new Vector3(currentLocation * PLATFORM_LENGTH, 0, 0), Quaternion.identity) as GameObject);
            currentLocation++;
        }
    }

    private Object SelectRandomPlatform()
    {
        var platforms = new[] {basicPlatform, obstaclePlatform, buildingPlatform};
        var platformType = RandomIntRange(0, 3);
        var currentPlatformType = platforms[platformType];
        var selectedPlatform = currentPlatformType[RandomIntRange(0, currentPlatformType.Length)];
        return selectedPlatform;
    }

    private static int RandomIntRange(int min, int max)
    {
        var randomIntRange = (int)Math.Floor((double)Random.Range(min, max));
        return randomIntRange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
