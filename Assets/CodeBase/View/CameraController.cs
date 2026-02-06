using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _positionOffset;
    [SerializeField] private float _smooth = 0.2f;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _positionOffset, _smooth * Time.deltaTime);
    }
}
