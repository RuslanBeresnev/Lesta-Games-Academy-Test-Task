using UnityEngine;
using System.Collections;

/// <summary>
/// Implementation of the platform with wind zone where the player is blown in a random direction
/// </summary>
public class WindZonePlatform : MonoBehaviour
{
    [SerializeField] private float windStrength = 6f;

    private Vector3 windDirection = Vector3.forward;

    private void Awake()
    {
        StartCoroutine(GenerateNewWindDirectionEveryFewSeconds());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterController>().Move(windDirection * Time.deltaTime);
        }
    }

    private IEnumerator GenerateNewWindDirectionEveryFewSeconds()
    {
        while (true)
        {
            windDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized * windStrength;
            yield return new WaitForSeconds(2f);
        }
    }
}
