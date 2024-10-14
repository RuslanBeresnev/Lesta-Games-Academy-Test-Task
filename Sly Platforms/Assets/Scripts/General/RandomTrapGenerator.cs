using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Implementation of the generator for random trap platforms insertion to way gaps
/// </summary>
public class RandomTrapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject gapPointsParentObject;
    [SerializeField] private List<GameObject> trapTypes;
    [SerializeField] private GameObject parentObjectForGeneratedTrapPlatforms;

    private void Awake()
    {
        GenerateRandomTrapPlatformsInWayGaps();
    }

    private void GenerateRandomTrapPlatformsInWayGaps()
    {
        for (int i = 0; i < gapPointsParentObject.transform.childCount; i++)
        {
            var point = gapPointsParentObject.transform.GetChild(i);
            int trapType = Random.Range(0, trapTypes.Count);
            Instantiate(trapTypes[trapType], point.position, Quaternion.identity,
                parentObjectForGeneratedTrapPlatforms.transform);
        }
    }
}
