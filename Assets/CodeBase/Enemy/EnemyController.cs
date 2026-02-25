using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Health _health;
    [SerializeField] private EnemyAttackZone _attackZone;

    private void OnEnable()
    {
        _health.Died += OnDied;
        _attackZone.TargetPlayerChanged += OnTargetPlayerChanged;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
        _attackZone.TargetPlayerChanged -= OnTargetPlayerChanged;
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
