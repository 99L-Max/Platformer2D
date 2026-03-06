using System;
using UnityEngine;

public class Health : MonoBehaviour, IRegeneratable, IDamageable
{
    private const float MinValue = 0f;

    public delegate void ValueHandler(float currentValue, float maxValue, bool isDamage);

    public event ValueHandler ValueChanged;
    public event Action Died;

    [field: SerializeField, Min(1f)] public float MaxValue { get; private set; } = 20f;
    public float CurrentValue { get; private set; }
    public bool IsAlive => CurrentValue > MinValue;

    private void Awake()
    {
        CurrentValue = MaxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0f)
        {
            SetValue(CurrentValue - damage, true);
        }
    }

    public void Regenerate(float health)
    {
        if (health > 0f)
        {
            SetValue(CurrentValue + health, false);
        }
    }

    public void Kill()
    {
        SetValue(MinValue, true);
    }

    private void SetValue(float value, bool isDamage)
    {
        CurrentValue = Mathf.Clamp(value, MinValue, MaxValue);
        ValueChanged?.Invoke(CurrentValue, MaxValue, isDamage);

        if (isDamage && CurrentValue == MinValue)
        {
            Died?.Invoke();
        }
    }
}