using UnityEngine;

public class PlayerAttaker : Attaker
{
    public void TryAttack()
    {
        if (CanAttack)
        {
            CanAttack = false;
            Attack();
            PlayAttackSound();
            StartCoroutine(Recover());
        }
    }

    private void Attack()
    {
        var hits = Physics2D.RaycastAll(transform.position, Vector2.right, Distance);

        foreach (var hit in hits)
        {
            if (hit.collider.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(Damage);
                return;
            }
        }
    }
}
