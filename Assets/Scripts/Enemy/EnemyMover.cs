using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _way;
    [SerializeField] private float _moveSpeed = 4f;

    private Transform[] _wayPoints;
    private Transform _targetPoint;
    private int _indexCurrentPoint = 0;
    private bool _isMoving = true;

    public Vector3 TargetPosition => _targetPoint.position;

    public event Action WayPointReached;

    private void Awake()
    {
        _wayPoints = new Transform[_way.childCount];

        for (int i = 0; i < _wayPoints.Length; i++)
        {
            _wayPoints[i] = _way.GetChild(i);
        }

        _targetPoint = _wayPoints[_indexCurrentPoint];
        transform.position = _targetPoint.position;
    }

    private void Update()
    {
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, _moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyWayPoint point))
        {
            if (point.transform == _targetPoint)
            {
                _isMoving = false;
                WayPointReached?.Invoke();
            }
        }
    }

    public void MoveNextPoint()
    {
        _indexCurrentPoint = ++_indexCurrentPoint % _wayPoints.Length;
        _targetPoint = _wayPoints[_indexCurrentPoint];
        _isMoving = true;
    }
}
