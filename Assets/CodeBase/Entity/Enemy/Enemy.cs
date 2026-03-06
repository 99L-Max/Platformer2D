using UnityEngine;

public class Enemy : Entity, IVampirable
{
    [SerializeField] private EnemyWay _way;
    [SerializeField] private EnemyAttaker _attaker;
    [SerializeField] private EnemyAttackZone _attackZone;
    [SerializeField] private Animator _animator;

    private StateMachine _stateMachine;
    private Player _targetPlayer;

    [field: SerializeField] public float RestTime { get; private set; } = 2f;
    [field: SerializeField] public float WalkSpeed { get; private set; } = 4f;
    [field: SerializeField] public float RunSpeed { get; private set; } = 6f;

    public bool HasTargetWayPointReached { get; private set; } = false;

    protected override void OnEnable()
    {
        base.OnEnable();
        _attackZone.TargetPlayerChanged += OnTargetPlayerChanged;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _attackZone.TargetPlayerChanged -= OnTargetPlayerChanged;
    }

    private void Awake()
    {
        _stateMachine = new EnemyStateMachineFactory().Create(this, _way, _attaker, _attackZone, _animator);
    }

    private void Update()
    {
        _stateMachine.Update();
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

    protected override void OnDied()
    {
        _stateMachine.ChangeState(null);
        _animator.SetBool(AnimatorData.EnemyParams.IsDied, true);

        base.OnDied();
    }

    private void OnTargetPlayerChanged(Player player)
    {
        _targetPlayer = player;
    }
}
