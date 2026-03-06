using System.Collections;
using UnityEngine;

public class VampireAbility : Ability
{
    [SerializeField] private Health _vampireHealth;
    [SerializeField] private GameObject _radiusVisual;
    [SerializeField] private float _radius = 6f;
    [SerializeField] private float _damagePerInterval = 2f;

    private void Start()
    {
        _radiusVisual.SetActive(false);
        _radiusVisual.transform.localScale = new Vector3(_radius, _radius, _radius);
    }

    protected override IEnumerator Use()
    {
        _radiusVisual.SetActive(true);

        for (var time = ActivityTime; time > 0f; time -= IntervalInSeconds)
        {
            UpdateTime(time, ActivityTime);

            if (TryFindNearestTarget(out IVampirable target))
            {
                if (target.IsAlive)
                {
                    target.TakeDamage(_damagePerInterval);
                    _vampireHealth.Regenerate(_damagePerInterval);
                }
            }

            yield return WaitInterval;
        }

        _radiusVisual.SetActive(false);
        UpdateTime(0f, ActivityTime);
    }

    private bool TryFindNearestTarget(out IVampirable target)
    {
        target = null;

        var targets = Physics2D.OverlapCircleAll(transform.position, _radius);
        var minDistance = Mathf.Infinity;

        foreach (var hits in targets)
        {
            if (hits.TryGetComponent(out IVampirable vampirable))
            {
                var distance = Vector2.Distance(transform.position, hits.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    target = vampirable;
                }
            }
        }

        return target != null;
    }
}
