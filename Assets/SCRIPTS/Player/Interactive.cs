using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] Camera _PlayerCamera;
    float _MaxDistance = 1;
    Ray _Ray;
    RaycastHit _Hit;
    private void Update()
    {
        Ray();
        DrawRay();
        InteractDoor();
    }
    private void Ray()
    {
        _Ray = _PlayerCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }
    void DrawRay()
    {
        if (Physics.Raycast(_Ray, out _Hit, _MaxDistance))
        {
            Debug.DrawRay(_Ray.origin, _Ray.direction * _MaxDistance, Color.green);
        }
        if (_Hit.transform == null)
        {
            Debug.DrawRay(_Ray.origin, _Ray.direction * _MaxDistance, Color.red);
        }
    }

    void InteractDoor()
    {
        if (_Hit.transform != null && _Hit.transform.tag == "Door")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _Hit.transform.GetComponent<OpenDoor>().OpenDoors();
            }
        }
    }
}
