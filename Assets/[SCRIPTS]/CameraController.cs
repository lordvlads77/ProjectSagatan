using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _followTarget = default;
    [SerializeField] private Vector3 _offset = default;
    [SerializeField] private float _currentZoom = default;
    [SerializeField] float _pitch = default;
    [SerializeField] private float _zoomSpeed = default;
    [SerializeField] private float _zoomMin = default;
    [SerializeField] private float _zoomMax = default;
    [SerializeField] private float _yawSpeed = default;
    [SerializeField] private float _yawInput = default;

    private void Update()
    {
        _currentZoom -= Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
        _currentZoom = Mathf.Clamp(_currentZoom, _zoomMin, _zoomMax);
        _yawInput -= Input.GetAxis("Horizontal") * _yawSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        transform.position = _followTarget.position - _offset * _currentZoom;
        transform.LookAt(_followTarget.position + Vector3.up * _pitch);
        
        transform.RotateAround(_followTarget.position, Vector3.up, _yawInput);
    }
}
