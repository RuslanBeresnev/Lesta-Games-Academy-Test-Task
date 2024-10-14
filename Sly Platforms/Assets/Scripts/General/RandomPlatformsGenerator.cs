using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Implementation of the generator for random type platforms (safe platforms and traps)
/// </summary>
public class RandomPlatformsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject spawnPointsParentObject;
    [SerializeField] private List<GameObject> platformTypes;
    [SerializeField] private GameObject parentObjectForGeneratedPlatforms;

    private void Awake()
    {
        GenerateRandomPlatforms();
    }

    private void GenerateRandomPlatforms()
    {
        for (int i = 0; i < spawnPointsParentObject.transform.childCount; i++)
        {
            var point = spawnPointsParentObject.transform.GetChild(i);
            int trapType = Random.Range(0, platformTypes.Count);
            Instantiate(platformTypes[trapType], point.position, Quaternion.identity,
                parentObjectForGeneratedPlatforms.transform);
        }
    }
}
