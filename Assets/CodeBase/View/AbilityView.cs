using UnityEngine;

public class AbilityView : MonoBehaviour
{
    [SerializeField] private Ability _ability;
    [SerializeField] private BarView _bar;

    private void OnEnable()
    {
        _ability.TimeChanged += OnTimeChanged;
    }

    private void OnDisable()
    {
        _ability.TimeChanged -= OnTimeChanged;
    }

    private void OnTimeChanged(float time, float maxTime)
    {
        _bar.UpdateValue(time, maxTime);
    }
}
