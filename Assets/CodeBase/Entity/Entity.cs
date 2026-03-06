using System.Collections;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IDamageable
{
    [SerializeField] protected Health Health;
    [SerializeField, Min(0.1f)] private float _deathDelay = 1f;

    public bool IsAlive => Health.IsAlive;

    protected virtual void OnEnable()
    {
        Health.Died += OnDied;
    }

    protected virtual void OnDisable()
    {
        Health.Died -= OnDied;
    }

    public void TakeDamage(float damage)
    {
        Health.TakeDamage(damage);
    }

    public void Kill()
    {
        Health.Kill();
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
