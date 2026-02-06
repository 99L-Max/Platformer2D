public class ToFollowStateTransition : Transition
{
    private readonly EnemyAttackZone _attackZone;

    public ToFollowStateTransition(FollowState nextState, EnemyAttackZone attackZone) : base(nextState)
    {
        _attackZone = attackZone;
    }

    protected override bool CanTransit()
    {
        return _attackZone.DoesContainPlayers();
    }
}
