using UnityEngine;

/// <summary>
/// Implementation of the win mechanic when the player reaches the end of the route
/// </summary>
public class WinTriggerController : MonoBehaviour
{
    [SerializeField] private Canvas winCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            winCanvas.gameObject.SetActive(true);
        }
    }
}
