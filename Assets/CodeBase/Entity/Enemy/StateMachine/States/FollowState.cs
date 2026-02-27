using UnityEngine;

public class FollowState : State
{
    private readonly Enemy _enemy;
    private readonly EnemyAttaker _attaker;
    private readonly Animator _animator;
    private readonly Rotator _rotator;

    public FollowState(IStateChanger stateChanger, Enemy enemy, EnemyAttaker attaker, Animator animator) : base(stateChanger)
    {
        _enemy = enemy;
        _animator = animator;
        _attaker = attaker;
        _rotator = new Rotator();
    }

    public override void Enter()
    {
        _animator.SetBool(AnimatorData.EnemyParams.IsFollowing, true);
    }

    public override void Exit()
    {
        _animator.SetBool(AnimatorData.EnemyParams.IsFollowing, false);
    }

    protected override void OnUpdate()
    {
        if (_enemy.TryGetTargetPlayer(out Player player))
        {
            _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, player.transform.position, _enemy.RunSpeed * Time.deltaTime);
            _rotator.SetDirectionX(_enemy.transform, player.transform.position);
            _attaker.TryAttack(player);
        }
    }
}
