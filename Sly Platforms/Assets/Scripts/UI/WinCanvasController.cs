using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Implementation of the win canvas
/// </summary>
public class WinCanvasController : MonoBehaviour
{
    [SerializeField] private Canvas HUD;
    [SerializeField] private TextMeshProUGUI elapsedTimeText;
    [SerializeField] private PlayerController player;

    private void OnEnable()
    {
        HUD.gameObject.SetActive(false);
        player.CanMove = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        (var minutes, var seconds) = Timer.GetElapsedTime();
        elapsedTimeText.text = $"{minutes}:{seconds}";
    }

    public void OnRetryButtonPressed()
    {
        SceneManager.LoadScene("Game");
        Timer.GameWasStarted = false;
        Timer.GameStartTime = 0f;
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
