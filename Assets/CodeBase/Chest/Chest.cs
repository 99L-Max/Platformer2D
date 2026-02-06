using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CoinSpawner))]
public class Chest : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioOpen;
    private CoinSpawner _coinsSpawner;
    private bool _isOpened = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioOpen = GetComponent<AudioSource>();
        _coinsSpawner = GetComponent<CoinSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isOpened == false && other.GetComponent<ChestOpener>())
        {
            _isOpened = true;
            _audioOpen.Play();
            _animator.SetBool(AnimatorData.ChestParams.IsOpened, _isOpened);
            _coinsSpawner.Spawn();
        }
    }
}
