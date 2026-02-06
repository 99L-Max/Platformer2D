public class ToPatrolStateTransition : Transition
{
    private readonly Enemy _enemy;
    private readonly EnemyAttackZone _attackZone;

    public ToPatrolStateTransition(PatrolState nextState, Enemy enemy, EnemyAttackZone attackZone) : base(nextState)
    {
        _enemy = enemy;
        _attackZone = attackZone;
    }

    protected override bool CanTransit()
    { 
        return _attackZone.DoesContainPlayers() == false && _enemy.HasTargetWayPointReached == false;
    }
}
