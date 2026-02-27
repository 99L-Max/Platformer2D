using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : HealthView
{
    [SerializeField] private Image _barImage;
    [SerializeField] private Gradient _gradient;

    protected float FillAmount
    {
        get => _barImage.fillAmount;
        set => SetFillAmount(value);
    }

    public override void UpdateValue(float currentValue, float maxValue)
    {
        SetFillAmount(currentValue / maxValue);
    }

    private void SetFillAmount(float value)
    {
        _barImage.fillAmount = value;
        _barImage.color = _gradient.Evaluate(value);
    }
}
