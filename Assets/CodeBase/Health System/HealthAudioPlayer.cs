using UnityEngine;

public class HealthAudioPlayer : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private AudioSource _audioDamage;
    [SerializeField] private AudioSource _audioRegenerate;
    [SerializeField] private AudioSource _audioDied;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float currentHealth, bool isDamage)
    {
        if (isDamage)
            _audioDamage.Play();
        else
            _audioRegenerate.Play();
    }

    private void OnDied()
    {
        _audioDied.Play();
    }
}
