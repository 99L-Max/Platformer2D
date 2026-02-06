using UnityEngine;

public class EnemyWay : MonoBehaviour 
{
    [SerializeField] private Transform _way;

    private Transform _targetPoint;
    private Transform[] _wayPoints;
    private int _indexCurrentPoint = 0;

    public Vector3 TargetPosition => _targetPoint.position;

    private void Awake()
    {
        _wayPoints = new Transform[_way.childCount];

        for (int i = 0; i < _wayPoints.Length; i++)
        {
            _wayPoints[i] = _way.GetChild(i);
        }

        _targetPoint = _wayPoints[_indexCurrentPoint];
    }

    public void Next()
    {
        _indexCurrentPoint = ++_indexCurrentPoint % _wayPoints.Length;
        _targetPoint = _wayPoints[_indexCurrentPoint];
    }

    public bool IsTargetPoint(EnemyWayPoint point)
    {
        return point.transform.position == TargetPosition;
    }
}
