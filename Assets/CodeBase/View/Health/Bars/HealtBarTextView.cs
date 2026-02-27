using TMPro;
using UnityEngine;

public class HealtBarTextView : HealthView
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField, Range(0, 2)] private int _decimalPlaces = 1;

    private string _format;

    private void Awake()
    {
        _format = $"F{_decimalPlaces}";
    }

    public override void UpdateValue(float currentValue, float maxValue)
    {
        _text.text = $"{currentValue.ToString(_format)} / {maxValue.ToString(_format)}";
    }
}
