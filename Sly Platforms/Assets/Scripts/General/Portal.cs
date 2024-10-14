using UnityEngine;

/// <summary>
/// Implementation of teleportation to the pair portal
/// </summary>
public class Portal : MonoBehaviour
{
    [SerializeField] private Portal pairPortal;
    // This is the point in space where object will appear after teleportation
    [SerializeField] private Transform pointOfAppearance;

    public Transform PointOfAppearance => pointOfAppearance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var delta = pairPortal.PointOfAppearance.position - other.transform.position;
            other.gameObject.GetComponent<CharacterController>().Move(delta);
        }
        else
        {
            other.transform.position = pairPortal.PointOfAppearance.position;
        }
    }
}
