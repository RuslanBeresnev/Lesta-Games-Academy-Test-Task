using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Implementation of the loss canvas
/// </summary>
public class LossCanvasController : MonoBehaviour
{
    [SerializeField] private Canvas HUD;
    [SerializeField] private PlayerController player;

    private void OnEnable()
    {
        HUD.gameObject.SetActive(false);
        player.CanMove = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void OnRetryButtonPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
