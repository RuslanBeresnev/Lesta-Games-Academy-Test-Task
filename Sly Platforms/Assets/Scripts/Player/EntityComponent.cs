using UnityEngine;

/// <summary>
/// Implementation of the component for entities that have health points and can get damage
/// </summary>
public class EntityComponent : MonoBehaviour
{
    [SerializeField] private float healthPoints = 100f;

    public float HealthPoints
    {
        get => healthPoints;
        set
        {
            healthPoints = value;
            if (value <= 0)
            {
                healthPoints = 0f;
                KillEntity();
            }
        }
    }

    public void DealDamage(float damage)
    {
        HealthPoints -= damage;
    }

    public void KillEntity()
    {
        // «агрузка сцены с меню поражени€ или блокировка игры и высвечивание текста
    }
}
