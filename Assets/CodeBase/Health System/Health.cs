using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable, IRegeneratable
{
    private const float MinHealth = 0f;

    public delegate void HealthHandler(float currentHealth, bool isDamage);

    public event HealthHandler HealthChanged;
    public event Action Died;

    [field: SerializeField, Min(1f)] public float MaxHealth { get; private set; } = 20f;
    public float CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0f)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, MinHealth, MaxHealth);
            HealthChanged?.Invoke(CurrentHealth, true);

            if (CurrentHealth == MinHealth)
                Died?.Invoke();
        }
    }

    public void Regenerate(float health)
    {
        if (health > 0f)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + health, MinHealth, MaxHealth);
            HealthChanged?.Invoke(CurrentHealth, false);
        }
    }

    public void Kill()
    {
        CurrentHealth = MinHealth;
        HealthChanged?.Invoke(CurrentHealth, true);
        Died?.Invoke();
    }
}
