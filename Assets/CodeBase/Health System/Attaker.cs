using System.Collections;
using UnityEngine;

public abstract class Attaker : MonoBehaviour
{
    [SerializeField] protected float Distance = 2f;
    [SerializeField] protected float Damage = 5f;

    [SerializeField] private float _cooldown = 1f;
    [SerializeField] private AudioSource _audioAttack;

    protected bool CanAttack = true;

    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_cooldown);
    }

    protected IEnumerator Recover()
    {
        yield return _wait;
        CanAttack = true;
    }

    protected void PlayAttackSound()
    {
        _audioAttack.Play();
    }
}
