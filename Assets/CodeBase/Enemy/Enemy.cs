using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyWay _way;
    [SerializeField] private EnemyAttaker _attaker;
    [SerializeField] private EnemyAttackZone _attackZone;
    [SerializeField] private Health _health;
    [SerializeField] private Animator _animator;

    private StateMachine _stateMachine;
    private Player _targetPlayer;

    [field: SerializeField] public float RestTime { get; private set; } = 2f;
    [field: SerializeField] public float WalkSpeed { get; private set; } = 4f;
    [field: SerializeField] public float RunSpeed { get; private set; } = 6f;

    public bool HasTargetWayPointReached { get; private set; } = false;
    public IDamageable DamageTaker => _health;

    private void Awake()
    {
        _stateMachine = new EnemyStateMachineFactory().Create(this, _way, _attaker, _attackZone, _animator);
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    public void SetTargetPlayer(Player player)
    {
        _targetPlayer = player;
    }

    public bool TryGetTargetPlayer(out Player player)
    {
        player = _targetPlayer;
        return _targetPlayer != null;
    }

    public void SetEnemyPositionStatus(EnemyWayPoint point)
    {
        HasTargetWayPointReached = _way.IsTargetPoint(point);

        if (HasTargetWayPointReached)
        {
            _way.Next();
        }
    }

    public void ResetEnemyPositionStatus()
    {
        HasTargetWayPointReached = false;
    }
}
