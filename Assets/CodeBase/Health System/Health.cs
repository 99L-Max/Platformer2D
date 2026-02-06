using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable, IRegeneratable
{
    [SerializeField] private float _maxHealth = 20f;
    [SerializeField] private AudioSource _audioRegenerate;
    [SerializeField] private AudioSource _audioDamage;
    [SerializeField] private AudioSource _audioDead;
    [SerializeField] private Animator _animator;

    private float _currentHealth;
    public delegate void HealthHandler(float currentHealth, bool isDamage);

    public event HealthHandler HealthChanged;
    public event Action Died;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0f)
        {
            _currentHealth -= damage;

            if (_currentHealth > 0f)
            {
                ReportDamage();
            }
            else
            {
                ReportDeath();
            }
        }
    }

    public void Regenerate(float health)
    {
        if (health > 0f)
        {
            _currentHealth += health;

            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }

            ReportRegeneration();
        }
    }

    public void Kill()
    {
        _currentHealth = 0f;
        ReportDeath();
    }

    private void ReportRegeneration()
    {
        _audioRegenerate.Play();
        HealthChanged?.Invoke(_currentHealth, false);
    }

    private void ReportDamage()
    {
        _audioDamage.Play();
        HealthChanged?.Invoke(_currentHealth, true);
    }

    private void ReportDeath()
    {
        _audioDead.Play();
        Died?.Invoke();
    }
}
