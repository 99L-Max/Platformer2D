using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    [Header("Optional Settings")]
    [SerializeField] private BarView _bar;
    [SerializeField] private HealthAnimator _animator;
    [SerializeField] private HealthAudioPlayer _audio;

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
        _bar?.UpdateValue(_health.CurrentValue, _health.MaxValue);
    }

    private void OnValueChanged(float currentHealth, float maxValue, bool isDamage)
    {
        _bar?.UpdateValue(currentHealth, maxValue);

        if (isDamage)
        {
            _audio?.PlayAudioDamage(_health.IsAlive);
            _animator?.ShowDamageAnimation();
        }
    }
}

