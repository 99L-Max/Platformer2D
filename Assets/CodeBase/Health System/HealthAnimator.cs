using System.Collections;
using UnityEngine;

public class HealthAnimator : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _showTime = 1f;
    [SerializeField] private int _animatorLayerDamageIndex = 1;

    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_showTime);
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float currentHealth, bool isDamage)
    {
        if (isDamage)
        {
            StartCoroutine(ShowLayer());
        }
    }

    private IEnumerator ShowLayer()
    {
        _animator.SetLayerWeight(_animatorLayerDamageIndex, 1);
        yield return _wait;
        _animator.SetLayerWeight(_animatorLayerDamageIndex, 0);
    }
}
