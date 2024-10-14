using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Implementation of the component for entities that have health points and can get damage
/// </summary>
public class EntityComponent : MonoBehaviour
{
    [SerializeField] private float maxHealthPoints = 100f;
    [SerializeField] UnityEvent<float, float> hpChanged;
    [SerializeField] private Canvas lossCanvas;

    private float healthPoints;

    public float MaxHealthPoints
    {
        get => maxHealthPoints;
        private set => maxHealthPoints = value;
    }

    public float HealthPoints
    {
        get => healthPoints;
        set
        {
            if (value <= 0)
            {
                healthPoints = 0f;
                hpChanged.Invoke(0f, MaxHealthPoints);
                KillEntity();
            }
            else if (value != healthPoints)
            {
                healthPoints = value;
                hpChanged.Invoke(HealthPoints, MaxHealthPoints);
            }
        }
    }

    private void Awake()
    {
        HealthPoints = MaxHealthPoints;
    }

    public void DealDamage(float damage)
    {
        HealthPoints -= damage;
    }

    public void KillEntity()
    {
        lossCanvas.gameObject.SetActive(true);
    }
}
