using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable, IRegeneratable
{
    private const float MinValue = 0f;

    public delegate void ValueHandler(float currentHealth, bool isDamage);

    public event ValueHandler ValueChanged;
    public event Action Died;

    [field: SerializeField, Min(1f)] public float MaxValue { get; private set; } = 20f;
    public float CurrentValue { get; private set; }

    private void Awake()
    {
        CurrentValue = MaxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0f)
        {
            CurrentValue = Mathf.Clamp(CurrentValue - damage, MinValue, MaxValue);
            ValueChanged?.Invoke(CurrentValue, true);

            if (CurrentValue == MinValue)
                Died?.Invoke();
        }
    }

    public void Regenerate(float health)
    {
        if (health > 0f)
        {
            CurrentValue = Mathf.Clamp(CurrentValue + health, MinValue, MaxValue);
            ValueChanged?.Invoke(CurrentValue, false);
        }
    }

    public void Kill()
    {
        CurrentValue = MinValue;
        ValueChanged?.Invoke(CurrentValue, true);
        Died?.Invoke();
    }
}