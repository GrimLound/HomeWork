using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReview : MonoBehaviour
{
    [SerializeField] Camera _CameraRotate;
    [SerializeField] GameObject _Player;

    float _Sensitivity = 250f;
    float smoothtime = 0.1f;
    float _xRot;
    float _xRotCurrent;
    float _xCurrentVelosity;
    float _yRot;
    float _yRotCurrent;
    float _yCurrentVelosity;

    private void Update()
    {
        _xRot += Input.GetAxis("Mouse X") * Time.fixedDeltaTime * _Sensitivity;    
        _yRot += Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * _Sensitivity;
        _yRot = Mathf.Clamp(_yRot, -90, 90);
        _yRotCurrent = Mathf.SmoothDamp(_yRotCurrent, _xRot, ref _yCurrentVelosity, smoothtime);
        _xRotCurrent = Mathf.SmoothDamp(_xRotCurrent, _xRot, ref _xCurrentVelosity, smoothtime);
        _CameraRotate.transform.rotation = Quaternion.Euler(-_yRot, _xRot, 0f);

        _Player.transform.rotation = Quaternion.Euler(0f, _xRot, 0f);
    }
}
