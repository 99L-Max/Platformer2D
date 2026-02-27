using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= OnValueChanged;
    }

    private void Start()
    {
        UpdateValue(_health.CurrentValue, _health.MaxValue);
    }

    private void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }

    private void OnValueChanged(float currentHealth, bool isDamage) 
    { 
        UpdateValue(currentHealth, _health.MaxValue);
    }

    public abstract void UpdateValue(float currentValue, float maxValue);
}
