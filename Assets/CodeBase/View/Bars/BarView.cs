using UnityEngine;

public abstract class BarView : MonoBehaviour
{
    private Quaternion _initialRotation;

    private void Awake()
    {
        _initialRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        transform.rotation = _initialRotation;
    }

    public abstract void UpdateValue(float currentValue, float maxValue);
}
