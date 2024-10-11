using UnityEngine;
using System.Collections;

/// <summary>
/// Damaging platform type behavior implementation
/// </summary>
public class DamagingPlatform : TrapPlatform
{
    [SerializeField] private MeshRenderer meshRenderer;

    [SerializeField] private Material idleStateMaterial;
    [SerializeField] private Material activatedStateMaterial;
    [SerializeField] private Material damagingStateMaterial;

    [SerializeField] private float damage;

    public override void ActivateTrap()
    {
        if (!mechanismIsRunning)
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
            collider.GetComponent<EntityComponent>()?.DealDamage(damage);
        }
    }
}
