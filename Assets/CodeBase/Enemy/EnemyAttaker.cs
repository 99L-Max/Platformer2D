using UnityEngine;

public class EnemyAttaker : Attaker
{
    public void TryAttack(Player player)
    {
        if (CanAttack && AtAttackDistance(player))
        {
            CanAttack = false;
            player.Damageable.TakeDamage(Damage);

            PlayAttackSound();
            StartCoroutine(Recover());
        }
    }

    private bool AtAttackDistance(Player player)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= Distance;
    }
}
