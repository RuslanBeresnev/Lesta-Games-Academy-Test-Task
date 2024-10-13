using UnityEngine;
using System.Collections;

/// <summary>
/// Implementation of the platform that causes damage to the player by poisoning while he is within the platform
/// </summary>
public class PoisonousPlatform : MonoBehaviour
{
    [SerializeField] private float damagePerSecond = 20f;

    private EntityComponent player;
    private Coroutine damageDealingCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject.GetComponent<EntityComponent>();
            damageDealingCoroutine = StartCoroutine(DealPoisoningDamage());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine(damageDealingCoroutine);
            damageDealingCoroutine = null;
        }
    }

    private IEnumerator DealPoisoningDamage()
    {
        while (true)
        {
            player.DealDamage(damagePerSecond * Time.deltaTime);
            Debug.Log(player.HealthPoints);
            yield return null;
        }
    }
}
