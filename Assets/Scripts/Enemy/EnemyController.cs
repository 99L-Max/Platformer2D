using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private float _waitingTime = 3f;

    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_waitingTime);
    }

    private void OnEnable()
    {
        _mover.WayPointReached += Rest;
    }

    private void OnDisable()
    {
        _mover.WayPointReached -= Rest;
    }

    private void Rest()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        _animator.UpdateAnimationRunning(false);
        yield return _wait;

        _mover.MoveNextPoint();
        _animator.UpdateAnimationRunning(true);

        var x = _mover.TargetPosition.x - _mover.gameObject.transform.position.x;
        _animator.SetDirectionX(x);
    }
}
