public class ToRestStateTransition : Transition
{
    private readonly EnemyAttackZone _attackZone;
    private readonly Enemy _enemy;

    public ToRestStateTransition(State nextState, Enemy enemy, EnemyAttackZone attackZone) : base(nextState)
    {
        _enemy = enemy;
        _attackZone = attackZone;
    }

    protected override bool CanTransit()
    {
        return _attackZone.DoesContainPlayers() == false && _enemy.HasTargetWayPointReached;
    }
}
