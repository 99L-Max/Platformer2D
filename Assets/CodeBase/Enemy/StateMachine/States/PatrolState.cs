using UnityEngine;

public class PatrolState : State
{
    private readonly Enemy _enemy;
    private readonly EnemyWay _way;
    private readonly Animator _animator;
    private readonly Rotator _rotator;

    public PatrolState(IStateChanger stateChanger, Enemy enemy, EnemyWay way, Animator animator) : base(stateChanger)
    {
        _enemy = enemy;
        _way = way;
        _animator = animator;
        _rotator = new Rotator();
    }

    public override void Enter()
    {
        _rotator.SetDirectionX(_enemy.transform, _way.TargetPosition);
        _animator.SetBool(AnimatorData.EnemyParams.IsPatrolling, true);
    }

    protected override void OnUpdate()
    {
        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _way.TargetPosition, _enemy.WalkSpeed * Time.deltaTime);
    }

    public override void Exit()
    {
        _animator.SetBool(AnimatorData.EnemyParams.IsPatrolling, false);
    }
}
