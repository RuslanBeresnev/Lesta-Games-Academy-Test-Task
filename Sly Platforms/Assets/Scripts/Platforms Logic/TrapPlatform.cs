using UnityEngine;

/// <summary>
/// General class for the all trap platforms
/// </summary>
public abstract class TrapPlatform : MonoBehaviour
{
    protected bool mechanismIsRunning = false;

    public abstract void ActivateTrap();
}
