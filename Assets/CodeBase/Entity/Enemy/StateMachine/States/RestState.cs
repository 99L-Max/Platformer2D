using System.Collections;
using UnityEngine;

public class RestState : State
{
    private readonly Enemy _enemy;
    private readonly WaitForSeconds _rest;
    private readonly Animator _animator;

    private Coroutine _restCoroutine;

    public RestState(IStateChanger stateChanger, Enemy enemy, Animator animator) : base(stateChanger)
    {
        _enemy = enemy;
        _animator = animator;
        _rest = new WaitForSeconds(enemy.RestTime);
    }

    public override void Enter()
    {
        _animator.SetBool(AnimatorData.EnemyParams.IsPatrolling, false);
        _animator.SetBool(AnimatorData.EnemyParams.IsFollowing, false);
        _restCoroutine = _enemy.StartCoroutine(Rest());
    }

    public override void Exit()
    {
        _enemy.StopCoroutine(_restCoroutine);
        _enemy.ResetEnemyPositionStatus();
    }

    private IEnumerator Rest()
    {
        yield return _rest;
        _enemy.ResetEnemyPositionStatus();
    }
}
