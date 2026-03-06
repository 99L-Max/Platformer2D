using UnityEngine;

public class HealthAudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioDamage;
    [SerializeField] private AudioClip _audioDied;

    public void PlayAudioDamage(bool isAlive)
    {
        _audioSource.PlayOneShot(isAlive ? _audioDamage : _audioDied);
    }
}
