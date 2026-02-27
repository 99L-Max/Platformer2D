using System.Collections;
using UnityEngine;

public class HealthBarSmoothView : HealthBarView
{
    [SerializeField] private float _speed = 0.5f;

    private Coroutine _drainCoroutine;
    private float _targetFillAmount = 1f;

    public override void UpdateValue(float currentValue, float maxValue)
    {
        _targetFillAmount = Mathf.Clamp01(currentValue / maxValue);
        _drainCoroutine ??= StartCoroutine(ChangeBar());
    }

    private IEnumerator ChangeBar()
    {
        while (Mathf.Approximately(FillAmount, _targetFillAmount) == false)
        {
            FillAmount = Mathf.MoveTowards(FillAmount, _targetFillAmount, _speed * Time.deltaTime);
            yield return null;
        }

        _drainCoroutine = null;
    }
}
