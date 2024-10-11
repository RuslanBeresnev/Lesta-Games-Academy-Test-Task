using UnityEngine;
using System.Collections;

/// <summary>
/// Damaging platform type behavior implementation
/// </summary>
public class DamagingPlatform : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    [SerializeField] private Material idleStateMaterial;
    [SerializeField] private Material activatedStateMaterial;
    [SerializeField] private Material damagingStateMaterial;

    [SerializeField] private float damage;

    private bool mechanismIsRunning = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !mechanismIsRunning)
        {
            mechanismIsRunning = true;
            StartCoroutine(PerformTrapTripping());
        }
    }

    private IEnumerator PerformTrapTripping()
    {
        meshRenderer.material = activatedStateMaterial;
        yield return new WaitForSeconds(1);
        DealDamageToAllEntitiesOnPlatform();
        meshRenderer.material = damagingStateMaterial;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.material = idleStateMaterial;
        yield return new WaitForSeconds(4.5f);
        mechanismIsRunning = false;
    }

    private void DealDamageToAllEntitiesOnPlatform()
    {
        var overlapBoxCenter = transform.position + new Vector3(0f, GetComponent<Collider>().bounds.size.y, 0f);
        Collider[] overlappedColliders = Physics.OverlapBox(overlapBoxCenter, GetComponent<Collider>().bounds.extents,
            Quaternion.identity);
        foreach (var collider in overlappedColliders)
        {
            var entityComponent = collider.GetComponent<EntityComponent>();
            if (entityComponent != null)
            {
                entityComponent.DealDamage(damage);
            }
        }
    }
}
