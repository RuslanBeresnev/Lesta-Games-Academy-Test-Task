using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Implementation of the win canvas
/// </summary>
public class WinCanvasController : MonoBehaviour
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
