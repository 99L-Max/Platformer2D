using UnityEngine;

public class EnemyStateMachineFactory
{
    public StateMachine Create(Enemy enemy, EnemyWay way, EnemyAttaker attaker, EnemyAttackZone attackZone, Animator animator)
    {
        var stateMachine = new StateMachine();

        var patrolState = new PatrolState(stateMachine, enemy, way, animator);
        var followState = new FollowState(stateMachine, enemy, attaker, animator);
        var restState = new RestState(stateMachine, enemy, animator);

        var toPatrolStateTransition = new ToPatrolStateTransition(patrolState, enemy, attackZone);
        var toFollowStateTransition = new ToFollowStateTransition(followState, attackZone);
        var toRestStateTransition = new ToRestStateTransition(restState, enemy, attackZone);

        patrolState.AddTransition(toRestStateTransition);
        patrolState.AddTransition(toFollowStateTransition);

        followState.AddTransition(toRestStateTransition);
        followState.AddTransition(toPatrolStateTransition);

        restState.AddTransition(toPatrolStateTransition);
        restState.AddTransition(toFollowStateTransition);

        stateMachine.ChangeState(patrolState);
        return stateMachine;
    }
}
