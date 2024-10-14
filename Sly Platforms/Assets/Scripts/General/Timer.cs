using UnityEngine;

/// <summary>
/// Implementation of the game time measurement
/// </summary>
public class Timer : MonoBehaviour
{
    public static bool GameWasStarted { get; set; } = false;

    public static float GameStartTime { get; set; } = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !GameWasStarted)
        {
            GameWasStarted = true;
            GameStartTime = Time.time;
        }
    }

    public static (int minutes, int seconds) GetElapsedTime()
    {
        float elapsedTime = Time.time - GameStartTime;
        int minutes = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime % 60);
        return (minutes, seconds);
    }
}
