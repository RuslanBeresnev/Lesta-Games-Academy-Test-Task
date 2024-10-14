using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Implementation of the main menu behavior
/// </summary>
public class MainMenuController : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
