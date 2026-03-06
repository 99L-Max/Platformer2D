using UnityEngine;

public class HeartTaker : MonoBehaviour, IRegeneratable
{
    [SerializeField] private Health _health;
    [SerializeField] private AudioSource _audioSource;

    public void Regenerate(float health)
    {
        _health.Regenerate(health);
        _audioSource.Play();
    }
}
