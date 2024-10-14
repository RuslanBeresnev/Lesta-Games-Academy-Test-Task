using UnityEngine;

/// <summary>
/// Implementation of the game over mechanic when the player falls down
/// </summary>
public class BottomTriggerController : MonoBehaviour
{
    [SerializeField] private Canvas lossCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            lossCanvas.gameObject.SetActive(true);
        }
    }
}
