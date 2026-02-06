using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Health _health;
    [SerializeField] private EnemyAttackZone _attackZone;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimatorLayer _damageLayer;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
        _health.Died += OnDied;
        _attackZone.TargetPlayerChanged += OnTargetPlayerChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
        _health.Died -= OnDied;
        _attackZone.TargetPlayerChanged -= OnTargetPlayerChanged;
    }

    private void OnHealthChanged(float currentHealth, bool isDamage)
    {
        if (isDamage)
        {
            _damageLayer.ShowLayer(AnimatorData.EnemyParams.DamageLayer);
        }
    }

    private void OnDied()
    {
        gameObject.SetActive(false);
    }

    private void OnTargetPlayerChanged(Player player)
    {
        _enemy.SetTargetPlayer(player);
    }
}
