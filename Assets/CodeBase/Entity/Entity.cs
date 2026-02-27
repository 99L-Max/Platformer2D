using System.Collections;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected Health Health;
    [SerializeField, Min(0.1f)] private float _deathDelay = 1f;

    public IDamageable DamageTaker => Health;

    protected virtual void OnEnable()
    {
        Health.Died += OnDied;
    }

    protected virtual void OnDisable()
    {
        Health.Died -= OnDied;
    }

    protected virtual void OnDied()
    {
        StartCoroutine(Disable());
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(_deathDelay);
        gameObject.SetActive(false);
    }
}
