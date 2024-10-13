using UnityEngine;
using System.Collections;

/// <summary>
/// Implementation of the trap platfrom that throws up the player and spawns portal to the start platform
/// </summary>
public class PortalPlatform : MonoBehaviour
{
    [SerializeField] private GameObject currentPlatformPortal;
    [SerializeField] private GameObject startPlatformPortal;
    [SerializeField] private float throwingVelocity = 10f;

    private bool trapActivated = false;
    private Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !trapActivated)
        {
            StartCoroutine(other.gameObject.GetComponent<PlayerController>().ThrowUpPlayer(throwingVelocity));
            trapActivated = true;
            player = other.transform;
            StartCoroutine(MakePortalsActiveAfterFewSeconds());
        }
    }

    private IEnumerator MakePortalsActiveAfterFewSeconds()
    {
        yield return new WaitForSeconds(1.5f);
        currentPlatformPortal.SetActive(true);
        startPlatformPortal.SetActive(true);

        float timeAfterPortalAppearance = 0f;
        while (timeAfterPortalAppearance < 2.25f)
        {
            currentPlatformPortal.transform.position = new Vector3(player.position.x,
                currentPlatformPortal.transform.position.y, player.position.z);
            timeAfterPortalAppearance += Time.deltaTime;
            yield return null;
        }
    }
}
