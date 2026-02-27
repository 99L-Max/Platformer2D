using System;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Parallax[] _parallaxes;
    [SerializeField] private float _parallaxSpeed = 0.01f;

    private float[] _speeds;
    private float _previousCameraX;
    private float _cameraSpeedX;
    private Vector3 _position;

    private void Awake()
    {
        _position = transform.position;
        _previousCameraX = _camera.position.x;
        _speeds = new float[_parallaxes.Length];

        for (int i = 0; i < _speeds.Length; i++)
        {
            _speeds[i] = 1f - Convert.ToSingle(i) / _speeds.Length;
        }
    }

    private void LateUpdate()
    {
        UpdatePosition();
        UpdateSpeeds();
    }

    private void UpdatePosition()
    {
        _cameraSpeedX = (_camera.position.x - _previousCameraX) / Time.deltaTime;
        _previousCameraX = _camera.position.x;

        _position.x = _camera.position.x;
        _position.y = _camera.position.y;

        transform.position = _position;
    }

    private void UpdateSpeeds()
    {
        for (int i = 0; i < _parallaxes.Length; i++)
        {
            _parallaxes[i].Speed = _speeds[i] * _cameraSpeedX * _parallaxSpeed;
        }
    }
}
